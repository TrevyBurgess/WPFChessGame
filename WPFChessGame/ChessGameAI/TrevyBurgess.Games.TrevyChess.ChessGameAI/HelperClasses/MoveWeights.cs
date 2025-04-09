//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    public class MoveWeights
    {
        // Normal weights.
        public const int Queen = 900;	// 9
        public const int Rook = 500;	// 5
        public const int Bishop = 325;	// 3.25
        public const int Knight = 300;	// 3
        public const int Pawn = 100;	// 1

        // Special move weights.
        public const int KingMove = 1000;			// 10		(Only move weakest piece, therefore king is highest weight.)
        public const int KingCastled = 1000;
        public const int KingCheck = 100;			// 1		(The importance of putting the king in check whenever possible.)
        public const int KingCheckMate = 1000000;		// 10000	(Maximum possible weight for move that gives check mate.)
        public const int PawnToQueen = Queen - Pawn;	// 800		(Promoting to queen. Loose a pawn but gain a queen.)
        
        // Positional weights.
        public const int Col_A = 500;
        public const int Col_B = 600;
        public const int Col_C = 700;
        public const int Col_D = 800;
        public const int Col_E = 800;
        public const int Col_F = 700;
        public const int Col_G = 600;
        public const int Col_H = 500;

        public const int Row_1 = 100;
        public const int Row_2 = 200;
        public const int Row_3 = 300;
        public const int Row_4 = 400;
        public const int Row_5 = 400;
        public const int Row_6 = 300;
        public const int Row_7 = 200;
        public const int Row_8 = 100;
    }
}
