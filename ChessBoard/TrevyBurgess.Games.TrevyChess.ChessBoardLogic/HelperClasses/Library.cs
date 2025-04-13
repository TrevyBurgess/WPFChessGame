//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    using System;
    using System.Diagnostics;

    public static class Library
    {
        /// <summary>
        /// Parse ColPos from character
        /// </summary>
        [DebuggerHidden]
        public static ColPos ParseColPos(char colPos)
        {
            return (ColPos)Enum.Parse(typeof(ColPos), colPos.ToString());
        }

        /// <summary>
        /// Parse RowPos from character
        /// </summary>
        [DebuggerHidden]
        public static RowPos ParseRowPos(char colPos)
        {
            return (RowPos)Enum.Parse(typeof(RowPos), colPos.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pieceType"></param>
        /// <param name="pieceColor"></param>
        /// <returns></returns>
        public static char GetPieceCode(ChessPieceType pieceType, ChessPieceColor pieceColor)
        {
            if (pieceColor == ChessPieceColor.Black)
            {

                switch (pieceType)
                {
                    case ChessPieceType.Bishop:
                        return 'b';

                    case ChessPieceType.EmptySquare:
                        return ' ';

                    case ChessPieceType.King:
                        return 'k';

                    case ChessPieceType.Knight:
                        return 'n';

                    case ChessPieceType.Pawn:
                        return 'p';

                    case ChessPieceType.Queen:
                        return 'q';

                    case ChessPieceType.Rook:
                        return 'r';

                    default:
                        throw new ApplicationException("Invalid piece type.");
                }
            }
            else if (pieceColor == ChessPieceColor.White)
            {
                switch (pieceType)
                {
                    case ChessPieceType.Bishop:
                        return 'B';

                    case ChessPieceType.EmptySquare:
                        return ' ';

                    case ChessPieceType.King:
                        return 'K';

                    case ChessPieceType.Knight:
                        return 'N';

                    case ChessPieceType.Pawn:
                        return 'P';

                    case ChessPieceType.Queen:
                        return 'Q';

                    case ChessPieceType.Rook:
                        return 'R';

                    default:
                        throw new ApplicationException("Invalid piece type.");
                }
            }
            else
            {
                throw new ApplicationException("Invalid piece color");
            }
        }

        public static ChessPieceType GetPieceType(char pieceCode)
        {
            switch (pieceCode)
            {
                case 'b':
                case 'B':
                    return ChessPieceType.Bishop;

                case ' ':
                    return ChessPieceType.EmptySquare; ;

                case 'k':
                case 'K':
                    return ChessPieceType.King;

                case 'n':
                case 'N':
                    return ChessPieceType.Knight;

                case 'p':
                case 'P':
                    return ChessPieceType.Pawn;

                case 'q':
                case 'Q':
                    return ChessPieceType.Queen;

                case 'r':
                case 'R':
                    return ChessPieceType.Rook;

                default:
                    throw new ApplicationException("Invalid piece code.");
            }
        }
    }
}
