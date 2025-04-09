//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    using System.Diagnostics;

    /// <summary>
    /// Store position of chess pieces
    /// </summary>
    public struct ChessPosition : System.IEquatable<ChessPosition>
    {
        public ColPos ColLoc;
        public RowPos RowLoc;

        [DebuggerHidden]
        public ChessPosition(ColPos colLoc, RowPos rowLoc)
        {
            ColLoc = colLoc;
            RowLoc = rowLoc;
        }

        [DebuggerHidden]
        public bool Equals(ChessPosition other)
        {
            if (other.ColLoc == ColLoc && other.RowLoc == RowLoc)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
