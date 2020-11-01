using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Chess
{
    public class BoardTile
    {
        Label square;
        Piece piece;
        Color originalColor;
        bool occupied;
        public BoardTile(Label l,Color c)
        {
            piece = null;
            occupied = false;
            this.square = l;
            this.originalColor = c;
            square.BackColor=c;
        }
        
        public void SetColor(Color c)
        {
            square.BackColor = c;
        }
        public Color GetColor()
        {
            return originalColor;
        }
        public BoardTile(Label l,Piece currentPiece)
        {
            this.piece = currentPiece;
            occupied = true;
            this.square = l;
        }
        public Piece GetPiece()
        {
            return this.piece;
        }
        public Label GetSquare()
        {
            return this.square;
        }
        public bool IsOccuppied()
        {
            return occupied;
        }
        public void SetPiece(Piece newPiece)
        {
            this.piece = newPiece;
            occupied = true;
        }
        public void RemovePiece()
        {
            this.occupied = false;
            piece = null;
        }
        public void SetSquare(Label l)
        {
            this.square = l;
        }
        public override string ToString()
        {
            return this.piece.ToShortString() + " " + this.piece.position;
        }
    }
}
