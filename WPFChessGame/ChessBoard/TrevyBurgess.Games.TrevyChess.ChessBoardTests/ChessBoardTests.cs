//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TrevyBurgess.Games.TrevyChess.ChessBoardLogic;

    /// <summary>
    /// Summary description for ChessBoardTests
    /// </summary>
    [TestClass]
    public class ChessBoardTests
    {
        public ChessBoardTests() { }

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }
        private TestContext context;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [DataSource("NewChessBoard"), DeploymentItem("Data\\ChessBoard.accdb")]
        [Description("New chess board")]
        public void NewChessBoard()
        {
            ChessBoard board = new ChessBoard();

            Assert.AreEqual<ChessPieceColor>(ChessPieceColor.White, board.CurrentPlayerColor);
            Assert.AreEqual<string>(context.DataRow["Expected"] as string, board.BoardState);
        }

        [TestMethod]
        [DataSource("SetupChessBoard"), DeploymentItem("Data\\ChessBoard.accdb")]
        [Description("Set up board to position you want")]
        public void SetupChessBoard()
        {
            string boardSetup = context.DataRow["Setup"] as string;
            ChessBoard board = new ChessBoard(boardSetup);

            ChessPieceColor pieceColor = (ChessPieceColor)Enum.Parse(typeof(ChessPieceColor), context.DataRow["Player"] as string);
            Assert.AreEqual<ChessPieceColor>(pieceColor, board.CurrentPlayerColor);
            Assert.AreEqual<string>(boardSetup, board.BoardState);
        }

        [TestMethod]
        [DataSource("SetupChessBoard"), DeploymentItem("Data\\ChessBoard.accdb")]
        [Description("Set up using existing board"), Priority(2)]
        public void SetupUsingExistingChessBoard()
        {
            string boardSetup = context.DataRow["Setup"] as string;
            ChessBoard initialBoard = new ChessBoard(boardSetup);

            ChessBoard newBoard = new ChessBoard(initialBoard);

            ChessPieceColor pieceColor = (ChessPieceColor)Enum.Parse(typeof(ChessPieceColor), context.DataRow["Player"] as string);
            Assert.AreEqual<ChessPieceColor>(pieceColor, newBoard.CurrentPlayerColor);
            Assert.AreEqual<string>(boardSetup, newBoard.BoardState);
        }

        [TestMethod]
        [DataSource("ResetChessBoard"), DeploymentItem("Data\\ChessBoard.accdb")]
        [Description("Reset chess board to initial position")]
        public void ResetChessBoard()
        {
            // set board to some arbitary state
            string boardSetup = context.DataRow["Setup"] as string;
            ChessBoard board = new ChessBoard(boardSetup);

            // Reset board
            board.ResetBoard();

            ChessPieceColor pieceColor = (ChessPieceColor)Enum.Parse(typeof(ChessPieceColor), context.DataRow["Player"] as string);
            Assert.AreEqual<ChessPieceColor>(pieceColor, board.CurrentPlayerColor);
            Assert.AreEqual<string>(context.DataRow["Expected"] as string, board.BoardState);
        }

        [TestMethod]
        [DataSource("BoardState"), DeploymentItem("Data\\ChessBoard.accdb")]
        [Description("Verify board state changes to reflect input values")]
        public void BoardState()
        {
            ChessBoard board = new ChessBoard();

            board.BoardState = context.DataRow["Setup"] as string;

            ChessPieceColor pieceColor = (ChessPieceColor)Enum.Parse(typeof(ChessPieceColor), context.DataRow["Player"] as string);
            Assert.AreEqual<ChessPieceColor>(pieceColor, board.CurrentPlayerColor);
            Assert.AreEqual<string>(context.DataRow["Expected"] as string, board.BoardState);
        }
    }
}
