//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulate Queen behavior
    /// </summary>
    internal class Queen : ChessPieceBase
    {
        internal Queen(ChessBoard board, ChessPieceColor Color) : base(board, Color, ChessPieceType.Queen) { }

        /// <summary>
        /// Return if a specified move is legal for a Queen
        /// </summary>
        internal override bool CanMove(ChessPosition newPosition)
        {
            return CanMoveHorVert(newPosition) || CanMoveDiag(newPosition);
        }

        /// <summary>
        /// Return if piece can move from currentl location
        /// </summary>
        internal override bool CanMove()
        {
            return CanMoveDiag() || CanMoveHorVert();
        }

        /// <summary>
        /// Return list of all possible moves piece can make on chess board
        /// </summary>
        internal override List<ChessMove> PossibleMoveList()
        {
            var moves = MoveDiagList();
            MoveDiagList().AddRange(MoveHorVertList());
            return moves;
        }

        /// <summary>
        /// Do housekeeping after piece is moved. Return move weight
        /// </summary>
        internal override ChessMove DoMoveHousekeeping(ChessPosition oldPosition, ChessPosition newPosition)
        {
            InitialPosition = false;

            return new ChessMove
            {
                Result = MoveMessage.MoveSucceeded
            };
        }
    }
}
