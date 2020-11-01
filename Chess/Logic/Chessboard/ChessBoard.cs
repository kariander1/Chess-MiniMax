using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Chess
{
    
    public class ChessBoard
    {
        //Label[,] grid;
        BoardTile[,] grid;
        public ChessBoard()
        {
            grid = new BoardTile[8, 8];

            bool flag = true;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {


                    Label temp;

                    temp = new Label();
                    temp.AutoSize = false;

                    Color tempColor;
                    if (flag)
                    {

                        tempColor = Color.PeachPuff;
                    }
                    else
                    {
                        tempColor = Color.Peru;
                    }


                    temp.Size = new Size(50, 50);
                    temp.Location = new Point((i * 50) + 120, ((j * 50) + 70));
                    temp.Visible = true;
                    temp.BorderStyle = BorderStyle.Fixed3D;


                    temp.Name = "Square";
                    grid[i, j] = new BoardTile(temp, tempColor);
                  
                    //GridArea(grid[i, j]);
                    flag = !flag;
                }
                flag = !flag;
            }
        }
        public Label GetLabel(Point p)
        {
            return grid[p.X - 1, p.Y - 1].GetSquare();
        }
        
        public BoardTile[,] GetGrid()
        {
            return this.grid;
        }
        public BoardTile GetTile(int i, int j)
        {
            return this.grid[i,j];
        }
        public BoardTile GetTile(Point p)
        {
            return grid[p.X - 1, p.Y - 1];
        }
        public void AddPiece(Piece piece)
        {
            Point temp=piece.GetPosition();
            grid[temp.X-1, temp.Y-1].SetPiece(piece);
            
        }
        public void RemovePiece(Piece piece)
        {
            Point temp = piece.GetPosition();
            grid[temp.X - 1, temp.Y - 1].RemovePiece();
        }        
        public void OriginalColorSquare()
        {
          
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j].GetSquare().BackColor = grid[i, j].GetColor();

                }
          
            }
        }        
        public void GridArea(Label l)
        {
            //l.MouseMove += (sender, e) =>
            //{
            //    if (playerFirst)
            //    {
            //        if (!moved)
            //            this.Cursor = Cursors.Hand;
            //        else
            //            this.Cursor = Cursors.WaitCursor;
            //    }
            //    else
            //    {
            //        if (moved)
            //            this.Cursor = Cursors.Hand;
            //        else
            //            this.Cursor = Cursors.WaitCursor;
            //    }
            //};

        }
        public bool IsEnded()
        {
            return (GetSumCertainPieces(ChessPieces.King, true) == 0 || GetSumCertainPieces(ChessPieces.King, false) == 0);
        }
        public int GetSumCertainPieces(ChessPieces chessPiece, bool isblack)
        {
            int sum = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j].IsOccuppied())
                    {
                        Piece temp = GetTile(i, j).GetPiece();
                        if (temp.GetChessPieceType() == chessPiece && temp.IsBlack() == isblack)
                            sum++;
                    }
                }
            }
            return sum;

        }
        public override string ToString()
        {
            string s="";
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (i == 0)
                {
                    s += " ";
                    for (int k = 0; k < 8; k++)
                    {
                        if (k != 7)
                            s += "   ";
                        else
                            s += "   ";
                    }
                }
                else
                {
                    s += " ";
                    for (int k = 0; k < 8; k++)
                    {
                        if (k != 7)
                            s += "   ";
                        else
                            s += "   ";
                    }
                }
                s += "\n";
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if(grid[i, j].GetPiece()==null)
                        s += "    ";
                    else
                        s += " " + grid[i, j].GetPiece().ToShortString();
                }
                s += "\n";
            }
            return s;
        }

        //Methods To do
      

       
        public void MakeMove(Move move)
        {
            Piece p = grid[move.GetSourcePoint().X-1, move.GetSourcePoint().Y-1].GetPiece();
            
            grid[move.GetSourcePoint().X-1, move.GetSourcePoint().Y-1].RemovePiece();
            if (grid[move.GetDestinationPoint().X - 1, move.GetDestinationPoint().Y - 1].IsOccuppied())
                move.SetEatenPiece(grid[move.GetDestinationPoint().X - 1, move.GetDestinationPoint().Y - 1].GetPiece());
            grid[move.GetDestinationPoint().X-1, move.GetDestinationPoint().Y-1].SetPiece(p);
            grid[move.GetDestinationPoint().X - 1, move.GetDestinationPoint().Y - 1].GetPiece().SetPosition(move.GetDestinationPoint());
           
        }

        public void UndoMove(Move move)
        {
            MakeMove(new Move(move.GetDestinationPoint(), move.GetSourcePoint()));
            if (move.GetEatenPiece() != null)
            {
                grid[move.GetDestinationPoint().X - 1, move.GetDestinationPoint().Y - 1].SetPiece(move.GetEatenPiece());

            }
            
        }
        public List<Move> GetOrderedMoves(ChessPlayer player)
        {
            List<Move> possibleMoves = new List<Move>();
            possibleMoves.Clear();
           
            foreach (BoardTile bd in grid)
            {
                if (bd.IsOccuppied())                
                    if ((bd.GetPiece().IsBlack() && player.isBlack) || (!bd.GetPiece().IsBlack() && !player.isBlack))
                    {
                        List<Point> points = bd.GetPiece().GetPoints();

                        for (int i = 1; i < points.Count; i++)
                        {
                            possibleMoves.Add(new Move(bd.GetPiece().position, points[i]));
                        }
                    }
                


            }
            return possibleMoves;
        }
    }
}
