//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulate Rook behavior
    /// </summary>
    internal class Rook : ChessPieceBase
    {
        internal Rook(ChessBoard board, ChessPieceColor Color) : base(board, Color, ChessPieceType.Rook) { }

        /// <summary>
        /// Return if a specified move is legal for a Rook
        /// </summary>
        internal override bool CanMove(ChessPosition newPosition)
        {
            return CanMoveHorVert(newPosition);
        }

        /// <summary>
        /// Return if piece can move from current location
        /// </summary>
        internal override bool CanMove()
        {
            return CanMoveHorVert();
        }

        /// <summary>
        /// Return list of all possible moves piece can make on chess board
        /// </summary>
        internal override List<ChessMove> PossibleMoveList()
        {
            return MoveHorVertList();
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
