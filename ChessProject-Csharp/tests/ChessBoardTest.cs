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
		public void Has_MaxBoardWidth_of_7()
        {          
			Assert.AreEqual(7, ChessBoard.MaxBoardWidth);
		}

        [TestMethod]
		public void Has_MaxBoardHeight_of_7()
		{
			Assert.AreEqual(7, ChessBoard.MaxBoardHeight); 
		}

        [TestMethod]
		public void Valid_Positioning()
		{
            var firstPawn = new Pawn(PieceColor.Black);
            var secondPawn = new Pawn(PieceColor.Black);

            var coordinate1 = new Coordinate(6, 3);
            var coordinate2 = new Coordinate(5, 3);

            chessBoard.Add(firstPawn, coordinate1);
            chessBoard.Add(secondPawn, coordinate2);
        }

        [TestMethod]
        public void Avoids_Duplicate_Positioning()
        {
            var firstPawn = new Pawn(PieceColor.Black);
            var secondPawn = new Pawn(PieceColor.Black);

            var coordinate = new Coordinate(6, 3);

            chessBoard.Add(firstPawn, coordinate);
            try
            {
                chessBoard.Add(secondPawn, coordinate);
            }
            catch (DuplicatePositioningException e)
            {
                Assert.AreEqual("Coordinate (6, 3) of the chess board has been positioned.", e.Message);
            }
        }

        [TestMethod]
		public void Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
			{
				var pawn = new Pawn(PieceColor.Black);
				int row = i / ChessBoard.MaxBoardWidth;
                var coordinate = new Coordinate(i % ChessBoard.MaxBoardWidth, 6 + row);
				if (row < 1)
                {
                    chessBoard.Add(pawn, coordinate);
                    Assert.AreEqual(pawn.Coordinate.XCoordinate, (i % ChessBoard.MaxBoardWidth));
					Assert.AreEqual(pawn.Coordinate.YCoordinate, (6 + row));
				}
				else
				{
                    try
                    {
                        chessBoard.Add(pawn, coordinate);
                    }
                    catch (LimitExceededException e)
                    {
                        Assert.AreEqual("Exceed the limit of black pawn.", e.Message);
                    }
                    Assert.AreEqual(pawn.Coordinate.YCoordinate, -1);
				}
			}
		}
	}
}
