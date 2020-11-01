using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
namespace Chess
{
    class King : Piece
    {
        
        
       

        public King(Point position,ChessPieces pi,  bool isblack)
            : base(position,pi ,isblack)
        {
            if(IsBlack())
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\45px-Chess_kdt45.svg.png"));
            else
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\White\45px-Chess_klt45.svg.png"));
                        
        }
        public override List<Point> Available()
        {

            int x = position.X;
            int y = position.Y;
            
            if (!PointIsThreatened(position))
                AvailableSquares.Add(position);
            x--;
            y--;
            for (int i = 0; i < 2; i++)
            {
                if (!PointIsThreatened(new Point(++x, y))&&RegularValidation(x,y))
                    AvailableSquares.Add(new Point(x, y));
            }
            for (int i = 0; i < 2; i++)
            {
                if (!PointIsThreatened(new Point(x, ++y))&& RegularValidation(x, y))
                    AvailableSquares.Add(new Point(x, y));
            }
            for (int i = 0; i < 2; i++)
            {
                if (!PointIsThreatened(new Point(--x, y)) && RegularValidation(x, y))
                    AvailableSquares.Add(new Point(x, y));
            }
            for (int i = 0; i < 2; i++)
            {
                if (!PointIsThreatened(new Point(x, --y))&& RegularValidation(x, y))
                    AvailableSquares.Add(new Point(x, y));
            }
            
            
            return AvailableSquares;
        }
       
    }
}
