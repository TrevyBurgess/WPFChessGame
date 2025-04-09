//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic.Internal
{
    using System;

    internal static class ChessPieceFactory
    {
        /// <summary>
        /// create a new chess piece based on piece color and type
        /// </summary>
        internal static ChessPieceBase GetNewChessPiece(ChessBoard board, ChessPieceType pieceType, ChessPieceColor color)
        {
            switch (pieceType)
            {
                case ChessPieceType.Bishop:
                    return new Bishop(board, color);

                case ChessPieceType.Knight:
                    return new Knight(board, color);

                case ChessPieceType.Queen:
                    return new Queen(board, color);

                case ChessPieceType.Rook:
                    return new Rook(board, color);

                case ChessPieceType.Pawn:
                    return new Rook(board, color);

                default:
                    throw new ApplicationException("Chess piece type: " + pieceType.ToString() + " is not allowed");
            }
        }
    }
}
