//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic;

    /// <summary>
    /// The chess piece knows where it is on the board
    /// </summary>
    public partial class ChessPieceUi : ChessPieceControlBase
    {
        #region Properties
        /// <summary>
        /// Event for when chess piece successfully moved
        /// </summary>
        public event ChessPieceMoveHandler ChessPieceMoved;

        /// <summary>
        /// The Chess board the chess piece is located on
        /// </summary>
        public ChessBoardUi TheChessBoard;

        /// <summary>
        /// Get a serialized string representation of the chess board
        /// </summary>
        public string ChessBoardState { get; private set; }

        private ColPos gameStartColPos;
        private RowPos gameStartRowPos;
        #endregion

        #region Initialization code

        public ChessPieceUi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reset chess piece to its original state when game first started
        /// </summary>
        public void ResetPiece()
        {
            PieceColumnPosition = gameStartColPos;
            PieceRowPosition = gameStartRowPos;

            Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Reset piece to a specified location
        /// </summary>
        public void ResetPiece(ChessPosition location)
        {
            PieceColumnPosition = location.ColLoc;
            PieceRowPosition = location.RowLoc;

            Visibility = Visibility.Visible;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TheChessBoard == null)
                {
                    Grid theGrid = Parent as Grid;
                    TheChessBoard = theGrid.Parent as ChessBoardUi;
                }

                // Set initial position of chess piece
                Grid.SetColumn(this, (int)PieceColumnPosition);
                Grid.SetRow(this, (int)(9 - PieceRowPosition));

                //Record initial location of Piece
                gameStartColPos = PieceColumnPosition;
                gameStartRowPos = PieceRowPosition;

                initialTransform = RenderTransform;
            }
            catch
            {
                throw new ArgumentException("Chess piece should be child of the grid of the ChessBoardUi UserControl.");
            }
        }
        #endregion

        #region Dependency Properties (http://msdn.microsoft.com/en-us/magazine/cc794276.aspx)
        /// <summary>
        /// Piece Type: King, Queen, Knight, Bichop, Rook, Pawn
        /// </summary>
        public ChessPieceType PieceType
        {
            get { return (ChessPieceType)GetValue(PieceTypeProperty); }
            set { SetValue(PieceTypeProperty, value); }
        }
        public static readonly DependencyProperty PieceTypeProperty =
            DependencyProperty.Register("PieceType", typeof(ChessPieceType), typeof(ChessPieceUi));

        /// <summary>
        /// Piece color: Black, White
        /// </summary>
        public ChessPieceColor PieceColor
        {
            get { return (ChessPieceColor)GetValue(PieceColorProperty); }
            set { SetValue(PieceColorProperty, value); }
        }
        public static readonly DependencyProperty PieceColorProperty =
            DependencyProperty.Register("PieceColor", typeof(ChessPieceColor), typeof(ChessPieceUi));

        /// <summary>
        /// Image Source
        /// </summary>
        public ImageSource PieceImage
        {
            get { return (ImageSource)GetValue(PieceImageProperty); }
            set { SetValue(PieceImageProperty, value); }
        }
        public static readonly DependencyProperty PieceImageProperty =
            DependencyProperty.Register
            (
                "PieceImage",
                typeof(ImageSource),
                typeof(ChessPieceUi),
                new PropertyMetadata
                (
                    (obj, args) =>
                    {
                        ChessPieceUi chessPiece = obj as ChessPieceUi;
                        chessPiece.ThePieceImage.Source = args.NewValue as ImageSource;
                    }
                )
            );

        /// <summary>
        /// Image ColPos
        /// </summary>
        public ColPos PieceColumnPosition
        {
            get { return (ColPos)GetValue(PieceColumnPositionProperty); }
            set { SetValue(PieceColumnPositionProperty, value); }
        }
        public static readonly DependencyProperty PieceColumnPositionProperty =
            DependencyProperty.Register
            (
                "PieceColumnPosition",
                typeof(ColPos),
                typeof(ChessPieceUi),
                new PropertyMetadata
                (
                    (obj, args) =>
                    {
                        ChessPieceUi piece = obj as ChessPieceUi;
                        ColPos colPos = (ColPos)args.NewValue;

                        piece.RenderTransform = piece.initialTransform;
                        Grid.SetColumn(piece, (int)colPos);
                    }
                )
            );

        /// <summary>
        /// Image RowPos
        /// </summary>
        public RowPos PieceRowPosition
        {
            get { return (RowPos)GetValue(PieceRowPositionProperty); }
            set { SetValue(PieceRowPositionProperty, value); }
        }
        public static readonly DependencyProperty PieceRowPositionProperty =
            DependencyProperty.Register
            (
                "PieceRowPosition",
                typeof(RowPos),
                typeof(ChessPieceUi),
                new PropertyMetadata
                    (
                        (obj, args) =>
                        {
                            ChessPieceUi piece = obj as ChessPieceUi;
                            RowPos rowPos = (RowPos)args.NewValue;

                            piece.RenderTransform = piece.initialTransform;
                            Grid.SetRow(piece, (int)(9 - rowPos));
                        }
                    )
                );
        #endregion

        #region Change cursor to signal piece can be moved
        /// <summary>
        /// Show hand when user moves cursor over piece
        /// </summary>
        private void ThePieceImage_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TheChessBoard.PlayWithoutRules)
            {
                Cursor = Cursors.Hand;
            }
            else if (e.LeftButton == MouseButtonState.Released && TheChessBoard.CanMove(new ChessPosition(PieceColumnPosition, PieceRowPosition)))
            {
                Cursor = Cursors.Hand;
            }
        }

        /// <summary>
        /// Show when user moves cursor away from piece
        /// </summary>
        private void ThePieceImage_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
            RenderTransform = initialTransform;
        }

        private void ThePieceImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Cursor == Cursors.Hand)
            {
                isSelected = true;
                Canvas.SetZIndex(this, 100);
            }
        }
        #endregion

        #region Move chess piece on board
        private Transform initialTransform;

        private Point moveLocation;
        private Transform moveTransform;
        private bool isSelected;

        private void ThePieceImage_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentLocation = e.MouseDevice.GetPosition(TheChessBoard);

            if (isSelected && e.LeftButton == MouseButtonState.Pressed)
            {
                TransformGroup group = new TransformGroup();
                if (moveTransform != null)
                {
                    group.Children.Add(moveTransform);
                }

                TranslateTransform move = new TranslateTransform(
                        currentLocation.X - moveLocation.X, currentLocation.Y - moveLocation.Y);
                group.Children.Add(move);

                RenderTransform = group;
            }

            moveLocation = currentLocation;
            moveTransform = RenderTransform;
        }
        #endregion

        #region Game control
        private void ThePieceImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isSelected)
            {
                // Center piece on board
                Point currentLocation = e.MouseDevice.GetPosition(TheChessBoard);
                ColPos colPos = TheChessBoard.GetColumn(currentLocation.X);
                RowPos rowPos = TheChessBoard.GetRow(currentLocation.Y);

                if (TheChessBoard.PlayWithoutRules)
                {
                    if (colPos == ColPos.Captured || rowPos == RowPos.Captured)
                    {
                        // TODO
                    }
                    else
                    {
                        TheChessBoard.MoveFreeStyle(new ChessPosition(PieceColumnPosition, PieceRowPosition), new ChessPosition(colPos, rowPos));

                        // Move piece
                        PieceColumnPosition = colPos;
                        PieceRowPosition = rowPos;
                    }
                }
                else
                {
                    if (TheChessBoard.CanMove(new ChessPosition(PieceColumnPosition, PieceRowPosition), new ChessPosition(colPos, rowPos)))
                    {
                        ChessPieceColor pieceColor = TheChessBoard.CurrentPlayerColor;
                        ChessMove result = TheChessBoard.Move(new ChessPosition(PieceColumnPosition, PieceRowPosition), new ChessPosition(colPos, rowPos));

                        if (result.Result == MoveMessage.PieceCaptured)
                        {
                            // Capture piece
                            ChessPieceUi capturedPiece = TheChessBoard.GetPiece(result.PieceKilled.ColLoc, result.PieceKilled.RowLoc);
                            capturedPiece.Visibility = Visibility.Collapsed;
                        }
                        else if (result.Result == MoveMessage.CastlingSucceeded)
                        {
                            // Move castle
                            ChessPieceUi capturedPiece = TheChessBoard.GetPiece(result.OldRookPosition.ColLoc, result.OldRookPosition.RowLoc);
                            capturedPiece.PieceColumnPosition = result.NewRookPosition.ColLoc;
                            capturedPiece.PieceRowPosition = result.NewRookPosition.RowLoc;
                        }

                        // Move piece
                        PieceColumnPosition = colPos;
                        PieceRowPosition = rowPos;

                        // Pawn promotion
                        if (result.PawnPromoted)
                        {
                            PawnPromotionChooser chooser = new PawnPromotionChooser(pieceColor);
                            chooser.ShowDialog();

                            TheChessBoard.PromotePawn(chooser.PieceSelected, pieceColor, colPos, rowPos);

                            PieceImage = chooser.Source;
                        }

                        // Set status message
                        UpdateGameStatus();
                    }
                }
            }
            else
            {
                UpdateGameStatus();
            }

            RenderTransform = initialTransform;
            isSelected = false;
            Canvas.SetZIndex(this, 0);
        }

        private void UpdateGameStatus(string sillyMessage = "No Message")
        {
            if (ChessPieceMoved != null)
            {
                ChessPieceColor currentPlayer = TheChessBoard.CurrentPlayerColor;
                string statusMessage;
                if (currentPlayer == ChessPieceColor.Black)
                {
                    statusMessage = Properties.Resources.Status_PlayersTurn_Black;
                }
                else
                {
                    statusMessage = Properties.Resources.Status_PlayersTurn_White;
                }

                // Raise event
                ChessPieceMoved(this, new ChessMoveEventArgs(currentPlayer, statusMessage, sillyMessage, TheChessBoard.BoardState));
            }
        }
        #endregion

        internal void Rotate180(bool turnUpSideDown)
        {
            if (turnUpSideDown)
            {
                TransformGroup pieceGroup = new TransformGroup();
                pieceGroup.Children.Add(new RotateTransform(180));
                TranslateTransform pieceMove = new TranslateTransform(ActualWidth, ActualHeight);
                pieceGroup.Children.Add(pieceMove);
                RenderTransform = pieceGroup;
            }
            else
            {
                RenderTransform = MatrixTransform.Identity;
            }

            initialTransform = RenderTransform;
        }
    }
}