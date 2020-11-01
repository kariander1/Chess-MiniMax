using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Chess
{
    public enum ChessPieces
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }
    public class Piece : PictureBox
    {

        ChessPlayer player,opposite;
        private bool isBlack;
        public List<Point> AvailableSquares;
        public List<Point> ThreateningRoute;
        private ChessPieces pieceType;       
        public Point position;
     
        
        public Piece(Point position, ChessPieces pi,bool isblack)
        {          
            isBlack = isblack;
            this.position = position;
            pieceType = pi;
            if (this.isBlack && MainWindow.Player1.isBlack)
            {
                player = MainWindow.Player1;
                opposite = MainWindow.Player2;
            }
            else
            {
                player = MainWindow.Player2;
                opposite = MainWindow.Player1;
            }
         
          


            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = new Size(40, 40);
            
           
      
        }
     
        public void SetPosition(Point newp)
        {
            this.position = newp;           

        }
        public ChessPieces GetChessPieceType()
        {
            return this.pieceType;
        }
        public bool IsBlack()
        {
            return this.isBlack;
        }
        public List<Point> GetPoints()
        {
            AvailableSquares = new List<Point>();
            return AvailableSquares = Available();
        }
        //public PictureBox GetImage()
        //{
        //    //return this.Image;   
        //}
        public Point GetPosition()
        {
            return position;
        }
      
        public bool RegularValidation(int x, int y)
        {


            if (this.pieceType != ChessPieces.Pawn)
                return (x > 0 && y > 0 && x < 9 && y < 9 && CheckBoard(x, y, player.Pieces));
            else
                return (x > 0 && y > 0 && x < 9 && y < 9 && CheckBoard(x, y, player.Pieces) && CheckBoard(x, y, opposite.Pieces));
        }
        public bool VertHorzValidation(int x, int y, bool ascend, bool horizontal)
        {
            int n;

            if (ascend)
                n = 1;
            else
                n = -1;
            if (x == position.X && y == position.Y)
                return true;
            bool flag;
            if (horizontal)
                flag = VertHorzValidation(x + n, y, ascend, horizontal);
            else
                flag = VertHorzValidation(x, y + n, ascend, horizontal);
            if (flag && CheckBoard(x, y, player.Pieces))
            {
                this.AvailableSquares.Add(new Point(x, y));
                if (CanEat(x,y))
                {
                    return false;
                }
                return true;
            }
            else return false;
        }
        bool CheckBoard(int x, int y, List<Piece> pieces)
        {          
            foreach (Piece p in pieces)
            {
                if (p.GetPosition() == new Point(x, y))
                return false;
            }
            return true;
        }
        public virtual List<Point> Available()
        {
            List<Point> points = new List<Point>();
            points.Add(this.position);
            return points;
        }
        public bool PreValid(int x, int y, bool horizontal)
        {
            int stat, dyna;
            if (horizontal)
            {
                dyna = x;
                stat = y;
            }
            else
            {
                dyna = y;
                stat = x;
            }
            if (dyna == 1)
                return VertHorzValidation(x, y, true, horizontal);
            else
                return VertHorzValidation(x, y, false, horizontal);



        }
        public void DiagonalValidation(int x, int y,int n,int d)
        {
            if (x < 1 || x > 8 || y < 1 || y > 8)
            {
            }
            else
            {
                if (x == position.X && y == position.Y)
                {
                    DiagonalValidation(x + n, y + d, n, d);
                }
                else
                    if (CheckBoard(x, y, player.Pieces))
                    {
                        AvailableSquares.Add(new Point(x, y));
                        if (CheckBoard(x, y, opposite.Pieces))
                            DiagonalValidation(x + n, y + d, n, d);
                    }
            }

        }
        public bool CanEat(int x, int y)
        {
            List<Piece> pieces = opposite.GetPieces(); ;
           
            //for (int i = 0; i < pieces.Length; i++)
            //{
            //    if (pieces[i].GetGridPoint() == new Point(x, y))
            //        return true;

            //}
            foreach (Piece p in pieces)
            {
                if (p.GetPosition() == new Point(x, y))
                    return true;
            }
            return false;
        }
        public bool PointIsThreatened(Point p)
        {
            ThreateningRoute = new List<Point>();
            return (HorizontalThreat(p) || VerticalThreat(p) || DiagonalThreat(p)||KnightThreat(p));
            
        }
        private bool KnightThreat(Point p)
        {
            int x = p.X;
            int y = p.Y;
            Piece temp;
           Point pp = new Point(x+1, y + 2);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           
           pp = new Point(x - 1, y + 2);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           pp = new Point(x + 1, y - 2);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           pp = new Point(x - 1, y - 2);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           pp = new Point(x + 2, y + 1);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           pp = new Point(x - 2, y + 1);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           pp = new Point(x + 2, y - 1);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           pp = new Point(x - 2, y - 1);
           if (!PointOutOfRange(pp))
           {
               if (MainWindow.board.GetTile(pp).GetPiece() != null)
               {
                   temp = MainWindow.board.GetTile(pp).GetPiece();
                   if (temp.isBlack != this.isBlack)
                   {
                       if (temp is Knight)
                       {
                           ThreateningRoute.Add(pp);
                           return true;
                       }
                   }

               }
           }
           return false;
        }
        private bool DiagonalThreat(Point p)
        {
            int x = p.X;
            int y = p.Y;
            Piece temp;
            List<Point> tempPoints = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x+i, y + i);
                if (!PointOutOfRange(pp))
                {

                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else if (temp is Bishop || temp is Queen || (temp is King && i == 1))
                            {
                                ThreateningRoute.AddRange(tempPoints);
                                return true;
                            }
                            else if (temp is Pawn && i == 1)
                            {
                                if (temp.isBlack)
                                {
                                    if (p.Y < temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (p.Y > temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                            }
                            else
                                break;
                        }
                    }
                }
            }
            tempPoints.Clear();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x - i, y + i);
                if (!PointOutOfRange(pp))
                {

                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else if (temp is Bishop || temp is Queen || (temp is King && i == 1))
                            {
                                ThreateningRoute.AddRange(tempPoints);
                                return true;
                            }
                            else if (temp is Pawn && i == 1)
                            {
                                if (temp.isBlack)
                                {
                                    if (p.Y < temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (p.Y > temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                            }
                            else
                                break;
                        }
                    }
                }
            }
            tempPoints.Clear();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x + i, y - i);
                if (!PointOutOfRange(pp))
                {

                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else if (temp is Bishop || temp is Queen || (temp is King && i == 1))
                            {
                                ThreateningRoute.AddRange(tempPoints);
                                return true;
                            }
                            else if (temp is Pawn && i == 1)
                            {
                                if (temp.isBlack)
                                {
                                    if (p.Y < temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (p.Y > temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                            }
                            else
                                break;
                        }
                    }
                }
            }
            tempPoints.Clear();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x - i, y - i);
                if (!PointOutOfRange(pp))
                {

                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else if (temp is Bishop || temp is Queen || (temp is King && i == 1))
                            {
                                ThreateningRoute.AddRange(tempPoints);
                                return true;
                            }
                            else if (temp is Pawn && i == 1)
                            {
                                if (temp.isBlack)
                                {
                                    if (p.Y < temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                                else
                                {
                                    if (p.Y > temp.GetPosition().Y)
                                    {
                                        ThreateningRoute.AddRange(tempPoints);
                                        return true;
                                    }
                                }
                            }
                            else
                                break;
                        }
                    }
                }
            }
            return false;
        }
        private bool HorizontalThreat(Point p)
        {
            int x = p.X;
            int y = p.Y;
            Piece temp;
            List<Point> tempPoints = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x + i, y);
                if (!PointOutOfRange(pp))
                {
                    
                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else
                            {
                                if (temp is Queen || temp is Rook || (temp is King && i == 1))
                                {
                                    ThreateningRoute.AddRange(tempPoints);
                                    return true;
                                }
                                else
                                    break;
                            }
                        } 
                    }
                }
            }
            tempPoints = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x - i, y);
                if (!PointOutOfRange(pp))
                {

                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else
                            {
                                if (temp is Queen || temp is Rook || (temp is King && i == 1))
                                {
                                    ThreateningRoute.AddRange(tempPoints);
                                    return true;
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private bool VerticalThreat(Point p)
        {
            int x = p.X;
            int y = p.Y;
            Piece temp;
            List<Point> tempPoints = new List<Point>();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x, y + i);
                if (!PointOutOfRange(pp))
                {

                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else
                            {
                                if (temp is Queen || temp is Rook || (temp is King && i == 1))
                                {
                                    ThreateningRoute.AddRange(tempPoints);
                                    return true;
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
            }
            ThreateningRoute.Clear();
            for (int i = 1; i < 8; i++)
            {
                Point pp = new Point(x, y - i);
                if (!PointOutOfRange(pp))
                {

                    if (pp == this.position)
                        continue;
                    else
                    {
                        tempPoints.Add(pp);
                        if (MainWindow.board.GetTile(pp).GetPiece() != null)
                        {
                            temp = MainWindow.board.GetTile(pp).GetPiece();
                            if (temp.isBlack == this.isBlack)
                                break;
                            else
                            {
                                if (temp is Queen || temp is Rook || (temp is King && i == 1))
                                {
                                    ThreateningRoute.AddRange(tempPoints);
                                    return true;
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public List<Point> GetThreateningRoute()
        {
            return this.ThreateningRoute;
        }
        public bool PointOutOfRange(Point p)
        {
            return (p.X > 8 || p.X < 1 || p.Y > 8 || p.Y < 1);
        }
        public override string ToString()
        {
            string color;
            if(IsBlack())
                color="Black";
            else
                color="White";
            return (color + " " + pieceType.ToString() + "\nPoint: " + MainWindow.PointToChessCoordinates(position));
        }
        public string ToShortString()
        {
            string s="";
            if (IsBlack())
                s += "b";
            else
                s += "w";
            switch (pieceType)
            {
                case ChessPieces.Bishop:
                    s+="B";
                    break;
                case ChessPieces.King:
                    s += "K";
                    break;
                case ChessPieces.Knight:
                    s += "N";
                    break;
                case ChessPieces.Pawn:
                    s += "P";
                    break;
                case ChessPieces.Queen:
                    s += "Q";
                    break;
                case ChessPieces.Rook:
                    s += "R";
                    break;
            }
            return s;
        }
    }
}
