//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Encapsulate Knight behavior
    /// </summary>
    internal class Knight : ChessPieceBase
    {
        internal Knight(ChessBoard board, ChessPieceColor Color) : base(board, Color, ChessPieceType.Knight) { }

        /// <summary>
        /// Return if a specified move is legal for a Knight
        /// </summary>
        internal override bool CanMove(ChessPosition newPosition)
        {
            Contract.Assume(ValidateBounds.IsInBounds(newPosition.RowLoc));
            Contract.Assume(ValidateBounds.IsInBounds(newPosition.ColLoc));

            // End position is your own piece
            if (Board[newPosition.ColLoc, newPosition.RowLoc].PieceColor == base.theChessPiece.PieceColor)
                return false;

            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iEndCol = (int)newPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;
            int iEndRow = (int)newPosition.RowLoc;

            // Test the eight legal positions a knight can move to.
            if ((iEndRow == iStartRow - 2 && iEndCol == iStartCol - 1) ||
                (iEndRow == iStartRow - 2 && iEndCol == iStartCol + 1) ||
                (iEndRow == iStartRow - 1 && iEndCol == iStartCol - 2) ||
                (iEndRow == iStartRow - 1 && iEndCol == iStartCol + 2) ||
                (iEndRow == iStartRow + 2 && iEndCol == iStartCol - 1) ||
                (iEndRow == iStartRow + 2 && iEndCol == iStartCol + 1) ||
                (iEndRow == iStartRow + 1 && iEndCol == iStartCol - 2) ||
                (iEndRow == iStartRow + 1 && iEndCol == iStartCol + 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return if a specified move is legal for a Pawn
        /// </summary>
        internal override bool CanMove()
        {
            int iStartCol = (int)MyPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;

            if (iStartCol > 2 && iStartRow > 1)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol - 2), (RowPos)(iStartRow - 1))))
                    return true;
            }

            if (iStartCol > 2 && iStartRow < 8)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol - 2), (RowPos)(iStartRow + 1))))
                    return true;
            }

            if (iStartCol > 1 && iStartRow > 2)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol - 1), (RowPos)(iStartRow - 2))))
                    return true;
            }

            if (iStartCol < 8 && iStartRow > 2)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol + 1), (RowPos)(iStartRow - 2))))
                    return true;
            }

            if (iStartCol < 7 && iStartRow < 8)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol + 2), (RowPos)(iStartRow + 1))))
                    return true;
            }

            if (iStartCol < 7 && iStartRow > 1)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol + 2), (RowPos)(iStartRow - 1))))
                    return true;
            }

            if (iStartCol > 1 && iStartRow < 7)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol - 1), (RowPos)(iStartRow + 2))))
                    return true;
            }

            if (iStartCol < 8 && iStartRow < 7)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol + 1), (RowPos)(iStartRow + 2))))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Return list of all possible moves piece can make on chess board
        /// </summary>
        internal override List<ChessMove> PossibleMoveList()
        {
            int iStartCol = (int)MyPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;
            List<ChessMove> moves = new List<ChessMove>();

            if (iStartCol > 2 && iStartRow > 1 && Board[iStartCol - 2, iStartRow - 1].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol - 2);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow - 1);

                moves.Add(move);
            }

            if (iStartCol > 2 && iStartRow < 8 && Board[iStartCol - 2, iStartRow + 1].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol - 2);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow + 1);

                moves.Add(move);
            }

            if (iStartCol > 1 && iStartRow > 2 && Board[iStartCol - 1, iStartRow - 2].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol - 1);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow - 2);

                moves.Add(move);
            }

            if (iStartCol < 8 && iStartRow > 2 && Board[iStartCol + 1, iStartRow - 2].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol + 1);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow - 2);

                moves.Add(move);
            }

            if (iStartCol < 7 && iStartRow < 8 && Board[iStartCol + 2, iStartRow + 1].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol + 2);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow + 1);

                moves.Add(move);
            }

            if (iStartCol < 7 && iStartRow > 1 && Board[iStartCol + 2, iStartRow - 1].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol + 2);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow - 1);

                moves.Add(move);
            }

            if (iStartCol > 1 && iStartRow < 7 && Board[iStartCol - 1, iStartRow + 2].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol - 1);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow + 2);

                moves.Add(move);
            }

            if (iStartCol < 8 && iStartRow < 7 && Board[iStartCol + 1, iStartRow + 2].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol + 1);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow + 2);

                moves.Add(move);
            }

            return moves;
        }

        /// <summary>
        /// Do housekeeping after piece is moved. Return move weight
        /// </summary>
        internal override ChessMove DoMoveHousekeeping(ChessPosition oldPosition, ChessPosition newPosition)
        {
            InitialPosition = false;

            var result = new ChessMove
            {
                Result = MoveMessage.MoveSucceeded
            };

            return result;
        }
    }
}
