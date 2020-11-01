using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Chess
{
    class Knight:Piece
    {
        public Knight(Point position, ChessPieces pi, bool isblack) :base(position,pi,isblack)
        {
            if(isblack)
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\45px-Chess_ndt45.svg.png"));
            else
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\White\45px-Chess_nlt45.svg.png"));
        }
        public override List<Point> Available()
        {

            List<Point> points=new List<Point>();
            int x = position.X;
            int y = position.Y;
            points.Add(position);


            if (RegularValidation(x + 2, y + 1))
                points.Add(new Point(x + 2, y + 1));
            if (RegularValidation(x + 2, y - 1))
                points.Add(new Point(x + 2, y - 1));
            if (RegularValidation(x - 2, y + 1))
                points.Add(new Point(x - 2, y + 1));
            if (RegularValidation(x - 2, y - 1))
                points.Add(new Point(x - 2, y - 1));
            if (RegularValidation(x + 1, y + 2))
                points.Add(new Point(x + 1, y + 2));
            if (RegularValidation(x + 1, y - 2))
                points.Add(new Point(x + 1, y - 2));
            if (RegularValidation(x - 1, y + 2))
                points.Add(new Point(x - 1, y + 2));
            if (RegularValidation(x - 1, y - 2))
                points.Add(new Point(x - 1, y - 2));


         
            return points;
        }

    }
   
}
