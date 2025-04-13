//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System.Collections.Generic;

    /// <summary>
    /// Impliments the basic functionality for a chess piece
    /// </summary>
    internal abstract class ChessPieceBase
    {
        /// <summary>
        /// Marks if the chess piece is in its initial position
        /// </summary>
        internal bool InitialPosition { get; set; }

        /// <summary>
        /// External representation of the chess piece
        /// </summary>
        internal ChessPiece theChessPiece { get; private set; }

        /// <summary>
        /// Chess piece color
        /// </summary>
        internal ChessPieceColor Color { get { return theChessPiece.PieceColor; } }

        /// <summary>
        /// Chess piece Type: Pawn, Rook, Knight, Bishop, King, Queen
        /// </summary>
        internal ChessPieceType PieceType { get { return theChessPiece.PieceType; } }

        /// <summary>
        /// Return if piece is a power (Not a pwen)
        /// </summary>
        internal bool IsPower { get { return theChessPiece.IsPower; } }

        /// <summary>
        /// Chess board chess piece resides on
        /// </summary>
        internal ChessBoard Board { get; private set; }

        /// <summary>
        /// Returns the current position of chess piece
        /// </summary>
        internal ChessPosition MyPosition { get; set; }

        internal ChessPieceBase(ChessBoard board, ChessPieceColor pieceColor, ChessPieceType pieceType)
        {
            InitialPosition = true;
            Board = board;

            theChessPiece = new ChessPiece(pieceType, pieceColor);
        }

        /// <summary>
        /// Perform specified move
        /// </summary>
        internal ChessMove Move(ChessPosition newPosition)
        {
            if (CanMove(newPosition))
            {
                // Initial position
                ChessPosition oldPosition = MyPosition;

                // Do necessary housekeeping
                ChessMove result = DoMoveHousekeeping(oldPosition, newPosition);

                // Check if we're killing a pawn En Passant
                ChessPieceBase endPiece = Board.GetChessPiece(newPosition.ColLoc, newPosition.RowLoc);
                if (endPiece == null)
                {
                    // Check if we're capturing a pawn En Passant
                    if (theChessPiece.PieceColor == ChessPieceColor.White && newPosition.RowLoc == RowPos.R6)
                    {
                        PawnBlack pawn = Board.GetChessPiece(newPosition.ColLoc, RowPos.R5) as PawnBlack;
                        if (pawn != null && pawn.MovedTwoSpaces && Board.undoList.MoveCount == pawn.NoOfMovesTime + 1)
                        {
                            result.Result = MoveMessage.PieceCaptured;
                            result.PieceKilled = new ChessPosition(newPosition.ColLoc, RowPos.R5);

                            // Capture the pawn
                            Board.SetChessPiece(newPosition.ColLoc, RowPos.R5, null);
                        }
                    }
                    else if (theChessPiece.PieceColor == ChessPieceColor.Black && newPosition.RowLoc == RowPos.R3)
                    {
                        PawnWhite pawn = Board.GetChessPiece(newPosition.ColLoc, RowPos.R4) as PawnWhite;
                        if (pawn != null && pawn.MovedTwoSpaces && Board.undoList.MoveCount == pawn.NoOfMovesTime + 1)
                        {
                            result.Result = MoveMessage.PieceCaptured;
                            result.PieceKilled = new ChessPosition(newPosition.ColLoc, RowPos.R4);

                            // Capture the pawn
                            Board.SetChessPiece(newPosition.ColLoc, RowPos.R4, null);
                        }
                    }
                }
                else
                {
                    result.Result = MoveMessage.PieceCaptured;
                    result.PieceKilled = newPosition;

                    #region Remove Later
                    //// Check if we're capturing a power
                    //if (endPiece.theChessPiece.IsPower)
                    //{
                    //    if (endPiece.theChessPiece.PieceColor == ChessPieceColor.Black)
                    //    {
                    //        Board.capturedBlackPowers.Add(endPiece);
                    //    }
                    //    else
                    //    {
                    //        Board.capturedWhitePowers.Add(endPiece);
                    //    }
                    //} 
                    #endregion
                }

                // Copy piece to destination
                Board.SetChessPiece(newPosition.ColLoc, newPosition.RowLoc, this);

                // Delete piece in source
                Board.SetChessPiece(oldPosition.ColLoc, oldPosition.RowLoc, null);

                // Switch players                    
                Board.CurrentPlayerColor = Board.CurrentPlayerColor == ChessPieceColor.Black ? ChessPieceColor.White : ChessPieceColor.Black;

                return result;
            }
            else
            {
                throw new IllegalMoveException("Piece can't be moved");
            }
        }

        /// <summary>
        /// Perform specified move, even if illegal
        /// </summary>
        internal void MoveFreeStyle(ChessPosition newPosition)
        {
            // Initial position
            ChessPosition oldPosition = MyPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        internal abstract List<ChessMove> PossibleMoveList();

        /// <summary>
        /// Do housekeeping after piece is moved. Return move weight
        /// </summary>
        internal abstract ChessMove DoMoveHousekeeping(ChessPosition oldPosition, ChessPosition newPosition);

        /// <summary>
        /// Return if a specified move is legal
        /// </summary>
        internal abstract bool CanMove(ChessPosition newPosition);

        /// <summary>
        /// Return if piece can move from current location
        /// </summary>
        internal abstract bool CanMove();
        #region Test Moves

        /// <summary>
        /// Check to see if piece can move horizontally or vertically. Does not test for check.
        /// </summary>
        protected bool CanMoveHorVert(ChessPosition newPosition)
        {
            // Piece does not move.
            if (MyPosition.ColLoc == newPosition.ColLoc && MyPosition.RowLoc == newPosition.RowLoc)
                return false;

            // End position is your own piece
            if (Board[newPosition.ColLoc, newPosition.RowLoc].PieceColor == theChessPiece.PieceColor)
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
        protected bool CanMoveHorVert()
        {
            int col = (int)MyPosition.ColLoc;
            int row = (int)MyPosition.RowLoc;

            if (col > 1)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col - 1), (RowPos)(row));
                if (CanMoveHorVert(newPosition))
                    return true;
            }

            if (col < 8)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col + 1), (RowPos)(row));
                if (CanMoveHorVert(newPosition))
                    return true;
            }

            if (row > 1)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col), (RowPos)(row - 1));
                if (CanMoveHorVert(newPosition))
                    return true;
            }

            if (row < 8)
            {
                ChessPosition newPosition = new ChessPosition((ColPos)(col), (RowPos)(row + 1));
                if (CanMoveHorVert(newPosition))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Check to see if piece can move diagonnally. Does not test for check.
        /// </summary>
        protected bool CanMoveDiag(ChessPosition newPosition)
        {
            // Piece does not move.
            if (MyPosition.ColLoc == newPosition.ColLoc && MyPosition.RowLoc == newPosition.RowLoc)
                return false;

            // End position is your own piece
            if (Board[newPosition.ColLoc, newPosition.RowLoc].PieceColor == this.theChessPiece.PieceColor)
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
        protected bool CanMoveDiag()
        {
            int col = (int)MyPosition.ColLoc;
            int row = (int)MyPosition.RowLoc;

            if (col > 1 && row > 1)
            {
                if (CanMoveDiag(new ChessPosition((ColPos)(col - 1), (RowPos)(row - 1))))
                    return true;
            }

            if (col > 1 && row < 8)
            {
                if (CanMoveDiag(new ChessPosition((ColPos)(col - 1), (RowPos)(row + 1))))
                    return true;
            }

            if (col < 8 && row > 1)
            {
                if (CanMoveDiag(new ChessPosition((ColPos)(col + 1), (RowPos)(row - 1))))
                    return true;
            }

            if (col < 8 && row < 8)
            {
                if (CanMoveDiag(new ChessPosition((ColPos)(col + 1), (RowPos)(row + 1))))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Return list of all possible moves piece can make
        /// </summary>
        protected List<ChessMove> MoveHorVertList()
        {
            List<ChessMove> moves = new List<ChessMove>();

            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iEndCol;
            int iStartRow = (int)MyPosition.RowLoc;
            int iEndRow;

            // To the left
            iEndCol = iStartCol - 1;
            iEndRow = (int)MyPosition.RowLoc;
            while (iEndCol > 0 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = MyPosition.RowLoc;

                moves.Add(move);
                iEndCol--;
            }

            // To the right
            iEndCol = iStartCol + 1;
            iEndRow = (int)MyPosition.RowLoc;
            while (iEndCol < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = MyPosition.RowLoc;

                moves.Add(move);
                iEndCol++;
            }

            // Upwards
            iEndCol = (int)MyPosition.ColLoc;
            iEndRow = iStartRow + 1;
            while (iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = MyPosition.ColLoc;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
                iEndRow++;
            }

            // Down and to right
            iEndCol = (int)MyPosition.ColLoc;
            iEndRow = iStartRow + 1;
            while (iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = MyPosition.ColLoc;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
                iEndRow++;
            }

            return moves;
        }

        /// <summary>
        /// Return list of all possible moves piece can make
        /// </summary>
        protected List<ChessMove> MoveDiagList()
        {
            List<ChessMove> moves = new List<ChessMove>();

            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iEndCol;
            int iStartRow = (int)MyPosition.RowLoc;
            int iEndRow;

            // Down and to left
            iEndCol = iStartCol - 1;
            iEndRow = iStartRow - 1;
            while (iEndCol > 0 && iEndRow > 0 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
                iEndCol--;
                iEndRow--;
            }

            // Down and to right
            iEndCol = iStartCol + 1;
            iEndRow = iStartRow - 1;
            while (iEndCol < 9 && iEndRow > 0 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
                iEndCol++;
                iEndRow--;
            }

            // Up and to left
            iEndCol = iStartCol - 1;
            iEndRow = iStartRow + 1;
            while (iEndCol > 0 && iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
                iEndCol--;
                iEndRow++;
            }

            // Down and to right
            iEndCol = iStartCol + 1;
            iEndRow = iStartRow + 1;
            while (iEndCol < 9 && iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
                iEndCol++;
                iEndRow++;
            }

            return moves;
        }
        #endregion
    }
}
