using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.IO;

namespace Chess
{

    public partial class MainWindow : Form
    {
        # region DATA
        public static Move lastmove=null;
        public static ChessBoard board;
        public static ChessPlayer Player1;
        public static ChessPlayer Player2;
        DateTime timer;
        public static bool Game=false,free=false,threatRoute=false,rescue=false;
        static bool flag = false;
        Point currentPoint;
        public static bool playerFirst = true, blacksTurn = true;
     
        
        #endregion

        # region C'tor

        public MainWindow()
        {
            InitializeComponent();
           
        }
        #endregion

        # region METHODS
        public void EndGame()
        {
            Game = false;
            Player1.DisablePieces();
            Player2.DisablePieces();
        }
        public void StartingPosition()
        {
            if (Player1.isBlack)
            {
                Player1.GeneratePieces(7);
                Player2.GeneratePieces(2);
            }
            else
            {
                Player1.GeneratePieces(2);
                Player2.GeneratePieces(7);
            }
            for (int i = 0; i < 16; i++)
            {
                DrawPiece(Player1.Pieces[i]);
                board.AddPiece(Player1.Pieces[i]);
                DrawPiece(Player2.Pieces[i]);
                board.AddPiece(Player2.Pieces[i]);
                
            }
          
            
        }
        #region Graphics
        public static void PaintSquares(List<Point> squares)
        {

            foreach (Point p in squares)
            {
                MainWindow.board.GetLabel(p).BackColor = Color.Red;
            }
           
        }
        public void AddImageToMoveList(Piece pie, Point originalPoint)
        {
           
            imglstPiecesPicture.Images.Add(pie.Image);
            string color;
            if (pie.IsBlack())
                color = "Black ";
            else
                color = "White ";

            ListViewItem lvi = new ListViewItem(color + pie.GetChessPieceType().ToString(), imglstPiecesPicture.Images.Count - 1);
            lvi.SubItems.Add(PointToChessCoordinates(originalPoint).ToString());
            lvi.SubItems.Add(PointToChessCoordinates(pie.GetPosition()).ToString());

            lstMoveHistory.LargeImageList = imglstPiecesPicture;
            lstMoveHistory.Items.Add(lvi);
        }
        public  void ApplyMove(Move m)
        {
            
            Piece temp=null;
            Piece eaten = null;
            ChessPlayer temp2;
            ChessPlayer temp3;
            if (blacksTurn && Player1.isBlack)
            {
                temp3 = Player2;
                temp2 = Player1;
            }
            else
            {
                temp3 = Player1;
                temp2 = Player2;
            }
            foreach (Piece pie in temp2.Pieces)
            {
                if (pie.GetPosition() == m.GetSourcePoint())
                    temp = pie;
            }
            int k;
            for (k = 0; k < temp3.Pieces.Count; k++)
            {
                if (temp3.Pieces[k].GetPosition() == m.GetDestinationPoint())
                {
                    eaten = temp3.GetPiece(k);

                    break;
                }
            }
            
            PaintSquares(temp.GetPoints());
            board.GetLabel(m.GetDestinationPoint()).BackColor = Color.Red;
            temp.BackColor = Color.Red;
            if (eaten != null)
                eaten.BackColor = Color.Red;
            Application.DoEvents();

            Thread.Sleep(1500);

            for (int i = 0; i < 5; i++)
            {
                
                board.GetLabel(m.GetDestinationPoint()).BackColor = board.GetTile(m.GetDestinationPoint()).GetColor();
                Application.DoEvents();
                Thread.Sleep(60);
                board.GetLabel(m.GetDestinationPoint()).BackColor = Color.Red;
                Application.DoEvents();
                Thread.Sleep(60);
            }
            
            board.OriginalColorSquare();
            if (eaten != null)
                temp3.RemovePiece(k);


            temp.BackColor = Color.Red;
            
            temp.SetPosition(m.GetDestinationPoint());
            board.MakeMove(m);
            AddImageToMoveList(temp, m.GetSourcePoint());
            temp.Location = Point.Add(board.GetLabel(m.GetDestinationPoint()).Location, new Size(5, 5));
            temp.BringToFront();
            temp.BackColor = board.GetLabel(m.GetDestinationPoint()).BackColor;
            
        }
        void DrawPiece(Piece pie)
        {

            #region Image Properties
            Point p = pie.GetPosition();



            pie.BackColor = board.GetLabel(p).BackColor;
    
            p = Point.Add(board.GetLabel(p).Location, new Size(5, 5));
            pie.Location = p;
            #endregion



            Controls.Add(pie);
            pie.BringToFront();
            pie.MouseEnter += img_MouseEnter;
            pie.MouseDown += pie_MouseDown;
            pie.MouseUp += pie_MouseUp;
            pie.MouseMove += pie_MouseMove;
            ImageMove(pie);
            
        }

        
        void PrintBoard(ChessBoard board)
        {


            bool flag = true;

            for (int i = 0; i < board.GetGrid().GetLength(0); i++)
            {
                for (int j = 0; j < board.GetGrid().GetLength(1); j++)
                {
                    #region Indexes


                    if (i == 0)
                    {
                        Label l = new Label();
                        l.Text = (8 - j).ToString();
                        l.Location = new Point((i * 50) + 100, ((j * 50) + 86));
                        l.Size = new Size(10, 12);
                        Controls.Add(l);

                    }
                    if (j == 0)
                    {
                        Label l = new Label();
                        l.Text = ((char)('a' + i)).ToString();
                        l.Location = new Point((i * 50) + 135, ((j * 50) + 52));
                        l.Size = new Size(10, 13);
                        Controls.Add(l);
                    }
                    #endregion

                    flag = !flag;
                    Controls.Add(board.GetLabel(new Point(i + 1, j + 1)));
                }
                flag = !flag;
            }

        }
    
        #endregion

        #region Coordinates
        public static string PointToChessCoordinates(Point p)
        {
            return (char)((int)'a' + p.X - 1) + (9 - p.Y).ToString();
        }
        public Point MouseToGridPoint()
        {
            for (int i = 0; i < MainWindow.board.GetGrid().GetLength(0); i++)
            {
                for (int j = 0; j < MainWindow.board.GetGrid().GetLength(1); j++)
                {

                    if ((PointToClient(MousePosition).X - ((MainWindow.board.GetGrid()[i, j].GetSquare().Location).X) < 50) && (PointToClient(MousePosition).Y - ((MainWindow.board.GetGrid()[i, j].GetSquare().Location).Y) < 50))
                        return new Point(i + 1, j + 1);
                }
            }
            return (new Point(0, 0));
        }
        #endregion




        public ChessPlayer GetOppoment(Piece p)
        {
            if (p.IsBlack() && Player1.isBlack)
                return Player2;
            else
                return Player1;
        }
        public void ChangeTurn()
        {
            if (!free)
            {
                blacksTurn = !blacksTurn;
                if (Player1.isBlack == blacksTurn)
                {
                    Player2.DisablePieces();
                    Player1.EnablePieces();
                }
                else
                {
                    Player1.DisablePieces();
                    Player2.EnablePieces();
                }
                if (blacksTurn)
                {

                    label4.Text = "Black's Turn";

                }
                else
                {
                    label4.Text = "White's Turn";
                }
            }
        }
        public void ChangeTurn(bool blackTurn)
        {
            if (!free)
            {
                blacksTurn = blackTurn;
                if (Player1.isBlack == blacksTurn)
                {
                    Player2.DisablePieces();
                    Player1.EnablePieces();
                }
                else
                {
                    Player1.DisablePieces();
                    Player2.EnablePieces();
                }
                if (blacksTurn)
                    label4.Text = "Black's Turn";

                else
                    label4.Text = "White's Turn";
            }
        }
        void ImageMove(Piece pie) //Split Method and orginization
        {
            
            
             
      
                  
        }
        
        
        
        
        #endregion

        #region EVENTS
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            MainWindow.board = new ChessBoard();
            PrintBoard(MainWindow.board);
        }

        
        

        void pie_MouseDown(object sender, MouseEventArgs e)
        {
            Piece pie = (Piece)sender;
            currentPoint = pie.GetPosition();
            flag = true; // Enable image modifications
            pie.BackColor = Color.Red;
            PaintSquares(pie.GetPoints());
            foreach (Point p in pie.GetPoints())
            {
                foreach (Piece piece in GetOppoment(pie).GetPieces())
                {
                    if (piece.GetPosition() == p)
                        piece.BackColor = Color.Red;
                }
            }
        }
        void pie_MouseMove(object sender, MouseEventArgs e)
        {

            Piece pie = (Piece)sender;
            
            label1.Text = PointToChessCoordinates(MouseToGridPoint()).ToString();
            if (flag)
            {
                foreach (Point p in pie.GetPoints())
                {
                    if (MouseToGridPoint() == p)
                    {
                        pie.Location = Point.Add(board.GetLabel(p).Location, new Size(5, 5));
                        pie.BringToFront();
                        currentPoint = p;
                    }
                }
            }
        }
        void pie_MouseUp(object sender, MouseEventArgs e)
        {
            Piece pie = (Piece)sender;
            int k;
            Point origPoint = pie.GetPosition();

            flag = false; //Disable image modifications

            board.MakeMove(new Move(pie.GetPosition(), currentPoint));
            board.OriginalColorSquare();
            pie.BackColor = board.GetLabel(currentPoint).BackColor;
            foreach (Piece piece in GetOppoment(pie).GetPieces())
            {
                piece.BackColor = board.GetLabel(piece.GetPosition()).BackColor;
            }
            k = 0;
            foreach (Piece pi in GetOppoment(pie).GetPieces())
            {
                if (currentPoint == pi.position)
                {
                    GetOppoment(pie).RemovePiece(k);
                    break;
                }
                k++;
            }
            if (origPoint != currentPoint) // Checks if the piece moved from its original spot
            {

                AddImageToMoveList(pie, origPoint);
                if (Player2.Check())
                {
                    if (threatRoute)
                    {
                        foreach (Piece piece in Player2.GetPieces())
                        {
                            if (piece is King)

                                foreach (Point p in piece.ThreateningRoute)
                                {
                                    board.GetLabel(p).BackColor = Color.Green;
                                    if (board.GetTile(p).GetPiece() != null)
                                        board.GetTile(p).GetPiece().BackColor = Color.Green;

                                }
                        }
                      
                    }
                    if (Player2.CheckMate())
                    {
                        SoundPlayer simpleSound = new SoundPlayer(Path.GetFullPath(@"Media\tada.wav"));
                        foreach (Piece piece in Player2.GetPieces())
                        {
                            if (piece is King)
                                piece.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        }
                        simpleSound.Play();
                      
                        EndGame();
                    }
                    else
                        MessageBox.Show("Check");
                }
                

                if (Game)
                    ChangeTurn();
                if (Player2 is Computer && Game)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Player2.DoMove();
                    ApplyMove(Player2.bestMove);
                    this.Cursor = Cursors.Default;
                    ChangeTurn();
                }
                if (board.IsEnded() && Game)
                    MessageBox.Show("You lost..");

            }
            string s = MainWindow.board.ToString();
        }

        void img_MouseEnter(object sender, EventArgs e)
        {
            Piece pie = (Piece)sender;

            pbPiecePicture.Image = pie.Image;

            lbPieceProp.Text = pie.ToString();


        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Preferences = new Form2();

            if (Preferences.ShowDialog() == DialogResult.OK)
            {
                MainWindow.Player1 = new ControlledPlayer(true);
                if (Preferences.CompMode)
                {
                    MainWindow.Player2 = new Computer(false);
                }
                else
                    MainWindow.Player2 = new ControlledPlayer(false);

                
                if (playerFirst)
                    blacksTurn = MainWindow.Player1.isBlack;
                else
                    blacksTurn = MainWindow.Player2.isBlack;
                StartingPosition();
                ChangeTurn(blacksTurn);
              
                timer = new DateTime();
                timer1.Enabled = true;
                label5.Text = timer.TimeOfDay.ToString();
                Game = true;
            }
        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer = timer.AddSeconds(1);
            label5.Text = timer.TimeOfDay.ToString();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void freestyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            freestyleToolStripMenuItem.Checked = !freestyleToolStripMenuItem.Checked;
            free = freestyleToolStripMenuItem.Checked;
        }

        private void showThreatningRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showThreatningRouteToolStripMenuItem.Checked = !showThreatningRouteToolStripMenuItem.Checked;
            threatRoute = showThreatningRouteToolStripMenuItem.Checked;
        }

        private void showToTheRescuePieceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showToTheRescuePieceToolStripMenuItem.Checked = !showToTheRescuePieceToolStripMenuItem.Checked;
            rescue = showToTheRescuePieceToolStripMenuItem.Checked;
        }
        

        
    }
}