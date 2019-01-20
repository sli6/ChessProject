using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class PawnTest
    {
        private dynamic mockCoordinateValidator;

        [TestInitialize]
		public void SetUp()
		{
            mockCoordinateValidator = new Mock<ICoordinateValidator>().Object;
		}

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
        {
            var pawn = new Pawn(PieceColor.Black, mockCoordinateValidator);
            var coordinate = new Coordinate(6, 3);
            pawn.Coordinate = coordinate;

            var new_coordinate = new Coordinate(7, 3);
            pawn.Move(new_coordinate);

            Assert.AreEqual(coordinate, pawn.Coordinate);
		}

		[TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
        {
            var pawn = new Pawn(PieceColor.Black, mockCoordinateValidator);
            var coordinate = new Coordinate(6, 3);
            pawn.Coordinate = coordinate;

            var new_coordinate = new Coordinate(5, 3);
            pawn.Move(new_coordinate);

            Assert.AreEqual(coordinate, pawn.Coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved backwards")]
        public void Pawn_Move_IllegalCoordinates_Backwards_DoesNotMove()
        {
            var pieceColors = new PieceColor[] { PieceColor.Black, PieceColor.White };

            foreach(PieceColor color in pieceColors)
            {
                var pawn = new Pawn(color, mockCoordinateValidator);
                var coordinate = new Coordinate(6, 3);
                pawn.Coordinate = coordinate;

                int yCoordinate = 2;

                if (color == PieceColor.Black)
                {
                    yCoordinate = 4;
                }

                var new_coordinate = new Coordinate(6, yCoordinate);
                pawn.Move(new_coordinate);

                Assert.AreEqual(coordinate, pawn.Coordinate);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to a position which has been occupied")]
        public void Pawn_Move_ILLegalCoordinates_Position_Occupied_DoesNotMove()
        {
            var chessBoard = new ChessBoard(mockCoordinateValidator);
            var firstPawn = new Pawn(PieceColor.White, mockCoordinateValidator);
            var coordinate1 = new Coordinate(7, 4);
            chessBoard.Add(firstPawn, coordinate1);

            var secondPawn = new Pawn(PieceColor.White, mockCoordinateValidator);
            var coordinate2 = new Coordinate(6, 3);
            chessBoard.Add(secondPawn, coordinate2);

            secondPawn.Move(coordinate1);

            Assert.AreEqual(coordinate2, secondPawn.Coordinate);
        }

        [TestMethod]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
            var chessBoard = new ChessBoard(mockCoordinateValidator);
            var pawn = new Pawn(PieceColor.White, mockCoordinateValidator);
            var coordinate1 = new Coordinate(7, 4);
            chessBoard.Add(pawn, coordinate1);
            
            var coordinate2 = new Coordinate(7, 5);
            pawn.Move(coordinate2);

            Assert.AreEqual(coordinate2, pawn.Coordinate);
        }

        [TestMethod]
        public void Pawn_Move_LegalCoordinates_Right_Diagonal_UpdatesCoordinates()
        {
            var chessBoard = new ChessBoard(mockCoordinateValidator);
            var pawn = new Pawn(PieceColor.White, mockCoordinateValidator);
            var coordinate1 = new Coordinate(6, 3);
            chessBoard.Add(pawn, coordinate1);

            var coordinate2 = new Coordinate(7, 4);
            pawn.Move(coordinate2);

            Assert.AreEqual(coordinate2, pawn.Coordinate);
        }

        [TestMethod]
        public void Pawn_Move_LegalCoordinates_Left_Diagonal_UpdatesCoordinates()
        {
            var chessBoard = new ChessBoard(mockCoordinateValidator);
            var pawn = new Pawn(PieceColor.White, mockCoordinateValidator);
            var coordinate1 = new Coordinate(6, 3);
            chessBoard.Add(pawn, coordinate1);

            var coordinate2 = new Coordinate(5, 4);
            pawn.Move(coordinate2);

            Assert.AreEqual(coordinate2, pawn.Coordinate);
        }
    }
}
