//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic;

    /// <summary>
    /// Interaction logic for ChessBoard.xaml
    /// </summary>
    public partial class ChessBoardUi : ChessBoardControlBase
    {
        #region Initializing code
        public ChessBoardUi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event for when chess piece successfully moved
        /// </summary>
        public event ChessMoveHandler ChessPieceMoved;

        private void TheChessBoard_Loaded(object sender, RoutedEventArgs re)
        {
            PlayWithoutRules = Properties.Settings.Default.PlayWithoutRules;

            BoardOrigin = new Point(TheChessBoard.Width / 26, TheChessBoard.Height / 26);
            ChessSquareWidth = BoardOrigin.X * 3;
            ChessSquareHeight = BoardOrigin.Y * 3;

            BoardLogic = new ChessBoard();

            SetupPiecesOnBoard();

            // Hookup chess piece events
            foreach (ChessPieceUi piece in chessPieces)
            {
                piece.TheChessBoard = this;
                piece.ChessPieceMoved += new ChessPieceMoveHandler
                (
                    (chessPiece, e) =>
                    {
                        // Set status message
                        if (chessPiece.TheChessBoard.ChessPieceMoved != null)
                        {
                            ChessPieceMoved(this, e);
                        }
                    }
                );
            }

            #region Record row and column numbers for rotating board
            colAndRowNumbers = new TextBlock[32];
            colAndRowNumbers[0] = TopCol1;
            colAndRowNumbers[1] = TopCol2;
            colAndRowNumbers[2] = TopCol3;
            colAndRowNumbers[3] = TopCol4;
            colAndRowNumbers[4] = TopCol5;
            colAndRowNumbers[5] = TopCol6;
            colAndRowNumbers[6] = TopCol7;
            colAndRowNumbers[7] = TopCol8;

            colAndRowNumbers[8] = LeftRow1;
            colAndRowNumbers[9] = LeftRow2;
            colAndRowNumbers[10] = LeftRow3;
            colAndRowNumbers[11] = LeftRow4;
            colAndRowNumbers[12] = LeftRow5;
            colAndRowNumbers[13] = LeftRow6;
            colAndRowNumbers[14] = LeftRow7;
            colAndRowNumbers[15] = LeftRow8;

            colAndRowNumbers[16] = RightRow1;
            colAndRowNumbers[17] = RightRow2;
            colAndRowNumbers[18] = RightRow3;
            colAndRowNumbers[19] = RightRow4;
            colAndRowNumbers[20] = RightRow5;
            colAndRowNumbers[21] = RightRow6;
            colAndRowNumbers[22] = RightRow7;
            colAndRowNumbers[23] = RightRow8;

            colAndRowNumbers[24] = BottomCol1;
            colAndRowNumbers[25] = BottomCol2;
            colAndRowNumbers[26] = BottomCol3;
            colAndRowNumbers[27] = BottomCol4;
            colAndRowNumbers[28] = BottomCol5;
            colAndRowNumbers[29] = BottomCol6;
            colAndRowNumbers[30] = BottomCol7;
            colAndRowNumbers[31] = BottomCol8;
            #endregion

            initialTransform = RenderTransform;
            Rotate180(Properties.Settings.Default.WhiteChessPiecesOnTop);
        }
        #endregion

        /// <summary>
        /// Position new pieces on the chess board
        /// </summary>
        private void SetupPiecesOnBoard()
        {
            #region Record Chess pieces
            chessPieces = new ChessPieceUi[32];
            chessPieces[0] = Black_Rook1;
            chessPieces[1] = Black_Knight1;
            chessPieces[2] = Black_Bishop1;
            chessPieces[3] = Black_Queen;
            chessPieces[4] = Black_King;
            chessPieces[5] = Black_Bishop2;
            chessPieces[6] = Black_Knight2;
            chessPieces[7] = Black_Rook2;

            chessPieces[8] = Black_Pawn1;
            chessPieces[9] = Black_Pawn2;
            chessPieces[10] = Black_Pawn3;
            chessPieces[11] = Black_Pawn4;
            chessPieces[12] = Black_Pawn5;
            chessPieces[13] = Black_Pawn6;
            chessPieces[14] = Black_Pawn7;
            chessPieces[15] = Black_Pawn8;

            chessPieces[16] = White_Rook1;
            chessPieces[17] = White_Knight1;
            chessPieces[18] = White_Bishop1;
            chessPieces[19] = White_Queen;
            chessPieces[20] = White_King;
            chessPieces[21] = White_Bishop2;
            chessPieces[22] = White_Knight2;
            chessPieces[23] = White_Rook2;

            chessPieces[24] = White_Pawn1;
            chessPieces[25] = White_Pawn2;
            chessPieces[26] = White_Pawn3;
            chessPieces[27] = White_Pawn4;
            chessPieces[28] = White_Pawn5;
            chessPieces[29] = White_Pawn6;
            chessPieces[30] = White_Pawn7;
            chessPieces[31] = White_Pawn8;
            #endregion

            //#region Record Chess pieces
            //chessPieces = new ChessPieceUi[32];
            //chessPieces[0] = Black_Rook1;
            //chessPieces[1] = Black_Knight1;
            //chessPieces[2] = Black_Bishop1;
            //chessPieces[3] = Black_Queen;
            //chessPieces[4] = Black_King;
            //chessPieces[5] = Black_Bishop2;
            //chessPieces[6] = Black_Knight2;
            //chessPieces[7] = Black_Rook2;

            //chessPieces[8] = Black_Pawn1;
            //chessPieces[9] = Black_Pawn2;
            //chessPieces[10] = Black_Pawn3;
            //chessPieces[11] = Black_Pawn4;
            //chessPieces[12] = Black_Pawn5;
            //chessPieces[13] = Black_Pawn6;
            //chessPieces[14] = Black_Pawn7;
            //chessPieces[15] = Black_Pawn8;

            //chessPieces[16] = White_Rook1;
            //chessPieces[17] = White_Knight1;
            //chessPieces[18] = White_Bishop1;
            //chessPieces[19] = White_Queen;
            //chessPieces[20] = White_King;
            //chessPieces[21] = White_Bishop2;
            //chessPieces[22] = White_Knight2;
            //chessPieces[23] = White_Rook2;

            //chessPieces[24] = White_Pawn1;
            //chessPieces[25] = White_Pawn2;
            //chessPieces[26] = White_Pawn3;
            //chessPieces[27] = White_Pawn4;
            //chessPieces[28] = White_Pawn5;
            //chessPieces[29] = White_Pawn6;
            //chessPieces[30] = White_Pawn7;
            //chessPieces[31] = White_Pawn8;
            //#endregion
        }
    }
}
