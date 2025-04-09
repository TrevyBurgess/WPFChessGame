//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulate Bishop behavior
    /// </summary>
    internal class Bishop : ChessPieceBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        internal Bishop(ChessBoard board, ChessPieceColor Color) : base(board, Color, ChessPieceType.Bishop) { }

        /// <summary>
        /// Return if a specified move is legal for a Bishop
        /// </summary>
        internal override bool CanMove(ChessPosition newPosition)
        {
            return base.CanMoveDiag(newPosition);
        }
        
        /// <summary>
        /// Return if piece can move from current location
        /// </summary>
        internal override bool CanMove()
        {
            return base.CanMoveDiag();
        }

        /// <summary>
        /// Return list of all possible moves piece can make on chess board
        /// </summary>
        internal override List<ChessMove> PossibleMoveList()
        {
            return base.MoveDiagList();
        }

        /// <summary>
        /// Do housekeeping after piece is moved. Return move weight
        /// </summary>
        internal override ChessMove DoMoveHousekeeping(ChessPosition oldPosition, ChessPosition newPosition)
        {
            InitialPosition = false;

            ChessMove result = new ChessMove();
            result.Result = MoveMessage.MoveSucceeded;

            return result;
        }
    }
}
