//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Encapsulate Pawn behavior
    /// </summary>
    internal class PawnBlack : ChessPieceBase
    {
        internal PawnBlack(ChessBoard board, ChessPieceColor Color) : base(board, Color, ChessPieceType.Pawn) { }

        /// <summary>
        /// Pawn moved 2 apaces
        /// </summary>
        internal bool MovedTwoSpaces { get; private set; }

        /// <summary>
        /// Time the pawn moved 2 spaces
        /// </summary>
        internal int NoOfMovesTime { get; private set; }

        /// <summary>
        /// Return if a specified move is legal for a Pawn
        /// </summary>
        internal override bool CanMove(ChessPosition newPosition)
        {
            Contract.Assume(ValidateBounds.IsInBounds(newPosition.RowLoc));
            Contract.Assume(ValidateBounds.IsInBounds(newPosition.ColLoc));

            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iEndCol = (int)newPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;
            int iEndRow = (int)newPosition.RowLoc;

            // End position is your own piece
            if (Board[newPosition.ColLoc, newPosition.RowLoc].PieceColor == ChessPieceColor.Black)
                return false;

            // Moving forward
            if (iEndCol == iStartCol)
            {
                // Moves 1 space down
                if (iEndRow == iStartRow - 1 &&
                    Board[iEndCol, iStartRow - 1].PieceType == ChessPieceType.EmptySquare)
                {
                    return true;
                }
                // Move 2 spaces down
                else if (iStartRow == 7 && iEndRow == iStartRow - 2 &&
                    Board[iEndCol, iStartRow - 1].PieceType == ChessPieceType.EmptySquare &&
                    Board[iEndCol, iStartRow - 2].PieceType == ChessPieceType.EmptySquare)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Capturing pieces
            else if (iEndCol == iStartCol + 1 || iEndCol == iStartCol - 1)
            {
                // Capturing piece
                if (iEndRow == iStartRow - 1 && Board[iEndCol, iEndRow].PieceType != ChessPieceType.EmptySquare)
                {
                    return true;
                }
                // Check En Passant
                else if (iEndRow == iStartRow - 1 &&
                    Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare &&
                    Board[iEndCol, iEndRow + 1].PieceType == ChessPieceType.Pawn)
                {
                    PawnWhite pawn = Board.GetChessPiece((ColPos)iEndCol, (RowPos)(iEndRow + 1)) as PawnWhite;
                    if (pawn == null)
                    {
                        // there is no pawn we are checking en passant against
                        return false;
                    }
                    else if (pawn.MovedTwoSpaces && Board.undoList.MoveCount == pawn.NoOfMovesTime + 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
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
            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;

            if (iStartRow > 1)
            {
                if (CanMove(new ChessPosition((ColPos)(iStartCol), (RowPos)(iStartRow - 1))))
                    return true;

                if (iStartCol > 1 && CanMove(new ChessPosition((ColPos)(iStartCol - 1), (RowPos)(iStartRow - 1))))
                    return true;

                if (iStartCol < 8 && CanMove(new ChessPosition((ColPos)(iStartCol + 1), (RowPos)(iStartRow - 1))))
                    return true;

                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return list of all possible moves piece can make on chess board
        /// </summary>
        internal override List<ChessMove> PossibleMoveList()
        {
            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;

            var moves = new List<ChessMove>();

            // Two moves ahead
            if (iStartRow == 7 &&
                Board[iStartCol, iStartRow - 1].PieceType == ChessPieceType.EmptySquare &&
                Board[iStartCol, iStartRow - 2].PieceType == ChessPieceType.EmptySquare)
            {
                var move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = MyPosition.ColLoc;
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow - 2);

                moves.Add(move);
            }

            // One move ahead
            if (iStartRow > 1 &&
                Board[iStartCol, iStartRow - 1].PieceType == ChessPieceType.EmptySquare)
            {
                var move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = MyPosition.ColLoc;
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow - 1);

                moves.Add(move);
            }

            // Capture to left
            if (iStartRow > 1 && iStartCol > 1 &&
                Board[iStartCol - 1, iStartRow - 1].PieceType != ChessPieceType.EmptySquare)
            {
                var move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol - 1);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow - 1);

                moves.Add(move);
            }

            // Capture to right
            if (iStartRow > 1 && iStartCol < 8 &&
                Board[iStartCol + 1, iStartRow - 1].PieceType != ChessPieceType.EmptySquare)
            {
                var move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)(iStartCol - 1);
                move.NewRookPosition.RowLoc = (RowPos)(iStartRow + 1);

                moves.Add(move);
            }

            return moves;
        }

        /// <summary>
        /// Do housekeeping after piece is moved. Return move weight
        /// </summary>
        internal override ChessMove DoMoveHousekeeping(ChessPosition oldPosition, ChessPosition newPosition)
        {
            var result = new ChessMove();
            result.Result = MoveMessage.MoveSucceeded;
            InitialPosition = false;

            // Needed to deal with En Passant move
            if (oldPosition.RowLoc == newPosition.RowLoc + 2)
            {
                MovedTwoSpaces = true;
                NoOfMovesTime = Board.undoList.MoveCount;
            }
            else
            {
                MovedTwoSpaces = false;
            }

            // Deal with pawn promotion
            if (newPosition.RowLoc == RowPos.R1)
            {
                result.PawnPromoted = true;
            }

            return result;
        }
    }
}
