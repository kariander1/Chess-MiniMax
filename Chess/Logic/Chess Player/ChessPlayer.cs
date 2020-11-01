using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{

    public class ChessPlayer
    {

       
        public List<Piece> Pieces;
        public Move bestMove;
        public bool isBlack;
        public int k = -1;

        public ChessPlayer(bool isBlack)
        {
            this.isBlack = isBlack;
            Pieces = new List<Piece>();
       
        }
       
        public virtual void DoMove()
        {

        }
        public void EnablePieces()
        {
            foreach (Piece p in Pieces)
            {
                p.Enabled=true;
            }
        }
        public List<Piece> GetPieces()
        {
            return Pieces;
        }
       
        public void DisablePieces()
        {
            foreach (Piece p in Pieces)
            {
                p.Enabled = false;
               
            }
        }
        public void GeneratePieces(int LeftmostPawnY)
        {
           
            

            for (int i = 0; i < 8; i++)
            {
               
                Pieces.Add(new Pawn(new Point(i + 1, LeftmostPawnY), ChessPieces.Pawn, isBlack));
            }
            if (isBlack)
                LeftmostPawnY++;

            else
                LeftmostPawnY--;
            Piece temp = null;
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                    case 7:
                      
                        temp=(new Rook(new Point(i + 1, LeftmostPawnY), ChessPieces.Rook, isBlack));
                        break;

                    case 1:
                    case 6:
                       
                        temp=(new Knight(new Point(i + 1, LeftmostPawnY), ChessPieces.Knight, isBlack));
                        break;

                    case 2:
                    case 5:
                      
                        temp=(new Bishop(new Point(i + 1, LeftmostPawnY), ChessPieces.Bishop, isBlack));
                        break;

                    case 3:
                       
                        temp=(new Queen(new Point(i + 1, LeftmostPawnY), ChessPieces.Queen, isBlack));
                        break;

                    case 4:
                   
                        temp=(new King(new Point(i + 1, LeftmostPawnY), ChessPieces.King, isBlack));

                        break;
                }
                Pieces.Add(temp);
            }
            
        }       
        public void RemovePiece(int k)
        {            
            Pieces.ElementAt(k).Visible = false;
            Pieces.RemoveAt(k);
        }
        public Piece GetPiece(int k)
        {
            return this.Pieces[k];
        }
       
        public List<Move> GetOrderedMoves()
        {
            List<Move> possibleMoves = new List<Move>();
            possibleMoves.Clear();

            foreach (Piece piece in Pieces)
            {
                List<Point> points = piece.GetPoints();              
                    
                for (int i = 1; i < points.Count; i++)
                {
                    if(points[i]!=piece.GetPosition())
                        possibleMoves.Add(new Move(piece.position, points[i]));
                }


            }
            return possibleMoves;
        }
        public bool Check()
        {
            foreach (Piece pie in Pieces)
            {
                if (pie is King)
                    if (pie.PointIsThreatened(pie.GetPosition()))
                        return true;
            }
            return false;
        }
        public bool CheckMate()
        {
            foreach (Piece pie in Pieces)
            {
                if (pie is King)
                {
                    List<Point> temp = pie.ThreateningRoute;
                    if (pie.GetPoints().Count == 0)
                        foreach (Point p in temp)
                        {
                            foreach (Piece piece in Pieces)
                            {
                                if (!(piece is King))
                                    foreach (Point availPoint in piece.GetPoints())
                                    {
                                        if (availPoint == p)
                                        {
                                            if(MainWindow.rescue)
                                                piece.BackColor = Color.CadetBlue;
                                            return false;
                                            
                                        }
                                    }
                            }
                        }
                    else
                        return false;
                }
            }
            return true;
        }
    }
}
