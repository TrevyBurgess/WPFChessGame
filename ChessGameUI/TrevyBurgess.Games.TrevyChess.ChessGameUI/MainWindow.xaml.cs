//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Initialization code
        /// <summary>
        /// Initialize main window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TrevyChessViewModel();
        }

        private void MainWindow1_Activated(object sender, EventArgs e)
        {
            if (ChessCode.Text.Trim() != ChessBoard1.BoardState)
            {
                // Initial settings
                Menu_View_ToolBar.IsChecked = Properties.Settings.Default.ToolbarVisible;
                Menu_View_StatusBar.IsChecked = Properties.Settings.Default.StatusBarVisible;

                SetDifficulty(Properties.Settings.Default.Difficulty);

                // Status
                ChessBoard1.ChessPieceMoved += new ChessMoveHandler(ChessPieceMoved_EventHandler);
                StatusMessages.Width = ChessBoard1.ActualWidth;

                // Player color
                SetPlayersColor(Properties.Settings.Default.PlayerIsWhite);
                WhiteOnTop = Properties.Settings.Default.WhiteChessPiecesOnTop;

                // Play against computer
                Menu_View_ShowSillyMessages.IsChecked = Properties.Settings.Default.ShowSillyMessges;
                Menu_Chess_PlayAgainstComputer.IsChecked = Properties.Settings.Default.PlayAgainstComputer;
                SetPlayAgainstComputer(Properties.Settings.Default.PlayAgainstComputer);

                // Allow player to move pieces without regard to chess rules
                Menu_Tools_PlayWithoutRules.IsChecked = Properties.Settings.Default.PlayWithoutRules;

                PlayWithoutChessRules(Properties.Settings.Default.PlayWithoutRules);

                ShowChessCodes(Properties.Settings.Default.ShowChessCodes);

                ChessCode.Text = ChessBoard1.BoardState;
            }
        }
        #endregion

        #region File Commands
        private void Menu_File_New_Click(object sender, RoutedEventArgs e)
        {
            ChessBoard1.ResetBoard();

            Toolbar_UndoMove.IsEnabled = false;
            Toolbar_RedoMove.IsEnabled = false;
        }

        private void Menu_File_Print_Click(object sender, RoutedEventArgs e)
        {
            var Printdlg = new PrintDialog();
            bool? res = Printdlg.ShowDialog();
            if (res == true)
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth - 5, Printdlg.PrintableAreaHeight - 5);
                ChessBoard1.Measure(pageSize);
                Printdlg.PrintVisual(ChessBoard1, Title);
            }
        }

        private void Menu_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region View Commands
        private void Menu_View_ToolBar_Checked(object sender, RoutedEventArgs e)
        {
            StandardToolbar.Visibility = Visibility.Visible;
            Properties.Settings.Default.ToolbarVisible = true;
            Properties.Settings.Default.Save();
        }
        private void Menu_View_ToolBar_Unchecked(object sender, RoutedEventArgs e)
        {
            StandardToolbar.Visibility = Visibility.Collapsed;
            Properties.Settings.Default.ToolbarVisible = false;
            Properties.Settings.Default.Save();
        }

        private void Menu_View_StatusBar_Checked(object sender, RoutedEventArgs e)
        {
            GameStatus.Visibility = Visibility.Visible;
            Properties.Settings.Default.StatusBarVisible = true;
            Properties.Settings.Default.Save();
        }
        private void Menu_View_StatusBar_Unchecked(object sender, RoutedEventArgs e)
        {
            GameStatus.Visibility = Visibility.Collapsed;
            Properties.Settings.Default.StatusBarVisible = false;
            Properties.Settings.Default.Save();
        }

        private void Menu_View_ShowSillyMessages_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowSillyMessges = true;
            Properties.Settings.Default.Save();

            SillyMessagesContainer.Visibility = Visibility.Visible;
        }
        private void Menu_View_ShowSillyMessages_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ShowSillyMessges = false;
            Properties.Settings.Default.Save();

            SillyMessagesContainer.Visibility = Visibility.Collapsed;
        }

        private void Menu_View_RotateBoard_Click(object sender, RoutedEventArgs e)
        {
            RotateBoard();
        }
        #endregion

        #region Chess commands
        private void Menu_Chess_PlayAgainstComputer_Checked(object sender, RoutedEventArgs e)
        {
            SetPlayAgainstComputer(true);
        }

        private void Menu_Chess_PlayAgainstComputer_Unchecked(object sender, RoutedEventArgs e)
        {
            SetPlayAgainstComputer(false);
        }

        private void Menu_Chess_Difficulty_Select(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            int level = int.Parse(element.Tag as string);

            if (level != Difficulty)
            {
                SetDifficulty(level);
                e.Handled = true;
            }
        }

        private void Menu_Chess_PlayerColor_Black_Click(object sender, RoutedEventArgs e)
        {
            SetPlayersColor(false);
        }

        private void Menu_Chess_PlayerColor_White_Click(object sender, RoutedEventArgs e)
        {
            SetPlayersColor(true);
        }
        #endregion

        #region Help commands
        private void Menu_Help_HelpTopics_Click(object sender, RoutedEventArgs e)
        {
            HelpPage helpWindow = new HelpPage();
            helpWindow.ShowDialog();
        }

        private void Menu_Help_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.Help_DialogBoxMessage, Properties.Resources.TrevyChessTitle);
        }
        #endregion

        #region Toolbar
        private void Toolbar_RotateBoard_Click(object sender, RoutedEventArgs e)
        {
            RotateBoard();
        }

        private void Toolbar_PlayAgainstComputer_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            SetPlayAgainstComputer(checkBox.IsChecked);
        }

        private void Toolbar_UserColor_Click(object sender, RoutedEventArgs e)
        {
            bool playerIsWhite = Properties.Settings.Default.PlayerIsWhite;
            if (playerIsWhite)
            {
                SetPlayersColor(false);
            }
            else
            {
                SetPlayersColor(true);
            }
        }
        #endregion

        private void Menu_Tools_PlayWithoutRules_Click(object sender, RoutedEventArgs e)
        {
            PlayWithoutChessRules(PlayWithoutRules ? false : true);
        }

        private void ChessPieceMoved_EventHandler(ChessBoardUi chessBoard, ChessMoveEventArgs e)
        {
            StatusMessages.Text = e.StatusMessage;
            SillyMessages.Text = e.SillyMessage;
            ChessCode.Text = e.ChessCode;

            Toolbar_UndoMove.IsEnabled = true;
            Toolbar_RedoMove.IsEnabled = false;
        }

        private void Menu_Tools_ShowChessBoardCode_Click(object sender, RoutedEventArgs e)
        {
            ShowChessCodes(Menu_Tools_ShowChessBoardCode.IsChecked);
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            string chessCode = ChessCode.Text.Trim();

            if (chessCode != ChessBoard1.BoardState)
            {
                ChessBoard1.ResetBoard(chessCode);

                bool playerIsWhite = Properties.Settings.Default.PlayerIsWhite;
                if (playerIsWhite)
                {
                    SetPlayersColor(false);
                }
                else
                {
                    SetPlayersColor(true);
                }
            }
        }

        private void ChessCode_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChessCode.SelectAll();
        }

        private void Toolbar_UndoMove_Click(object sender, RoutedEventArgs e)
        {
            ChessBoard1.UndoMove();

            Toolbar_RedoMove.IsEnabled = true;

            if (!ChessBoard1.CanUndoMove())
                Toolbar_UndoMove.IsEnabled = false;

            SetStatus();
        }

        private void Toolbar_RedoMove_Click(object sender, RoutedEventArgs e)
        {
            ChessBoard1.RedoMove();

            Toolbar_UndoMove.IsEnabled = true;

            if (!ChessBoard1.CanRedoMove())
                Toolbar_RedoMove.IsEnabled = false;

            SetStatus();
        }

        /// <summary>
        /// Set status message for who's turn it is and
        /// the 
        /// </summary>
        private void SetStatus()
        {
            if (ChessBoard1.CurrentPlayerColor == ChessBoardLogic.ChessPieceColor.White)
            {
                StatusMessages.Text = Properties.Resources.Status_PlayersTurn_White;
            }
            else
            {
                StatusMessages.Text = Properties.Resources.Status_PlayersTurn_Black;
            }

            ChessCode.Text = ChessBoard1.BoardState;
        }

        private void Toolbar_Difficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
