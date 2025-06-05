//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    /// <summary>
    /// Verify whether a chess move is possible,
    /// assuming
    /// </summary>
    internal static class ChessMoveVerefication
    {
        /// <summary>
        /// Check to see if piece can move horizontally or vertically. Does not test for check.
        /// </summary>
        internal static bool CanMoveHorVert(ChessBoard Board, ChessPosition MyPosition, ChessPosition newPosition, ChessPieceColor PieceColor)
        {
            // Piece does not move.
            if (MyPosition.ColLoc == newPosition.ColLoc && MyPosition.RowLoc == newPosition.RowLoc)
                return false;

            // End position is your own piece
            if (Board[newPosition.ColLoc, newPosition.RowLoc].PieceColor == PieceColor)
                return false;

            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iEndCol = (int)newPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;
            int iEndRow = (int)newPosition.RowLoc;

            int currPos;
            int endPos;

            // Moving vertically.
            if (MyPosition.ColLoc == newPosition.ColLoc)
            {
                // Count in the correct direction.
                if (iStartRow < iEndRow)
                {
                    currPos = iStartRow;
                    endPos = iEndRow;
                }
                else
                {
                    currPos = iEndRow;
                    endPos = iStartRow;
                }

                // Check if path is clear.
                currPos++;
                while (currPos < endPos)
                {
                    if (Board[iStartCol, currPos].PieceType == ChessPieceType.EmptySquare)
                    {
                        currPos++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // Moving horizantally.
            else if (MyPosition.RowLoc == newPosition.RowLoc)
            {
                // Count in the correct direction.
                if (iStartCol < iEndCol)
                {
                    currPos = iStartCol;
                    endPos = iEndCol;
                }
                else
                {
                    currPos = iEndCol;
                    endPos = iStartCol;
                }

                // Check if path is clear.
                currPos++;
                while (currPos < endPos)
                {
                    if (Board[currPos, iStartRow].PieceType == ChessPieceType.EmptySquare)
                    {
                        currPos++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // Illegal move
            else
            {
                return false;
            }

            // Move succeed.
            return true;
        }

        /// <summary>
        /// Return if piece can move from current location
        /// </summary>
        internal static bool CanMoveHorVert(ChessBoard Board, ChessPosition MyPosition, ChessPieceColor PieceColor)
        {
            int col = (int)MyPosition.ColLoc;
            int row = (int)MyPosition.RowLoc;

            if (col > 1)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col - 1), (RowPos)(row));
                if (CanMoveHorVert(Board, MyPosition, newPosition, PieceColor))
                    return true;
            }

            if (col < 8)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col + 1), (RowPos)(row));
                if (CanMoveHorVert(Board, MyPosition, newPosition, PieceColor))
                    return true;
            }

            if (row > 1)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col), (RowPos)(row - 1));
                if (CanMoveHorVert(Board, MyPosition, newPosition, PieceColor))
                    return true;
            }

            if (row < 8)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col), (RowPos)(row + 1));
                if (CanMoveHorVert(Board, MyPosition, newPosition, PieceColor))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check to see if piece can move diagonnally. Does not test for check.
        /// </summary>
        internal static bool CanMoveDiag(ChessBoard Board, ChessPosition MyPosition, ChessPosition newPosition, ChessPieceColor PieceColor)
        {
            // Piece does not move.
            if (MyPosition.ColLoc == newPosition.ColLoc && MyPosition.RowLoc == newPosition.RowLoc)
                return false;

            // End position is your own piece
            if (Board[newPosition.ColLoc, newPosition.RowLoc].PieceColor == PieceColor)
                return false;

            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iEndCol = (int)newPosition.ColLoc;
            int iStartRow = (int)MyPosition.RowLoc;
            int iEndRow = (int)newPosition.RowLoc;

            // Piece has moved diagonally.
            if (System.Math.Abs(iStartCol - iEndCol) == System.Math.Abs(iStartRow - iEndRow))
            {
                int diffCol = iEndCol - iStartCol > 0 ? 1 : -1;
                int diffRow = iEndRow - iStartRow > 0 ? 1 : -1;
                int currCol = iStartCol + diffCol;
                int currRow = iStartRow + diffRow;

                // Check if path is clear.
                while (currCol != iEndCol)
                {
                    if (Board[currCol, currRow].PieceType == ChessPieceType.EmptySquare)
                    {
                        currCol += diffCol;
                        currRow += diffRow;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Return if piece can move from current location
        /// </summary>
        internal static bool CanMoveDiag(ChessBoard Board, ChessPosition MyPosition, ChessPieceColor PieceColor)
        {
            int col = (int)MyPosition.ColLoc;
            int row = (int)MyPosition.RowLoc;

            if (col > 1 && row > 1)
            {
                if (CanMoveDiag(Board, MyPosition, new ChessPosition((ColPos)(col - 1), (RowPos)(row - 1)), PieceColor))
                    return true;
            }

            if (col > 1 && row < 8)
            {
                if (CanMoveDiag(Board, MyPosition, new ChessPosition((ColPos)(col - 1), (RowPos)(row + 1)), PieceColor))
                    return true;
            }

            if (col < 8 && row > 1)
            {
                if (CanMoveDiag(Board, MyPosition, new ChessPosition((ColPos)(col + 1), (RowPos)(row - 1)), PieceColor))
                    return true;
            }

            if (col < 8 && row < 8)
            {
                if (CanMoveDiag(Board, MyPosition, new ChessPosition((ColPos)(col + 1), (RowPos)(row + 1)), PieceColor))
                    return true;
            }

            return false;
        }
    }
}
