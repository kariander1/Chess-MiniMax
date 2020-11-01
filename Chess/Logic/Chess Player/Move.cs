using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chess
{
    public class Move
    {
        Point Source, Dest;
       
        Piece eatenPiece;
        public Move(Point Source, Point Dest)
        {
            this.Source = Source;
            this.Dest = Dest;
            
        }
        public Point GetSourcePoint()
        {
            return this.Source;
        }
        public Point GetDestinationPoint()
        {
            return this.Dest;
        }
        public void SetEatenPiece(Piece p)
        {
            this.eatenPiece = p;
        }
        public Piece GetEatenPiece()
        {
            return this.eatenPiece;
        }
    }
}
