//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Text;
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal;

    /// <summary>
    /// Encapsulate chess logic associated the chess board
    /// </summary>
    public class ChessBoard
    {
        /// <summary>
        /// Length of string used to encode the state of the chess board.
        /// </summary>
        private const int C_BoardStateStringLength = 66;

        #region Constructors
        /// <summary>
        /// Create chess board with pieces in their starting positions
        /// </summary>
        public ChessBoard()
        {
            ResetBoard();
        }

        /// <summary>
        /// Create the board
        /// </summary>
        /// <param name="boardLayout">layout of the chess board</param>
        public ChessBoard(string boardLayout)
        {
            //Contract.Requires<ArgumentNullException>(boardLayout != null, "Can't be null");
            Contract.Assume(boardLayout.Length == C_BoardStateStringLength, "Invalid input string");

            // Set board state
            BoardState = boardLayout;

            // Reset Undo list
            undoList = new ChessMoveUndoRedoList(boardLayout);
        }
        
        public ChessBoard(ChessBoard board)
        {
            //Contract.Requires<ArgumentNullException>(board != null, "Can't be null");
            //Contract.Requires<ArgumentException>(board.BoardState.Length == C_BoardStateStringLength, "Invalid input string");

            // Set board state
            BoardState = board.BoardState;

            // Reset Undo list
            undoList = new ChessMoveUndoRedoList(board.BoardState);
        }

        /// <summary>
        /// Resets the chess board to its initial condition, so a new game can start
        /// </summary>
        public void ResetBoard()
        {
            const string initialBoard = "W_A1B1C1D1E1F1G1H1A2B2C2D2E2F2G2H2A7B7C7D7E7F7G7H7A8B8C8D8E8F8G8H8";

            BoardState = initialBoard;

            // Reset Undo list
            undoList = new ChessMoveUndoRedoList(initialBoard);
        }
        #endregion

        #region Board State
        /// <summary>
        /// Get the state of the chess board
        /// </summary>
        /// <Pattern>Memento - Capture and restore an object's internal state</Pattern>
        public string BoardState
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (CurrentPlayerColor == ChessPieceColor.Black)
                    sb.Append("B_");
                else
                    sb.Append("W_");

                foreach (ChessPieceBase piece in whitePowers)
                    sb.Append((piece.MyPosition.ColLoc).ToString() + ((int)piece.MyPosition.RowLoc).ToString());

                foreach (ChessPieceBase piece in whitePawns)
                    sb.Append((piece.MyPosition.ColLoc).ToString() + ((int)piece.MyPosition.RowLoc).ToString());

                foreach (ChessPieceBase piece in blackPawns)
                    sb.Append((piece.MyPosition.ColLoc).ToString() + ((int)piece.MyPosition.RowLoc).ToString());

                foreach (ChessPieceBase piece in blackPowers)
                    sb.Append((piece.MyPosition.ColLoc).ToString() + ((int)piece.MyPosition.RowLoc).ToString());

                return sb.ToString();
            }
            set
            {
                //Contract.Requires<ArgumentNullException>(value != null, "Can't be null");
                //Contract.Requires<ArgumentException>(value.Length == C_BoardStateStringLength, "Invalid input string");

                string colorString = value.Substring(0, 2);
                string layoutString = value.Substring(2);

                // Set initial player
                if (colorString.Equals("B_"))
                    CurrentPlayerColor = ChessPieceColor.Black;
                else if (colorString.Equals("W_"))
                    CurrentPlayerColor = ChessPieceColor.White;
                else
                    throw new ApplicationException("Input string is invalid.");

                theBoard = new ChessPieceBase[9, 9];
                enumChessBoard = new ChessPiece[9, 9];

                // Set white pieces
                whitePowers = new ChessPieceBase[8];
                SetChessPiece(Library.ParseColPos(layoutString[0]), Library.ParseRowPos(layoutString[1]), whitePowers[0] = new Rook(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[2]), Library.ParseRowPos(layoutString[3]), whitePowers[1] = new Knight(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[4]), Library.ParseRowPos(layoutString[5]), whitePowers[2] = new Bishop(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[6]), Library.ParseRowPos(layoutString[7]), whitePowers[3] = new Queen(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[8]), Library.ParseRowPos(layoutString[9]), whitePowers[4] = whiteKing = new King(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[10]), Library.ParseRowPos(layoutString[11]), whitePowers[5] = new Bishop(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[12]), Library.ParseRowPos(layoutString[13]), whitePowers[6] = new Knight(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[14]), Library.ParseRowPos(layoutString[15]), whitePowers[7] = new Rook(this, ChessPieceColor.White));

                // Set white pawns
                whitePawns = new ChessPieceBase[8];
                SetChessPiece(Library.ParseColPos(layoutString[16]), Library.ParseRowPos(layoutString[17]), whitePawns[0] = new PawnWhite(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[18]), Library.ParseRowPos(layoutString[19]), whitePawns[1] = new PawnWhite(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[20]), Library.ParseRowPos(layoutString[21]), whitePawns[2] = new PawnWhite(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[22]), Library.ParseRowPos(layoutString[23]), whitePawns[3] = new PawnWhite(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[24]), Library.ParseRowPos(layoutString[25]), whitePawns[4] = new PawnWhite(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[26]), Library.ParseRowPos(layoutString[27]), whitePawns[5] = new PawnWhite(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[28]), Library.ParseRowPos(layoutString[29]), whitePawns[6] = new PawnWhite(this, ChessPieceColor.White));
                SetChessPiece(Library.ParseColPos(layoutString[30]), Library.ParseRowPos(layoutString[31]), whitePawns[7] = new PawnWhite(this, ChessPieceColor.White));

                // Set black pawns
                blackPawns = new ChessPieceBase[8];
                SetChessPiece(Library.ParseColPos(layoutString[32]), Library.ParseRowPos(layoutString[33]), blackPawns[0] = new PawnBlack(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[34]), Library.ParseRowPos(layoutString[35]), blackPawns[1] = new PawnBlack(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[36]), Library.ParseRowPos(layoutString[37]), blackPawns[2] = new PawnBlack(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[38]), Library.ParseRowPos(layoutString[39]), blackPawns[3] = new PawnBlack(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[40]), Library.ParseRowPos(layoutString[41]), blackPawns[4] = new PawnBlack(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[42]), Library.ParseRowPos(layoutString[43]), blackPawns[5] = new PawnBlack(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[44]), Library.ParseRowPos(layoutString[45]), blackPawns[6] = new PawnBlack(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[46]), Library.ParseRowPos(layoutString[47]), blackPawns[7] = new PawnBlack(this, ChessPieceColor.Black));

                // Set black pieces
                blackPowers = new ChessPieceBase[8];
                SetChessPiece(Library.ParseColPos(layoutString[48]), Library.ParseRowPos(layoutString[49]), blackPowers[0] = new Rook(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[50]), Library.ParseRowPos(layoutString[51]), blackPowers[1] = new Knight(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[52]), Library.ParseRowPos(layoutString[53]), blackPowers[2] = new Bishop(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[54]), Library.ParseRowPos(layoutString[55]), blackPowers[3] = new Queen(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[56]), Library.ParseRowPos(layoutString[57]), blackPowers[4] = blackKing = new King(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[58]), Library.ParseRowPos(layoutString[59]), blackPowers[5] = new Bishop(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[60]), Library.ParseRowPos(layoutString[61]), blackPowers[6] = new Knight(this, ChessPieceColor.Black));
                SetChessPiece(Library.ParseColPos(layoutString[62]), Library.ParseRowPos(layoutString[63]), blackPowers[7] = new Rook(this, ChessPieceColor.Black));

            }
        }

        /// <summary>
        /// Locations of all chess pieces
        /// </summary>
        public ChessPosition[] GetChessPieceLocations()
        {
            ChessPosition[] positions = new ChessPosition[32];
            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                positions[index++] = blackPowers[i].MyPosition;
            }
            for (int i = 0; i < 8; i++)
            {
                positions[index++] = blackPawns[i].MyPosition;
            }
            for (int i = 0; i < 8; i++)
            {
                positions[index++] = whitePowers[i].MyPosition;
            }
            for (int i = 0; i < 8; i++)
            {
                positions[index++] = whitePawns[i].MyPosition;
            }

            return positions;
        }
        #endregion

        #region Move chess pieces
        /// <summary>
        /// Move specified chess piece without verifying if move is legal
        /// </summary>
        public string MoveFreeStyle(ChessPosition oldPosition, ChessPosition newPosition)
        {
            //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(oldPosition), "oldPosition contains valuse that are out of bounds.");
            //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(newPosition), "newPosition contains valuse that are out of bounds.");

            ChessPieceBase piece = theBoard[(int)oldPosition.ColLoc, (int)oldPosition.RowLoc];
            if (piece != null)
            {
                piece.MoveFreeStyle(newPosition);

                return this.BoardState;
            }
            else
            {
                throw new ArgumentException("There is no chess piece at oldPosition: " + oldPosition.ColLoc.ToString() + ", " + oldPosition.RowLoc.ToString());
            }
        }

        /// <summary>
        /// Move specified chess piece
        /// </summary>
        public ChessMove Move(ChessPosition oldPosition, ChessPosition newPosition)
        {
            //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(oldPosition), "oldPosition contains valuse that are out of bounds.");
            //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(newPosition), "newPosition contains valuse that are out of bounds.");

            ChessPieceBase piece = theBoard[(int)oldPosition.ColLoc, (int)oldPosition.RowLoc];
            if (piece != null)
            {
                ChessMove move = piece.Move(newPosition);

                undoList.AddMoveToUndoList(this.BoardState);

                return move;
            }
            else
            {
                throw new ArgumentException("There is no chess piece at oldPosition: " + oldPosition.ColLoc.ToString() + ", " + oldPosition.RowLoc.ToString());
            }
        }

        /// <summary>
        /// Return if specified chess move is legal
        /// </summary>
        public bool CanMove(ChessPosition oldPosition, ChessPosition newPosition)
        {
            if (ValidateBounds.IsInBounds(oldPosition) && ValidateBounds.IsInBounds(newPosition))
            {
                ChessPieceBase piece = theBoard[(int)oldPosition.ColLoc, (int)oldPosition.RowLoc];
                if (piece == null)
                {
                    // No pece to move
                    return false;
                }
                else if (piece.theChessPiece.PieceColor == CurrentPlayerColor)
                {
                    ChessPieceBase endPiece = theBoard[(int)newPosition.ColLoc, (int)newPosition.RowLoc];
                    if (endPiece != null && endPiece.theChessPiece.PieceColor == CurrentPlayerColor)
                    {
                        // Trying to capture your own piece
                        return false;
                    }
                    else
                    {
                        return piece.CanMove(newPosition);
                    }
                }
                else
                {
                    // Not player's turn
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return if piece can move from current position
        /// </summary>
        public bool CanMove(ChessPosition location)
        {
            if (ValidateBounds.IsInBounds(location))
            {
                ChessPieceBase piece = theBoard[(int)location.ColLoc, (int)location.RowLoc];
                if (piece == null)
                {
                    // No pece to move
                    return false;
                }
                else if (piece.theChessPiece.PieceColor == CurrentPlayerColor)
                {
                    return piece.CanMove();
                }
                else
                {
                    // Not player's turn
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Track chess pieces
        /// <summary>
        /// Get contents of chess board
        /// Returns chess piece if present, or null if empty
        /// </summary>
        public ChessPiece this[ColPos colPos, RowPos rowPos]
        {
            get
            {
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(colPos), "Column location is out of bounds.");
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(rowPos), "Row location is out of bounds.");

                return enumChessBoard[(int)colPos, (int)rowPos];
            }
            internal set
            {
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(colPos), "Column location is out of bounds.");
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds(rowPos), "Row location is out of bounds.");

                enumChessBoard[(int)colPos, (int)rowPos] = value;
            }
        }

        /// <summary>
        /// Get contents of chess board
        /// Returns chess piece if present, or null if empty
        /// </summary>
        public ChessPiece this[int colPos, int rowPos]
        {
            get
            {
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds((ColPos)colPos), "Column location is out of bounds.");
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds((RowPos)rowPos), "Row location is out of bounds.");

                return enumChessBoard[colPos, rowPos];
            }
            internal set
            {
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds((ColPos)colPos), "Column location is out of bounds.");
                //Contract.Requires<ApplicationException>(ValidateBounds.IsInBounds((RowPos)rowPos), "Row location is out of bounds.");

                enumChessBoard[colPos, rowPos] = value;
            }
        }
        private ChessPiece[,] enumChessBoard;

        /// <summary>
        /// Set a chess piece on the board
        /// </summary>
        internal void SetChessPiece(ColPos colPos, RowPos rowPos, ChessPieceBase piece)
        {
            //Contract.Requires<ArgumentException>(ValidateBounds.IsInBounds(colPos));
            //Contract.Requires<ArgumentException>(ValidateBounds.IsInBounds(rowPos));

            theBoard[(int)colPos, (int)rowPos] = piece;
            if (piece == null)
            {
                this[colPos, rowPos] = new ChessPiece();
            }
            else
            {
                piece.MyPosition = new ChessPosition(colPos, rowPos);
                this[colPos, rowPos] = new ChessPiece(piece.theChessPiece.PieceType, piece.theChessPiece.PieceColor);
            }
        }
        internal ChessPieceBase GetChessPiece(ColPos col, RowPos row)
        {
            return theBoard[(int)col, (int)row];
        }
        private ChessPieceBase[,] theBoard;

        /// <summary>
        /// Returns all the pieces on the chess board of the specified color
        /// </summary>
        /// <remarks>
        /// Just used as an example of an iterator. We would use a dedicated array for speed
        /// </remarks>
        internal IEnumerable<ChessPieceBase> ChessPieces(ChessPieceColor color)
        {
            for (int col = 1; col <= 8; col++)
            {
                for (int row = 1; row <= 8; row++)
                {
                    ChessPieceBase piece = theBoard[col, row];
                    if (piece != null && piece.theChessPiece.PieceColor == color)
                    {
                        yield return piece;
                    }
                }
            }
        }

        private ChessPieceBase[] whitePawns;
        private ChessPieceBase[] whitePowers;
        private ChessPieceBase[] blackPawns;
        private ChessPieceBase[] blackPowers;

        // Used to track if king is in check
        private King blackKing;
        private King whiteKing;
        #endregion

        /// <summary>
        /// Promote selected pawn
        /// </summary>
        public void PromotePawn(ChessPieceType chessPieceType, ChessPieceColor color, ColPos colPos, RowPos rowPos)
        {
            ChessPieceBase[] pieces;
            if (color == ChessPieceColor.Black)
            {
                pieces = blackPawns;
            }
            else
            {
                pieces = whitePawns;
            }

            // Update piece
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].MyPosition.ColLoc == colPos && pieces[i].MyPosition.RowLoc == rowPos)
                {
                    SetChessPiece(colPos, rowPos, pieces[i] = ChessPieceFactory.GetNewChessPiece(this, chessPieceType, color));

                    break;
                }
            }
        }

        /// <summary>
        /// Rrturns a list of all possible moves the current player can make
        /// </summary>
        public static List<ChessMove> PossibleChessMoves(ChessBoard chessBoard)
        {
            //Contract.Requires<ArgumentNullException>(chessBoard != null);

            List<ChessMove> moveList = new List<ChessMove>();

            foreach (ChessPieceBase piece in chessBoard.ChessPieces(chessBoard.CurrentPlayerColor))
            {
                List<ChessMove> pieceMoves = piece.PossibleMoveList();
                moveList.AddRange(pieceMoves);
            }

            return moveList;
        }

        /// <summary>
        /// Return if specified king is in check
        /// </summary>
        public bool IsKingInCheck(ChessPieceColor color)
        {
            if (color == ChessPieceColor.Black)
            {
                return blackKing.IsInCheck();
            }
            else
            {
                return whiteKing.IsInCheck();
            }
        }

        /// <summary>
        /// get the color of the player whose move it currently is.
        /// </summary>
        public ChessPieceColor CurrentPlayerColor { get; set; }

        #region Undo-Redo list
        internal ChessMoveUndoRedoList undoList;

        /// <summary>
        /// Return true if can undo current move
        /// </summary>
        public bool CanUndoMove()
        {
            return undoList.CanGetPreviousState();
        }

        /// <summary>
        /// Undo last chess move
        /// </summary>
        public void UndoMove()
        {
            BoardState = undoList.GetPreviousMove();
        }

        /// <summary>
        /// Return true if can redo current move
        /// </summary>
        public bool CanRedoMove()
        {
            return undoList.CanGetNextState();
        }

        /// <summary>
        /// Redo last chess move
        /// </summary>
        public void RedoMove()
        {
            BoardState = undoList.GetNextMove();
        }
        #endregion
    }
}
