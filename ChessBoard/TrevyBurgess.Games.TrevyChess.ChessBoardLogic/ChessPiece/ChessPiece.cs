//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    /// <summary>
    /// Represents a chess piece
    /// </summary>
    public struct ChessPiece
    {
        /// <summary>
        /// Piece type: Pawn, Rook, Knight, Bishop, King, Queen
        /// </summary>
        public ChessPieceType PieceType;

        /// <summary>
        /// Piece color: black, white
        /// </summary>
        public ChessPieceColor PieceColor;

        /// <summary>
        /// Return if piece is a power (Not a pwen)
        /// </summary>
        internal bool IsPower;

        /// <summary>
        /// New chess piece representation
        /// </summary>
        public ChessPiece(ChessPieceType pieceType, ChessPieceColor pieceColor)
        {
            PieceType = pieceType;
            PieceColor = pieceColor;

            IsPower = pieceType != ChessPieceType.Pawn;
        }
    }
}
