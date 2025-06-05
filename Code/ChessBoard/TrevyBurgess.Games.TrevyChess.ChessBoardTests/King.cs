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

    [TestClass]
    public class King
    {
        /// <summary>
        /// Test context
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

        [TestMethod()]
        [DataSource("Castle")]
        [DeploymentItem("Data\\King.accdb")]
        [Description("Tests all legal ways for castling to take place.")]
        public void Castle()
        {
            // Setup board
            string boardSetup = context.DataRow["Setup"] as string;
            ChessBoard board = new ChessBoard(boardSetup);

            // Move piece
            ColPos startColum = Parse.ColPos(context.DataRow["StartColum"]);
            RowPos startRow = Parse.RowPos(context.DataRow["StartRow"]);
            ColPos endColum = Parse.ColPos(context.DataRow["EndColum"]);
            RowPos endRow = Parse.RowPos(context.DataRow["EndRow"]);
            board.Move(new ChessPosition(startColum, startRow), new ChessPosition(endColum, endRow));

            // Validate
            Assert.AreEqual<string>(context.DataRow["Expected"] as string, board.BoardState);
        }

        [TestMethod()]
        [DataSource("LegalMoves")]
        [DeploymentItem("Data\\King.accdb")]
        [Description("Tests legal moves.")]
        public void LegalMoves()
        {
            // Setup board
            string boardSetup = context.DataRow["Setup"] as string;
            ChessBoard board = new ChessBoard(boardSetup);

            // Move piece
            ColPos startColum = Parse.ColPos(context.DataRow["StartColum"]);
            RowPos startRow = Parse.RowPos(context.DataRow["StartRow"]);
            ColPos endColum = Parse.ColPos(context.DataRow["EndColum"]);
            RowPos endRow = Parse.RowPos(context.DataRow["EndRow"]);
            board.Move(new ChessPosition(startColum, startRow), new ChessPosition(endColum, endRow));

            // Validate
            Assert.AreEqual<string>(context.DataRow["Expected"] as string, board.BoardState);
        }














    }
}
