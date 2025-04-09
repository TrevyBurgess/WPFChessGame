//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameAI
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic;

    public class ChessAI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chessBoard"></param>
        /// <param name="movesAhead"></param>
        /// <returns></returns>
        [Pure]
        public static ChessMove SuggestMove(ChessBoard chessBoard, int movesAhead)
        {
            //Contract.Requires<ArgumentNullException>(chessBoard != null);
            //Contract.Requires<ArgumentException>(movesAhead > 0);

            List<ChessMove> chessMoves = ChessBoard.PossibleChessMoves(chessBoard);

            // 
            ChessMove bestMove = new ChessMove();
            foreach (ChessMove move in chessMoves)
            {
                ChessBoard newBoard = new ChessBoard(chessBoard);
                ChessMove currMove =  newBoard.Move(move.OldRookPosition, move.NewRookPosition);
            }

            return bestMove;
        }

        public static ChessMove Move(ChessBoard chessBoard, int Difficulty)
        {
            //try
            //{

            //    ColPos EnPassantCol = ChessEng.EnPassantCol;

            //    if (Difficulty <= 0)
            //        throw new System.ArgumentException("Difficulty level must be 1 or greater.");

            //    // Make list of all possible moves.
            //    ChessMoveList moveList = GetWeightedList(ChessEng.Board, ChessEng.PlayersTurn, Difficulty, ChessEng.CanCastle, EnPassantCol);

            //    // Return best calculated move.
            //    return SelectBestMove(ChessEng.Board, moveList, ChessEng.PlayersTurn, ChessEng.CanCastle, ChessEng.EnPassantCol);
            //}
            //catch
            //{
            //    // No moves left.
            //    return null;
            //}

            return new ChessMove();
        }
    }
}
