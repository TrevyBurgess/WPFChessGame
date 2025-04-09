//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI
{
    using System;
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic;

    /// <summary>
    /// Event arguments to be passed into the drag event.
    /// </summary>
    public class ChessMoveEventArgs : EventArgs
    {
        public ChessMoveEventArgs(ChessPieceColor playersTurn, string statusMessage, string sillyMessage, string chessCode)
        {
            PlayersTurn = playersTurn;
            SillyMessage = sillyMessage;
            StatusMessage = statusMessage;
            ChessCode = chessCode;
        }

        /// <summary>
        /// Current player's turn
        /// </summary>
        public ChessPieceColor PlayersTurn { get; private set; }

        /// <summary>
        /// Silly messages
        /// </summary>
        public string StatusMessage { get; private set; }

        /// <summary>
        /// Silly messages
        /// </summary>
        public string SillyMessage { get; private set; }

        /// <summary>
        /// Serialized chess board
        /// </summary>
        public string ChessCode { get; private set; }
    }
}
