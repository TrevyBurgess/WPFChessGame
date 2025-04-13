//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI
{
    using System;
    using System.Windows.Media;

    public partial class MainWindow
    {
        #region Properties
        /// <summary>
        /// Play against computer if true
        /// </summary>
        public bool PlayAgainstComputer { get; private set; }

        /// <summary>
        /// Orientation of the chess board
        /// </summary>
        public bool WhiteOnTop { get; private set; }

        /// <summary>
        /// Get the difficulty level when playing against computer
        /// </summary>
        public int Difficulty { get; private set; }

        /// <summary>
        /// Allow player to play without standard game rules
        /// </summary>
        public bool PlayWithoutRules { get; private set; }

        /// <summary>
        /// Show chess code describing board layout
        /// </summary>
        public bool ChessCodes { get; private set; }
        #endregion

        private void PlayWithoutChessRules(bool playWithoutRules)
        {
            if (playWithoutRules)
            {
                SetPlayAgainstComputer(false);
                Menu_Chess.Visibility = System.Windows.Visibility.Collapsed;
                Toolbar_PlayAgainstComputer.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                Menu_Chess.Visibility = System.Windows.Visibility.Visible;
                Toolbar_PlayAgainstComputer.Visibility = System.Windows.Visibility.Visible;
            }

            PlayWithoutRules = playWithoutRules;
            ChessBoard1.PlayWithoutRules = playWithoutRules;
            Properties.Settings.Default.PlayWithoutRules = playWithoutRules;
            Properties.Settings.Default.Save();
        }

        private void ShowChessCodes(bool showChessCodes)
        {
            if (showChessCodes)
            {
                ChessCodePanel.Visibility = System.Windows.Visibility.Visible;
                Menu_Tools_ShowChessBoardCode.IsChecked = true;
            }
            else
            {
                ChessCodePanel.Visibility = System.Windows.Visibility.Collapsed;
                Menu_Tools_ShowChessBoardCode.IsChecked = false;
            }

            Properties.Settings.Default.ShowChessCodes = showChessCodes;
            Properties.Settings.Default.Save();
        }

        private void SetDifficulty(int difficulty)
        {
            Difficulty = difficulty;
            Properties.Settings.Default.Difficulty = difficulty;
            Properties.Settings.Default.Save();

            // Set difficulty
            switch (difficulty)
            {
                case 1:
                    Toolbar_Difficulty.SelectedIndex = 0;
                    Toolbar_Difficulty.Background = new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_1_Color.ParseColors());

                    Menu_Chess_Difficulty_2.IsChecked = false;
                    Toolbar_Difficulty_2.IsSelected = false;

                    Menu_Chess_Difficulty_3.IsChecked = false;
                    Toolbar_Difficulty_3.IsSelected = false;

                    Menu_Chess_Difficulty_4.IsChecked = false;
                    Toolbar_Difficulty_4.IsSelected = false;

                    Menu_Chess_Difficulty_5.IsChecked = false;
                    Toolbar_Difficulty_5.IsSelected = false;

                    Menu_Chess_Difficulty_1.IsChecked = true;
                    Toolbar_Difficulty_1.IsSelected = true;
                    break;

                case 2:
                    Toolbar_Difficulty.SelectedIndex = 1;
                    Toolbar_Difficulty.Background = new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_2_Color.ParseColors());

                    Menu_Chess_Difficulty_1.IsChecked = false;
                    Toolbar_Difficulty_1.IsSelected = false;

                    Menu_Chess_Difficulty_3.IsChecked = false;
                    Toolbar_Difficulty_3.IsSelected = false;

                    Menu_Chess_Difficulty_4.IsChecked = false;
                    Toolbar_Difficulty_4.IsSelected = false;

                    Menu_Chess_Difficulty_5.IsChecked = false;
                    Toolbar_Difficulty_5.IsSelected = false;

                    Menu_Chess_Difficulty_2.IsChecked = true;
                    Toolbar_Difficulty_2.IsSelected = true;
                    break;

                case 3:
                    Toolbar_Difficulty.SelectedIndex = 2;
                    Toolbar_Difficulty.Background = new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_3_Color.ParseColors());

                    Menu_Chess_Difficulty_1.IsChecked = false;
                    Toolbar_Difficulty_1.IsSelected = false;

                    Menu_Chess_Difficulty_2.IsChecked = false;
                    Toolbar_Difficulty_2.IsSelected = false;

                    Menu_Chess_Difficulty_4.IsChecked = false;
                    Toolbar_Difficulty_4.IsSelected = false;

                    Menu_Chess_Difficulty_5.IsChecked = false;
                    Toolbar_Difficulty_5.IsSelected = false;

                    Menu_Chess_Difficulty_3.IsChecked = true;
                    Toolbar_Difficulty_3.IsSelected = true;
                    break;

                case 4:
                    Toolbar_Difficulty.SelectedIndex = 3;
                    Toolbar_Difficulty.Background = new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_4_Color.ParseColors());

                    Menu_Chess_Difficulty_1.IsChecked = false;
                    Toolbar_Difficulty_1.IsSelected = false;

                    Menu_Chess_Difficulty_2.IsChecked = false;
                    Toolbar_Difficulty_2.IsSelected = false;

                    Menu_Chess_Difficulty_3.IsChecked = false;
                    Toolbar_Difficulty_3.IsSelected = false;

                    Menu_Chess_Difficulty_5.IsChecked = false;
                    Toolbar_Difficulty_5.IsSelected = false;

                    Menu_Chess_Difficulty_4.IsChecked = true;
                    Toolbar_Difficulty_4.IsSelected = true;
                    break;

                case 5:
                    Toolbar_Difficulty.SelectedIndex = 4;
                    Toolbar_Difficulty.Background = new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_5_Color.ParseColors());

                    Menu_Chess_Difficulty_1.IsChecked = false;
                    Toolbar_Difficulty_1.IsSelected = false;

                    Menu_Chess_Difficulty_2.IsChecked = false;
                    Toolbar_Difficulty_2.IsSelected = false;

                    Menu_Chess_Difficulty_3.IsChecked = false;
                    Toolbar_Difficulty_3.IsSelected = false;

                    Menu_Chess_Difficulty_4.IsChecked = false;
                    Toolbar_Difficulty_4.IsSelected = false;

                    Menu_Chess_Difficulty_5.IsChecked = true;
                    Toolbar_Difficulty_5.IsSelected = true;
                    break;

                default:
                    throw new ArgumentException("Difficulty level " + Properties.Settings.Default.Difficulty + " specified in settings isn't supported");
            }
        }

        private void SetPlayAgainstComputer(bool? playAgainsComputer)
        {
            if (playAgainsComputer == true)
            {
                Toolbar_UserColor.Visibility = System.Windows.Visibility.Visible;
                Toolbar_Difficulty.Visibility = System.Windows.Visibility.Visible;
                Menu_Chess_Difficulty.Visibility = System.Windows.Visibility.Visible;
                Menu_Chess_PlayerColor.Visibility = System.Windows.Visibility.Visible;

                Properties.Settings.Default.PlayAgainstComputer = true;
                Properties.Settings.Default.Save();

                // Play against computer
                Menu_Chess_PlayAgainstComputer.IsChecked = true;
                Toolbar_PlayAgainstComputer.IsChecked = true;
                Menu_View_ShowSillyMessages.Visibility = System.Windows.Visibility.Visible;
                if (Properties.Settings.Default.ShowSillyMessges)
                {
                    SillyMessagesContainer.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    SillyMessagesContainer.Visibility = System.Windows.Visibility.Collapsed;
                }
                PlayAgainstComputer = true;


                Menu_Tools_PlayWithoutRules.IsChecked = false;
                Properties.Settings.Default.PlayWithoutRules = false;
            }
            else
            {
                Toolbar_UserColor.Visibility = System.Windows.Visibility.Collapsed;
                Toolbar_Difficulty.Visibility = System.Windows.Visibility.Collapsed;
                Menu_Chess_Difficulty.Visibility = System.Windows.Visibility.Collapsed;
                Menu_Chess_PlayerColor.Visibility = System.Windows.Visibility.Collapsed;

                Properties.Settings.Default.PlayAgainstComputer = false;
                Properties.Settings.Default.Save();

                // Play against computer
                Menu_Chess_PlayAgainstComputer.IsChecked = false;
                Menu_View_ShowSillyMessages.Visibility = System.Windows.Visibility.Collapsed;
                Toolbar_PlayAgainstComputer.IsChecked = false;
                SillyMessagesContainer.Visibility = System.Windows.Visibility.Collapsed;

                PlayAgainstComputer = false;
            }

            Properties.Settings.Default.Save();
        }

        private void RotateBoard()
        {
            WhiteOnTop = WhiteOnTop ? false : true;
            if (WhiteOnTop)
            {
                ChessBoard1.Rotate180(true);

                Properties.Settings.Default.WhiteChessPiecesOnTop = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                ChessBoard1.Rotate180(false);

                Properties.Settings.Default.WhiteChessPiecesOnTop = false;
                Properties.Settings.Default.Save();
            }
        }

        private void SetPlayersColor(bool playerIsWhite)
        {
            if (playerIsWhite)
            {
                Properties.Settings.Default.PlayerIsWhite = true;
                Properties.Settings.Default.Save();

                Menu_Chess_PlayerColor_Black.IsChecked = false;
                Menu_Chess_PlayerColor_White.IsChecked = true;
                Toolbar_UserColor.Content = Properties.Resources.Status_PlayersColor_White;
                Toolbar_UserColor.Background = new SolidColorBrush(Colors.White);
                Toolbar_UserColor.Foreground = new SolidColorBrush(Colors.Black);

                StatusMessages.Text = Properties.Resources.Status_PlayersTurn_White;

                ChessBoard1.CurrentPlayerColor = ChessBoardLogic.ChessPieceColor.White;
            }
            else
            {
                Properties.Settings.Default.PlayerIsWhite = false;
                Properties.Settings.Default.Save();

                Menu_Chess_PlayerColor_Black.IsChecked = true;
                Menu_Chess_PlayerColor_White.IsChecked = false;
                Toolbar_UserColor.Content = Properties.Resources.Status_PlayersColor_Black;
                Toolbar_UserColor.Background = new SolidColorBrush(Colors.Black);
                Toolbar_UserColor.Foreground = new SolidColorBrush(Colors.White);

                StatusMessages.Text = Properties.Resources.Status_PlayersTurn_Black;

                ChessBoard1.CurrentPlayerColor = ChessBoardLogic.ChessPieceColor.Black;
            }
        }
    }
}
