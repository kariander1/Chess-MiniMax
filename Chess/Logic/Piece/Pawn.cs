using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Chess
{
    class Pawn:Piece
    {
        private Point originalPoint;
        public Pawn(Point position, ChessPieces pi, bool isblack)
            : base(position, pi, isblack)
        {
            this.originalPoint = position;
            if(isblack)
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\45px-Chess_pdt45.svg.png"));
                
            else
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\White\45px-Chess_plt45.svg.png"));
        }
        public override List<Point> Available()
        {
            List<Point> points = new List<Point>();
            points.Add(position);
            int x = position.X;
            int y = position.Y;
            if (IsBlack())
            {
                if (RegularValidation(x, y - 1))
                {
                    points.Add(new Point(x, y - 1));
                    if (y == 7)
                        if (RegularValidation(x, y - 2))
                            points.Add(new Point(x, y - 2));
                }
                if (CanEat(x + 1, y - 1))
                    points.Add(new Point(x + 1, y - 1));
                if (CanEat(x - 1, y - 1))
                    points.Add(new Point(x - 1, y - 1));
            }
            else
            {
                if (RegularValidation(x, y + 1))
                {
                    points.Add(new Point(x, y + 1));

                    if (y == 2)
                        if (RegularValidation(x, y + 2))
                             points.Add(new Point(x, y + 2));
                }
                if (CanEat(x+1,y+1))
                    points.Add(new Point(x + 1, y + 1));
                if (CanEat(x-1,y+1))
                    points.Add(new Point(x - 1, y + 1));
            }
            return points;
        }
        
    }
   
}
