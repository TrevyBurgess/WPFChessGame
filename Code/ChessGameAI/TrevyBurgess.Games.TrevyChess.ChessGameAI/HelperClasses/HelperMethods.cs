//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameAI
{
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic;

    public static class HelperMethods
    {
        private static int PosWeight(ColPos Col, RowPos Row)
        {
            int weight = 0;
            switch (Col)
            {
                case ColPos.A:
                    weight = MoveWeights.Col_A;
                    break;

                case ColPos.B:
						  weight = MoveWeights.Col_B;
                    break;

                case ColPos.C:
						  weight = MoveWeights.Col_C;
                    break;

                case ColPos.D:
						  weight = MoveWeights.Col_D;
                    break;

                case ColPos.E:
						  weight = MoveWeights.Col_E;
                    break;

                case ColPos.F:
						  weight = MoveWeights.Col_F;
                    break;

                case ColPos.G:
						  weight = MoveWeights.Col_G;
                    break;

                case ColPos.H:
						  weight = MoveWeights.Col_H;
                    break;
            }

            switch (Row)
            {
                case RowPos.R1:
                    weight += MoveWeights.Row_1;
                    break;

                case RowPos.R2:
                    weight += MoveWeights.Row_2;
                    break;

                case RowPos.R3:
                    weight += MoveWeights.Row_3;
                    break;

                case RowPos.R4:
                    weight += MoveWeights.Row_4;
                    break;

                case RowPos.R5:
                    weight += MoveWeights.Row_5;
                    break;

                case RowPos.R6:
                    weight += MoveWeights.Row_6;
                    break;

                case RowPos.R7:
                    weight += MoveWeights.Row_7;
                    break;

                case RowPos.R8:
                    weight += MoveWeights.Row_8;
                    break;
            }

            return weight;
        }
    }
}
