//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    using System;

    public static class Parse
    {
        public static ChessPieceColor ChessPieceColor(object color)
        {
            return (ChessPieceColor)Enum.Parse(typeof(ChessPieceColor), color as string);
        }

        public static ChessPieceType ChessPieceType(object pieceType)
        {
            return (ChessPieceType)Enum.Parse(typeof(ChessPieceType), pieceType as string);
        }

        public static ColPos ColPos(object colPos)
        {
            return (ColPos)Enum.Parse(typeof(ColPos), colPos as string);
        }

        public static RowPos RowPos(object rowPos)
        {
            return (RowPos)Enum.Parse(typeof(RowPos), rowPos as string);
        }
    }
}
