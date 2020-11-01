using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Chess
{
    class ControlledPlayer : ChessPlayer 
    {
       
        public ControlledPlayer(bool isBlack)
            : base(isBlack)
        {
            this.isBlack = isBlack;
         
        }
        public override void DoMove()
        {
            //foreach (Piece pie in Pieces)
            //{
            //    bool flag = false;
            //    bool eat = false;
            //    int k = 0;
            //    PictureBox ima = pie.GetImage();
            //    Point originalPoint = pie.GetGridPoint();

            //    ima.MouseEnter += (sender, e) =>
            //    {

            //        MainWindow.pbPiecePicture.Image = pie.GetImage().Image;

            //    };

            //    ima.MouseDown += (sender, e) =>
            //    {
                    
            //            flag = true; // Enable image modifications
            //            ima.BackColor = Color.Red;
            //            PaintSquares(pie.GetPoints());
                    
                    
            //    };
            //    ima.MouseMove += (sender, e) =>
            //    {
            //        label1.Text = PointToChessCoordinates(MouseToGridPoint()).ToString();
            //        if (flag)
            //        {
            //            List<Point> AvailableTiles = pie.GetPoints();
            //            foreach (Point p in AvailableTiles)
            //            {
            //                if (MouseToGridPoint() == p)
            //                {
            //                    ima.Location = Point.Add(board.GetLabel(p).Location, new Size(5, 5));
            //                    ima.BringToFront();

            //                    currentPoint = p;
            //                    ChessPlayer Cp; //Temporary chessplayer which represents the oppoment
            //                    if (pie.IsBlack())
            //                        Cp = Program.Player2;
            //                    else
            //                        Cp = Program.Player1;
            //                    k = 0;
            //                    foreach (Piece pi in Cp.Pieces)
            //                    {
            //                        if (currentPoint == pi.position)
            //                        {
            //                            eat = true;
            //                            break;
            //                        }
            //                        else
            //                            eat = false;
            //                        k++;
            //                    }
            //                    //for (k = 0; k < Cp.Pieces.Length; k++)
            //                    //{
            //                    //    if (currentPoint == Cp.Pieces[k].p) //Checks if piece's current position overwites oppoment piece position
            //                    //    {
            //                    //        eat = true;
            //                    //        break;
            //                    //    }
            //                    //    else
            //                    //        eat = false;

            //                    //}

            //                }
            //            }

            //        }
            //    };
            //    ima.MouseUp += (sender, e) =>
            //    {

            //        flag = false; //Disable image modifications
            //        board.RemovePiece(pie);
            //        pie.SetPosition(currentPoint); //Verify Chess piece new position    

            //        board.OriginalColorSquare();
            //        ima.BackColor = board.GetLabel(currentPoint).BackColor;
            //        if (eat)
            //        {
            //            Piece temp;
            //            if (pie.IsBlack())
            //            {
            //                temp = Program.Player2.GetPiece(k);
            //                Program.Player2.RemovePiece(k);


            //            }
            //            else
            //            {
            //                temp = Program.Player1.GetPiece(k);
            //                Program.Player1.RemovePiece(k);
            //            }
            //            board.RemovePiece(temp);
            //            eat = false;

            //        }
            //        board.AddPiece(pie);
            //        label2.Text = "PC's Remaining Pieces : " + Program.Player2.Pieces.Count;
            //        label3.Text = "Player's Remaining Pieces : " + Program.Player1.Pieces.Count;
            //        if (originalPoint != currentPoint) // Checks if the piece moved from its original spot
            //        {

            //            imglstPiecesPicture.Images.Add(ima.Image);
            //            string color;
            //            if (pie.IsBlack())
            //                color = "Black ";
            //            else
            //                color = "White ";

            //            ListViewItem lvi = new ListViewItem(color + pie.GetChessPieceType().ToString(), imglstPiecesPicture.Images.Count - 1);
            //            lvi.SubItems.Add(PointToChessCoordinates(originalPoint).ToString());
            //            lvi.SubItems.Add(PointToChessCoordinates(currentPoint).ToString());

            //            lstMoveHistory.LargeImageList = imglstPiecesPicture;
            //            lstMoveHistory.Items.Add(lvi);



            //            originalPoint = currentPoint;

            //            if (blacksTurn)
            //            {
            //                label4.Text = "White's Turn";

            //            }
            //            else
            //            {
            //                label4.Text = "Black's Turn";

            //            }
            //            blacksTurn = !blacksTurn;
            //        }
            //        string s = board.ToString();
            //        label6.Text = board.GetSumCertainPieces(ChessPieces.Pawn, false).ToString();
            //    };
            //}
        }
    }
}
