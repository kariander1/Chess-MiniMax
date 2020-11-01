using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess
{
    class NegaMax
    {
   
        ChessBoard currentBoard;
        private int depth;
        public Move bestMove = null;

        public NegaMax(int depth)
        {
            // TODO: Complete member initialization
            this.depth = depth;
            currentBoard = MainWindow.board;
        }
        int GetDeduction(ChessBoard board,ChessPieces pie)
        {
            return board.GetSumCertainPieces(pie,false) - board.GetSumCertainPieces(pie, true);
        }
        public double Evaluate(ChessBoard board,ChessPlayer player)//from White's point of view
        {
            double sum = 0;
            if (player.isBlack)
            {
                
                sum -= 200 * GetDeduction(board,ChessPieces.King );
                sum -= 9 * GetDeduction(board, ChessPieces.Queen);
                sum -= 5 * GetDeduction(board, ChessPieces.Rook);
                sum -= 3 * (GetDeduction(board, ChessPieces.Bishop) + GetDeduction(board, ChessPieces.Knight));
                sum -= 1 * GetDeduction(board, ChessPieces.Pawn);
                //sum += 0.1 * (currentBoard.GetOrderedMoves(MainWindow.Player1).Count - currentBoard.GetOrderedMoves(MainWindow.Player2).Count);
            }
            else
            {
               
                sum += 200 * GetDeduction(board, ChessPieces.King);
                sum += 9 * GetDeduction(board, ChessPieces.Queen);
                sum += 5 * GetDeduction(board, ChessPieces.Rook);
                sum += 3 * (GetDeduction(board, ChessPieces.Bishop) + GetDeduction(board, ChessPieces.Knight));
                sum += 1 * GetDeduction(board, ChessPieces.Pawn);
                //sum -= 0.1 * (currentBoard.GetOrderedMoves(MainWindow.Player1).Count - currentBoard.GetOrderedMoves(MainWindow.Player2).Count);
                
            }
            
            return sum;
        }
        public void Run(ChessPlayer  player)
        {
            double best = int.MinValue;


            
            foreach (Move move in  currentBoard.GetOrderedMoves(player))
            {
                currentBoard.MakeMove(move);
                double value = -AlphaBeta(depth - 1, int.MinValue, int.MaxValue, player is Computer ? MainWindow.Player1 : MainWindow.Player2);
                if (value > best)
                {   
                    bestMove=move;
                    best = value;
                }
               
                currentBoard.UndoMove(move);
            }
   
        }

      

        double AlphaBeta(int depth, double alpha, double beta, ChessPlayer  player)
        {
            if (depth == 0 || currentBoard.IsEnded())
                return  Evaluate(currentBoard,player);
            
            double best = int.MinValue;

            foreach (Move move in currentBoard.GetOrderedMoves(player))
            {
                currentBoard.MakeMove(move);
                double value = -AlphaBeta(depth - 1, -beta, -alpha, player is Computer ? MainWindow.Player1 : MainWindow.Player2);
                if (value > best)
                    best = value;
                if (best > alpha)
                    alpha = best;
                if (best >= beta)
                {
                    currentBoard.UndoMove(move);
                    break;
                }
                currentBoard.UndoMove(move);
            }
            return best;

        }
    }
}
