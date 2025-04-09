//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Encapsulate King behavior
    /// </summary>
    internal class King : ChessPieceBase
    {
        internal King(ChessBoard board, ChessPieceColor Color) : base(board, Color, ChessPieceType.King) { }

        /// <summary>
        /// Check to see if king can move one space in any direction. Does not test for check.
        /// </summary>
        internal override bool CanMove(ChessPosition newPosition)
        {
            Contract.Assume(ValidateBounds.IsInBounds(newPosition.RowLoc));
            Contract.Assume(ValidateBounds.IsInBounds(newPosition.ColLoc));

            // End position is your own piece
            if (Board[newPosition.ColLoc, newPosition.RowLoc].PieceColor == base.theChessPiece.PieceColor)
                return false;

            int colMove = System.Math.Abs((int)MyPosition.ColLoc - (int)newPosition.ColLoc);
            int rowMove = System.Math.Abs((int)MyPosition.RowLoc - (int)newPosition.RowLoc);

            if ((colMove == 1 && rowMove == 1) || CanCastle(newPosition))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Return if piece can move from current location
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
            List<ChessMove> moves = new List<ChessMove>();

            // Input values.
            int iStartCol = (int)MyPosition.ColLoc;
            int iEndCol;
            int iStartRow = (int)MyPosition.RowLoc;
            int iEndRow;

            // To the left
            iEndCol = iStartCol - 1;
            iEndRow = (int)MyPosition.RowLoc;
            if (iEndCol > 0 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = MyPosition.RowLoc;

                moves.Add(move);
            }

            // To the right
            iEndCol = iStartCol + 1;
            iEndRow = (int)MyPosition.RowLoc;
            if (iEndCol < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = MyPosition.RowLoc;

                moves.Add(move);
            }

            // Upwards
            iEndCol = (int)MyPosition.ColLoc;
            iEndRow = iStartRow + 1;
            if (iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = MyPosition.ColLoc;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
            }

            // Down and to right
            iEndCol = (int)MyPosition.ColLoc;
            iEndRow = iStartRow + 1;
            if (iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = MyPosition.ColLoc;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
            }

            // Down and to left
            iEndCol = iStartCol - 1;
            iEndRow = iStartRow - 1;
            if (iEndCol > 0 && iEndRow > 0 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
            }

            // Down and to right
            iEndCol = iStartCol + 1;
            iEndRow = iStartRow - 1;
            if (iEndCol < 9 && iEndRow > 0 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
            }

            // Up and to left
            iEndCol = iStartCol - 1;
            iEndRow = iStartRow + 1;
            if (iEndCol > 0 && iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
            }

            // Down and to right
            iEndCol = iStartCol + 1;
            iEndRow = iStartRow + 1;
            if (iEndCol < 9 && iEndRow < 9 && Board[iEndCol, iEndRow].PieceType == ChessPieceType.EmptySquare)
            {
                ChessMove move = new ChessMove();
                move.OldRookPosition.ColLoc = MyPosition.ColLoc;
                move.OldRookPosition.RowLoc = MyPosition.RowLoc;
                move.NewRookPosition.ColLoc = (ColPos)iEndCol;
                move.NewRookPosition.RowLoc = (RowPos)iEndRow;

                moves.Add(move);
            }

            return moves;
        }

        /// <summary>
        /// Do housekeeping after piece is moved. Return move weight
        /// </summary>
        internal override ChessMove DoMoveHousekeeping(ChessPosition oldPosition, ChessPosition newPosition)
        {
            ChessMove result = new ChessMove();

            if (CanCastle(newPosition))
            {
                if (Board.CurrentPlayerColor == ChessPieceColor.Black)
                {
                    if (newPosition.ColLoc == ColPos.C)
                    {
                        ChessPieceBase castle = Board.GetChessPiece(ColPos.A, RowPos.R8);
                        castle.InitialPosition = false;

                        // Deal with Rook
                        Board.SetChessPiece(ColPos.D, RowPos.R8, castle);
                        result.NewRookPosition = new ChessPosition(ColPos.D, RowPos.R8);

                        Board.SetChessPiece(ColPos.A, RowPos.R8, null);
                        result.OldRookPosition = new ChessPosition(ColPos.A, RowPos.R8);
                    }
                    else
                    {
                        ChessPieceBase castle = Board.GetChessPiece(ColPos.H, RowPos.R8);
                        castle.InitialPosition = false;

                        // Deal with Rook
                        Board.SetChessPiece(ColPos.F, RowPos.R8, castle);
                        result.NewRookPosition = new ChessPosition(ColPos.F, RowPos.R8);

                        Board.SetChessPiece(ColPos.H, RowPos.R8, null);
                        result.OldRookPosition = new ChessPosition(ColPos.H, RowPos.R8);
                    }
                }
                else
                {
                    if (newPosition.ColLoc == ColPos.C)
                    {
                        ChessPieceBase castle = Board.GetChessPiece(ColPos.A, RowPos.R1);
                        castle.InitialPosition = false;

                        // Deal with Rook
                        Board.SetChessPiece(ColPos.D, RowPos.R1, castle);
                        result.NewRookPosition = new ChessPosition(ColPos.D, RowPos.R1);

                        Board.SetChessPiece(ColPos.A, RowPos.R1, null);
                        result.OldRookPosition = new ChessPosition(ColPos.A, RowPos.R1);
                    }
                    else
                    {
                        ChessPieceBase castle = Board.GetChessPiece(ColPos.H, RowPos.R1);
                        castle.InitialPosition = false;

                        // Deal with Rook
                        Board.SetChessPiece(ColPos.F, RowPos.R1, castle);
                        result.NewRookPosition = new ChessPosition(ColPos.F, RowPos.R1);

                        Board.SetChessPiece(ColPos.H, RowPos.R1, null);
                        result.OldRookPosition = new ChessPosition(ColPos.H, RowPos.R1);
                    }
                }

                result.Result = MoveMessage.CastlingSucceeded;
            }
            else
            {
                result.Result = MoveMessage.MoveSucceeded;
            }

            InitialPosition = false;

            return result;
        }

        /// <summary>
        /// Returns if King can move to specified castling position.
        /// </summary>
        private bool CanCastle(ChessPosition newPosition)
        {
            // King is in its initial position
            if (InitialPosition)
            {
                if (theChessPiece.PieceColor == ChessPieceColor.Black)
                {
                    // Black King moves left
                    if (newPosition.ColLoc == ColPos.C && newPosition.RowLoc == RowPos.R8)
                    {
                        // Left Black Castle hasn't moved
                        ChessPieceBase rook = Board.GetChessPiece(ColPos.A, RowPos.R8);
                        if (rook != null && rook.InitialPosition)
                        {
                            if (Board.GetChessPiece(ColPos.B, RowPos.R8) == null &&
                                Board.GetChessPiece(ColPos.C, RowPos.R8) == null &&
                                Board.GetChessPiece(ColPos.D, RowPos.R8) == null)
                            {
                                // Spaces between are empty
                                return true;
                            }
                            else
                            {
                                // Pieces between king and rook
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    // Black King moves right
                    else if (newPosition.ColLoc == ColPos.G && newPosition.RowLoc == RowPos.R8)
                    {
                        // Right Blcak Castle hasn't moved
                        ChessPieceBase rook = Board.GetChessPiece(ColPos.H, RowPos.R8);
                        if (rook != null && rook.InitialPosition)
                        {
                            if (Board.GetChessPiece(ColPos.F, RowPos.R8) == null &&
                                Board.GetChessPiece(ColPos.G, RowPos.R8) == null)
                            {
                                // Spaces between are empty
                                return true;
                            }
                            else
                            {
                                // Pieces between king and rook
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
                else
                {
                    // Black King moves left
                    if (newPosition.ColLoc == ColPos.C && newPosition.RowLoc == RowPos.R1)
                    {
                        // Left White Castle hasn't moved
                        ChessPieceBase rook = Board.GetChessPiece(ColPos.A, RowPos.R1);
                        if (rook != null && rook.InitialPosition)
                        {
                            if (Board.GetChessPiece(ColPos.B, RowPos.R1) == null &&
                                Board.GetChessPiece(ColPos.C, RowPos.R1) == null &&
                                Board.GetChessPiece(ColPos.D, RowPos.R1) == null)
                            {
                                // Spaces between are empty
                                return true;
                            }
                            else
                            {
                                // Pieces between king and rook
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    // Black King moves right
                    else if (newPosition.ColLoc == ColPos.G && newPosition.RowLoc == RowPos.R1)
                    {
                        // Right White Castle hasn't moved
                        ChessPieceBase rook = Board.GetChessPiece(ColPos.H, RowPos.R1);
                        if (rook != null && rook.InitialPosition)
                        {
                            if (Board.GetChessPiece(ColPos.F, RowPos.R1) == null &&
                                Board.GetChessPiece(ColPos.G, RowPos.R1) == null)
                            {
                                // Spaces between are empty
                                return true;
                            }
                            else
                            {
                                // Pieces between king and rook
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
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Find if moving the king to the specified position will place the king in check
        /// </summary>
        internal bool IsInCheck(ChessPosition kingsPosition)
        {
            ChessPieceColor opponentColor = theChessPiece.PieceColor == ChessPieceColor.Black ? ChessPieceColor.White : ChessPieceColor.Black;

            foreach (ChessPieceBase piece in Board.ChessPieces(opponentColor))
            {
                if (piece.CanMove(kingsPosition))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Find if king is currently in check
        /// </summary>
        internal bool IsInCheck()
        {
            return IsInCheck(MyPosition);
        }
    }
}
