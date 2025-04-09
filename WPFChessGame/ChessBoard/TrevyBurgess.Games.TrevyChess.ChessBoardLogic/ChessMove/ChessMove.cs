//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    public class ChessMove
    {
        /// <summary>
        /// Old Rook position
        /// </summary>
        public ChessPosition OldRookPosition;

        /// <summary>
        /// New Rook position
        /// </summary>
        public ChessPosition NewRookPosition;

        /// <summary>
        /// Result of specific mobve
        /// </summary>
        public MoveMessage Result;
        
        /// <summary>
        /// Location of piece that was killed
        /// </summary>
        public ChessPosition PieceKilled;
        
        /// <summary>
        /// Specify if pawn can be promoted
        /// </summary>
        public bool PawnPromoted;
    }
}
