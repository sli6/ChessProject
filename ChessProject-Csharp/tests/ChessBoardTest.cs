using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class ChessBoardTest
	{
		private ChessBoard chessBoard;

        [TestInitialize]
		public void SetUp()
		{
			chessBoard = new ChessBoard();
		}

        [TestMethod]
		public void Has_MaxBoardWidth_of_8()
        {          
			Assert.AreEqual(8, ChessBoard.MaxBoardWidth);
		}

        [TestMethod]
		public void Has_MaxBoardHeight_of_8()
		{
			Assert.AreEqual(8, ChessBoard.MaxBoardHeight); 
		}


        [TestMethod]
        public void ValidateIfInsideChessBoard_Valid_X_equals_0_Y_equals_0()
        {
            chessBoard.ValidateIfInsideChessBoard(new Coordinate(0, 0));
        }

        [TestMethod]
        public void ValidateIfInsideChessBoard_Valid_X_equals_5_Y_equals_5()
        {
            chessBoard.ValidateIfInsideChessBoard(new Coordinate(5, 5));
        }

        [TestMethod]
        public void ValidateIfInsideChessBoard_Valid_X_equals_11_Y_equals_5()
        {
            try
            {
                chessBoard.ValidateIfInsideChessBoard(new Coordinate(11, 5)); ;
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (11, 5) is not inside the chessboard.", e.Message);
            }
        }


        [TestMethod]
        public void ValidateIfInsideChessBoard_Invalid_X_equals_0_Y_equals_9()
        {
            try
            {
                chessBoard.ValidateIfInsideChessBoard(new Coordinate(0, 9));
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (0, 9) is not inside the chessboard.", e.Message);
            }
        }

        [TestMethod]
        public void ValidateIfInsideChessBoard_Invalid_X_equals_11_Y_equals_0()
        {
            try
            {
                chessBoard.ValidateIfInsideChessBoard(new Coordinate(11, 0));
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (11, 0) is not inside the chessboard.", e.Message);
            }
        }

        [TestMethod]
        public void ValidateIfInsideChessBoard_Invalid_For_Negative_X_Values()
        {
            try
            {
                chessBoard.ValidateIfInsideChessBoard(new Coordinate(-1, 5));
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (-1, 5) is not inside the chessboard.", e.Message);
            }
        }

        [TestMethod]
        public void ValidateIfInsideChessBoard_Invalid_For_Negative_Y_Values()
        {
            try
            {
                chessBoard.ValidateIfInsideChessBoard(new Coordinate(5, -1));
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (5, -1) is not inside the chessboard.", e.Message);
            }
        }

        [TestMethod]
		public void Add_Piece_Valid_Positioning()
		{
            var firstPawn = new Mock<IPiece>();
            firstPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            firstPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var secondPawn = new Mock<IPiece>();
            secondPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            secondPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var coordinate1 = new Coordinate(6, 3);
            var coordinate2 = new Coordinate(5, 3);

            chessBoard.Add(firstPawn.Object, coordinate1);
            chessBoard.Add(secondPawn.Object, coordinate2);
        }

        public void Add_Piece_Invalid_Positioning_Based_On_Piece_Type()
        {

        }
        
        [TestMethod]
        public void Add_Piece_Avoids_Duplicate_Positioning()
        {
            var firstPawn = new Mock<IPiece>();
            firstPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            firstPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var secondPawn = new Mock<IPiece>();
            secondPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            secondPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var coordinate = new Coordinate(6, 3);

            chessBoard.Add(firstPawn.Object, coordinate);
            try
            {
                chessBoard.Add(secondPawn.Object, coordinate);
            }
            catch (DuplicatePositioningException e)
            {
                Assert.AreEqual("Coordinate (6, 3) of the chess board has been positioned.", e.Message);
            }
        }

        [TestMethod]
		public void Add_Piece_Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
			{
                var pawn = new Mock<IPiece>();
                pawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
                pawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

                int row = i / ChessBoard.MaxBoardWidth;
                var coordinate = new Coordinate(i % ChessBoard.MaxBoardWidth, 6 + row);
                pawn.Setup(obj => obj.Coordinate).Returns(coordinate);

                if (row < 1)
                {
                    chessBoard.Add(pawn.Object, coordinate);
				}
				else
				{
                    try
                    {
                        chessBoard.Add(pawn.Object, coordinate);
                    }
                    catch (LimitExceededException e)
                    {
                        Assert.AreEqual("Exceed the limit of black pawn.", e.Message);
                        break;
                    }
				}
			}
		}
	}
}
