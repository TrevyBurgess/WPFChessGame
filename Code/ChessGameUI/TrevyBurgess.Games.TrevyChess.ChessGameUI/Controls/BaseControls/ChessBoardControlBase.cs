// 
// 
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic;

    public class ChessBoardControlBase : UserControl
    {
        #region Properties

        /// <summary>
        /// Chess board logic
        /// </summary>
        protected ChessBoard BoardLogic { get; set; }

        /// <summary>
        /// Get the board state
        /// </summary>
        public string BoardState { get { return BoardLogic.BoardState; } }

        /// <summary>
        /// Origin of chess board
        /// </summary>
        public Point BoardOrigin { get; protected set; }

        /// <summary>
        /// Width of chess board square
        /// </summary>
        public double ChessSquareWidth { get; protected set; }

        /// <summary>
        /// Height of chess board square
        /// </summary>
        public double ChessSquareHeight { get; protected set; }

        /// <summary>
        /// Get/set weather you want to play without rules
        /// </summary>
        public bool PlayWithoutRules;

        /// <summary>
        /// All chess pieces on board
        /// </summary>
        protected ChessPieceUi[] chessPieces;

        /// <summary>
        /// Used to rotate columns and row numbers
        /// </summary>
        protected TextBlock[] colAndRowNumbers;

        /// <summary>
        /// Initial position of Chess board
        /// </summary>
        protected Transform initialTransform;
        #endregion

        /// <summary>
        /// Return the chess board to its initial position
        /// </summary>
        public void ResetBoard()
        {
            BoardLogic = new ChessBoard();
            foreach (ChessPieceUi piece in chessPieces)
            {
                piece.ResetPiece();
            }
        }

        /// <summary>
        /// Return the chess board to its initial position
        /// </summary>
        public void ResetBoard(string boardLayout)
        {
            BoardLogic = new ChessBoard(boardLayout);
            ChessPosition[] locations = BoardLogic.GetChessPieceLocations();

            for (int i = 0; i < chessPieces.Length; i++)
            {
                chessPieces[i].ResetPiece(locations[i]);
            }
        }

        /// <summary>
        /// Return if we can undo current move
        /// </summary>
        public bool CanUndoMove()
        {
            return BoardLogic.CanUndoMove();
        }

        /// <summary>
        /// Undo move
        /// </summary>
        public void UndoMove()
        {
            BoardLogic.UndoMove();

            // Move pieces
            ChessPosition[] locations = BoardLogic.GetChessPieceLocations();
            for (int i = 0; i < chessPieces.Length; i++)
            {
                chessPieces[i].ResetPiece(locations[i]);
            }
        }

        /// <summary>
        /// Return if we can redo current move
        /// </summary>
        public bool CanRedoMove()
        {
            return BoardLogic.CanRedoMove();
        }

        /// <summary>
        /// Redo move
        /// </summary>
        public void RedoMove()
        {
            BoardLogic.RedoMove();

            // Move pieces
            ChessPosition[] locations = BoardLogic.GetChessPieceLocations();
            for (int i = 0; i < chessPieces.Length; i++)
            {
                chessPieces[i].ResetPiece(locations[i]);
            }

            BoardLogic.CanRedoMove();
        }

        /// <summary>
        /// Get or set the current player
        /// </summary>
        public ChessPieceColor CurrentPlayerColor
        {
            get { return BoardLogic.CurrentPlayerColor; }
            set { BoardLogic.CurrentPlayerColor = value; }
        }

        /// <summary>
        /// Return if piece can move from current position
        /// </summary>
        public bool CanMove(ChessPosition location)
        {
            return BoardLogic.CanMove(location);
        }

        /// <summary>
        /// Return if piece can move from current position
        /// </summary>
        public bool CanMove(ChessPosition oldPosition, ChessPosition newPosition)
        {
            return BoardLogic.CanMove(oldPosition, newPosition);
        }

        /// <summary>
        /// Move specified chess piece
        /// </summary>
        public ChessMove Move(ChessPosition oldPosition, ChessPosition newPosition)
        {
            return BoardLogic.Move(oldPosition, newPosition);
        }

        /// <summary>
        /// Move specified chess piece without verifying if move is legal
        /// </summary>
        public string MoveFreeStyle(ChessPosition oldPosition, ChessPosition newPosition)
        {
            return BoardLogic.MoveFreeStyle(oldPosition, newPosition);
        }

        /// <summary>
        /// Promote selected pawn
        /// </summary>
        public void PromotePawn(ChessPieceType chessPieceType, ChessPieceColor color, ColPos colPos, RowPos rowPos)
        {
            BoardLogic.PromotePawn(chessPieceType, color, colPos, rowPos);
        }

        /// <summary>
        /// Return column position of piece, given X position of mouse from origin of control
        /// </summary>
        public ColPos GetColumn(double xPosition)
        {
            if (xPosition < ChessSquareWidth * 0 + BoardOrigin.X)
            {
                return ColPos.Captured;
            }
            else if (xPosition < ChessSquareWidth * 1 + BoardOrigin.X)
            {
                return ColPos.A;
            }
            else if (xPosition < ChessSquareWidth * 2 + BoardOrigin.X)
            {
                return ColPos.B;
            }
            else if (xPosition < ChessSquareWidth * 3 + BoardOrigin.X)
            {
                return ColPos.C;
            }
            else if (xPosition < ChessSquareWidth * 4 + BoardOrigin.X)
            {
                return ColPos.D;
            }
            else if (xPosition < ChessSquareWidth * 5 + BoardOrigin.X)
            {
                return ColPos.E;
            }
            else if (xPosition < ChessSquareWidth * 6 + BoardOrigin.X)
            {
                return ColPos.F;
            }
            else if (xPosition < ChessSquareWidth * 7 + BoardOrigin.X)
            {
                return ColPos.G;
            }
            else if (xPosition < ChessSquareWidth * 8 + BoardOrigin.X)
            {
                return ColPos.H;
            }
            else
            {
                return ColPos.Captured;
            }
        }

        /// <summary>
        /// Return row position of piece, given Y position of mouse from origin of control
        /// </summary>
        public RowPos GetRow(double yPosition)
        {
            if (yPosition < BoardOrigin.Y)
            {
                return RowPos.Captured;
            }
            else if (yPosition < ChessSquareWidth * 1 + BoardOrigin.Y)
            {
                return RowPos.R8;
            }
            else if (yPosition < ChessSquareWidth * 2 + BoardOrigin.Y)
            {
                return RowPos.R7;
            }
            else if (yPosition < ChessSquareWidth * 3 + BoardOrigin.Y)
            {
                return RowPos.R6;
            }
            else if (yPosition < ChessSquareWidth * 4 + BoardOrigin.Y)
            {
                return RowPos.R5;
            }
            else if (yPosition < ChessSquareWidth * 5 + BoardOrigin.Y)
            {
                return RowPos.R4;
            }
            else if (yPosition < ChessSquareWidth * 6 + BoardOrigin.Y)
            {
                return RowPos.R3;
            }
            else if (yPosition < ChessSquareWidth * 7 + BoardOrigin.Y)
            {
                return RowPos.R2;
            }
            else if (yPosition < ChessSquareWidth * 8 + BoardOrigin.Y)
            {
                return RowPos.R1;
            }
            else
            {
                return RowPos.Captured;
            }
        }

        /// <summary>
        ///  
        /// </summary>
        public Point GetLocation(ColPos startCol, RowPos startRow, ColPos endCol, RowPos endRow)
        {
            int colDiff = (int)endCol - (int)startCol;
            int rowDiff = (int)startRow - (int)endRow;

            return new Point(ChessSquareWidth * colDiff, ChessSquareWidth * rowDiff);
        }

        /// <summary>
        /// Return column position of piece, given X position of mouse from origin of control
        /// </summary>
        public double GetCenteredX(double xPosition)
        {
            if (xPosition < BoardOrigin.X)
            {
                return -1;
            }
            else if (xPosition < ChessSquareWidth * 1 + BoardOrigin.X)
            {
                return ChessSquareWidth * 0 + BoardOrigin.X;
            }
            else if (xPosition < ChessSquareWidth * 2 + BoardOrigin.X)
            {
                return ChessSquareWidth * 1 + BoardOrigin.X;
            }
            else if (xPosition < ChessSquareWidth * 3 + BoardOrigin.X)
            {
                return ChessSquareWidth * 2 + BoardOrigin.X;
            }
            else if (xPosition < ChessSquareWidth * 4 + BoardOrigin.X)
            {
                return ChessSquareWidth * 3 + BoardOrigin.X;
            }
            else if (xPosition < ChessSquareWidth * 5 + BoardOrigin.X)
            {
                return ChessSquareWidth * 4 + BoardOrigin.X;
            }
            else if (xPosition < ChessSquareWidth * 6 + BoardOrigin.X)
            {
                return ChessSquareWidth * 5 + BoardOrigin.X;
            }
            else if (xPosition < ChessSquareWidth * 7 + BoardOrigin.X)
            {
                return ChessSquareWidth * 6 + BoardOrigin.X;
            }
            else if (xPosition < ChessSquareWidth * 8 + BoardOrigin.X)
            {
                return ChessSquareWidth * 7 + BoardOrigin.X;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Return row position of piece, given Y position of mouse from origin of control
        /// </summary>
        public double GetCenteredY(double yPosition)
        {
            if (yPosition < BoardOrigin.Y)
            {
                return -1;
            }
            else if (yPosition < ChessSquareWidth * 1 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 0 + BoardOrigin.Y;
            }
            else if (yPosition < ChessSquareWidth * 2 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 1 + BoardOrigin.Y;
            }
            else if (yPosition < ChessSquareWidth * 3 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 2 + BoardOrigin.Y;
            }
            else if (yPosition < ChessSquareWidth * 4 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 3 + BoardOrigin.Y;
            }
            else if (yPosition < ChessSquareWidth * 5 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 4 + BoardOrigin.Y;
            }
            else if (yPosition < ChessSquareWidth * 6 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 5 + BoardOrigin.Y;
            }
            else if (yPosition < ChessSquareWidth * 7 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 6 + BoardOrigin.Y;
            }
            else if (yPosition < ChessSquareWidth * 8 + BoardOrigin.Y)
            {
                return ChessSquareWidth * 7 + BoardOrigin.Y;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Return chess piece located in specified location
        /// </summary>
        public ChessPieceUi GetPiece(ColPos colPos, RowPos rowPos)
        {
            foreach (ChessPieceUi piece in chessPieces)
            {
                if (piece.PieceColumnPosition == colPos && piece.PieceRowPosition == rowPos)
                {
                    return piece;
                }
            }

            throw new ApplicationException("No chess piece found at location (" + colPos.ToString() + ", " + rowPos.ToString() + ")");
        }

        /// <summary>
        /// Rotate board 180 degrees
        /// </summary>
        public void Rotate180(bool turnUpSideDown)
        {
            // Rotate board
            if (turnUpSideDown)
            {
                TransformGroup boardGroup = new TransformGroup();
                boardGroup.Children.Add(new RotateTransform(180));
                TranslateTransform boardMove = new TranslateTransform(base.ActualWidth, base.ActualHeight);
                boardGroup.Children.Add(boardMove);
                base.RenderTransform = boardGroup;

                foreach (TextBlock rowAndColNo in colAndRowNumbers)
                {
                    TransformGroup numberGroup = new TransformGroup();
                    numberGroup.Children.Add(new RotateTransform(180));
                    TranslateTransform numberMove = new TranslateTransform(rowAndColNo.ActualWidth, rowAndColNo.ActualHeight);
                    numberGroup.Children.Add(numberMove);
                    rowAndColNo.RenderTransform = numberGroup;
                }
            }
            else
            {
                RenderTransform = MatrixTransform.Identity;

                foreach (TextBlock rowAndColNo in colAndRowNumbers)
                {
                    rowAndColNo.RenderTransform = MatrixTransform.Identity;
                }
            }

            // Rotate pieces
            foreach (ChessPieceUi piece in chessPieces)
            {
                piece.Rotate180(turnUpSideDown);
            }
        }
    }
}
