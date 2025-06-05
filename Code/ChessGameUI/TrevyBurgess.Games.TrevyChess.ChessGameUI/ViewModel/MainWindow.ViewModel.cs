//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI
{
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Data source for the main window view
    /// </summary>
    public class TrevyChessViewModel : ViewModelBase
    {
        public string TrevyChessTitle { get { return Properties.Resources.TrevyChessTitle; } }
        public ImageSource TrevyChessIcon { get { return HelperMethods.GetImageSource(Properties.Resources.TrevyChess); } }

        #region Add Label names
        // File Menu
        public string Menu_File { get { return Properties.Resources.Menu_File; } }
        public string Menu_File_New { get { return Properties.Resources.Menu_File_New; } }
        public Image Menu_File_New_Icon { get { return HelperMethods.GetImage(Properties.Resources.New_16x16, 16); } }
        public string Menu_File_Print { get { return Properties.Resources.Menu_File_Print; } }
        public Image Menu_File_Print_Icon { get { return HelperMethods.GetImage(Properties.Resources.Printer_48x48, 16); } }
        public ImageSource Menu_File_Print_LargeImage { get { return HelperMethods.GetImageSource(Properties.Resources.Printer_48x48); } }
        public ImageSource Menu_File_Print_SmallImage { get { return HelperMethods.GetImageSource(Properties.Resources.Printer_16x16); } }
        public string Menu_File_Exit { get { return Properties.Resources.Menu_File_Exit; } }
        public Image Menu_File_Exit_Icon { get { return HelperMethods.GetImage(Properties.Resources.Printer_48x48, 16); } }
        // View menu
        public string Menu_View { get { return Properties.Resources.Menu_View; } }
        public string Menu_View_ToolBar { get { return Properties.Resources.Menu_View_ToolBar; } }
        public string Menu_View_StatusBar { get { return Properties.Resources.Menu_View_StatusBar; } }
        public string Menu_View_ShowSillyMessages { get { return Properties.Resources.Menu_View_ShowSillyMessages; } }
        public string Menu_View_RotateBoard { get { return Properties.Resources.Menu_View_RotateBoard; } }
        // Chess menu
        public string Menu_Chess { get { return Properties.Resources.Menu_Chess; } }
        public string Menu_Chess_PlayAgainstComputer { get { return Properties.Resources.Menu_Chess_PlayAgainstComputer; } }
        public string Menu_Chess_Difficulty { get { return Properties.Resources.Menu_Chess_Difficulty; } }
        public string Menu_Chess_Difficulty_1 { get { return Properties.Resources.Menu_Chess_Difficulty_1; } }
        public string Menu_Chess_Difficulty_2 { get { return Properties.Resources.Menu_Chess_Difficulty_2; } }
        public string Menu_Chess_Difficulty_3 { get { return Properties.Resources.Menu_Chess_Difficulty_3; } }
        public string Menu_Chess_Difficulty_4 { get { return Properties.Resources.Menu_Chess_Difficulty_4; } }
        public string Menu_Chess_Difficulty_5 { get { return Properties.Resources.Menu_Chess_Difficulty_5; } }
        public string Menu_Chess_PlayerColor { get { return Properties.Resources.Menu_Chess_PlayerColor; } }
        public string Menu_Chess_PlayerColor_Black { get { return Properties.Resources.Menu_Chess_PlayerColor_Black; } }
        public string Menu_Chess_PlayerColor_White { get { return Properties.Resources.Menu_Chess_PlayerColor_White; } }
        // Tools ment
        public string Menu_Tools { get { return Properties.Resources.Menu_Tools; } }
        public string Menu_Tools_PlayWithoutRules { get { return Properties.Resources.Menu_Tools_PlayWithoutRules; } }
        public string Menu_Tools_ShowChessCodes { get { return Properties.Resources.Menu_Tools_ShowChessCodes; } }
        // help menu
        public string Menu_Help { get { return Properties.Resources.Menu_Help; } }
        public string Menu_Help_HelpTopics { get { return Properties.Resources.Menu_Help_HelpTopics; } }
        public string Menu_Help_About { get { return Properties.Resources.Menu_Help_About; } }
        // Toolbar
        public ImageSource Toolbar_UndoMoveImage { get { return HelperMethods.GetImageSource(Properties.Resources.UndoMoveImage); } }
        public ImageSource Toolbar_RedoMoveImage { get { return HelperMethods.GetImageSource(Properties.Resources.RedoMoveImage); } }
        public string Toolbar_RotateBoard { get { return Properties.Resources.Toolbar_RotateBoard; } }
        public string Toolbar_PlayAgainstComputer { get { return Properties.Resources.Toolbar_PlayAgainstComputer; } }

        // Set difficulty
        public string Toolbar_Difficulty_1 { get { return Properties.Resources.Toolbar_Difficulty_1; } }
        public SolidColorBrush Toolbar_Difficulty_Background_1 { get { return new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_1_Color.ParseColors()); } }
        public string Toolbar_Difficulty_2 { get { return Properties.Resources.Toolbar_Difficulty_2; } }
        public SolidColorBrush Toolbar_Difficulty_Background_2 { get { return new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_2_Color.ParseColors()); } }
        public string Toolbar_Difficulty_3 { get { return Properties.Resources.Toolbar_Difficulty_3; } }
        public SolidColorBrush Toolbar_Difficulty_Background_3 { get { return new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_3_Color.ParseColors()); } }
        public string Toolbar_Difficulty_4 { get { return Properties.Resources.Toolbar_Difficulty_4; } }
        public SolidColorBrush Toolbar_Difficulty_Background_4 { get { return new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_4_Color.ParseColors()); } }
        public string Toolbar_Difficulty_5 { get { return Properties.Resources.Toolbar_Difficulty_5; } }
        public SolidColorBrush Toolbar_Difficulty_Background_5 { get { return new SolidColorBrush(Properties.Resources.Toolbar_Difficulty_5_Color.ParseColors()); } }
        #endregion
    }
}
