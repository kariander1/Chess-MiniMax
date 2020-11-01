using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Chess
{
    class Bishop:Piece
    {
        public Bishop(Point position, ChessPieces pi, bool isblack)
            : base(position, pi, isblack)
        {
            if(isblack)
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\45px-Chess_bdt45.svg.png"));
            else
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\White\45px-Chess_blt45.svg.png"));
        }
        public override List<Point> Available()
        {



            int x = position.X;
            int y = position.Y;
            AvailableSquares.Add(new Point(x, y));
         
            DiagonalValidation(x, y, 1, 1);
            DiagonalValidation(x, y, -1, 1);
            DiagonalValidation(x, y, -1, -1);
            DiagonalValidation(x, y, 1, -1);


            return AvailableSquares;
        }

    }
    
    
}
