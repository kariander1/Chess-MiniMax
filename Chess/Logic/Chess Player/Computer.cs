using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Chess
{
    class Computer : ChessPlayer
    {
        int depth = 4;
        Thread threadThink;
        
     
        public Computer(bool isBlack)
            : base(isBlack)
        {
            this.isBlack = isBlack;

        }

        public override void DoMove()
        {
            
            threadThink = new Thread(new ThreadStart(Think));
            threadThink.IsBackground = true;
            threadThink.Start();
            threadThink.Join();
            
            
         }

        private void Think()
        {
            NegaMax negaMax = new NegaMax(depth);
            negaMax.Run(this);
            this.bestMove = negaMax.bestMove;
           
            
        }
    }
}
