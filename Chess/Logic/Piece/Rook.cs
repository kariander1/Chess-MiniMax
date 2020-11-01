using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
namespace Chess
{
    class Rook:Piece
    {
      
        public Rook(Point position,ChessPieces pi, bool isblack)
            : base(position, pi, isblack)
        {
            if(isblack)
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\15351823890172195.png"));
            else
                this.Image = Image.FromFile(Path.GetFullPath(@"Images\White\45px-Chess_rlt45.svg.png"));

        }
        public override List<Point> Available()
        {



            int x = position.X;
            int y = position.Y;
            AvailableSquares.Add(new Point(x, y));

         
            PreValid(x, 1, false);
            PreValid(x, 8, false);
            PreValid(1, y, true);
            PreValid(8, y, true);
            
            return base.AvailableSquares;       
            
        }
      

       
     
    }
    
}
