using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class PawnTest
    {
        private Mock<ICoordinateValidator> mockCoordinateValidator;
        private ChessBoard chessBoard;

        [TestInitialize]
		public void SetUp()
		{
            mockCoordinateValidator = new Mock<ICoordinateValidator>();
            chessBoard = new ChessBoard() { CoordinateValidator = mockCoordinateValidator.Object };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
        {
            // arrange
            var pawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };

            var coordinate = new Coordinate(6, 3);
            chessBoard.Add(pawn, coordinate);

            var new_coordinate = new Coordinate(7, 3);

            // act
            pawn.Move(new_coordinate);

            // assert
            Assert.AreEqual(coordinate, pawn.Coordinate);
		}

		[TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
        {
            // arrange
            var pawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate = new Coordinate(6, 3);
            chessBoard.Add(pawn, coordinate);

            var new_coordinate = new Coordinate(5, 3);

            // act
            pawn.Move(new_coordinate);

            //assert
            Assert.AreEqual(coordinate, pawn.Coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved backwards")]
        public void Pawn_Move_IllegalCoordinates_Backwards_DoesNotMove()
        {
            // arrange
            var testCases = new[]
            {
                new { color = PieceColor.Black },
                new { color = PieceColor.White }
            };
            
            foreach(var testCase in testCases)
            {
                var pawn = new Pawn(testCase.color) { CoordinateValidator = mockCoordinateValidator.Object };
                var coordinate = new Coordinate(6, 3);
                chessBoard.Add(pawn, coordinate);

                var new_coordinate = new Coordinate(6, (testCase.color == PieceColor.Black) ? 4 : 2);

                // act
                pawn.Move(new_coordinate);

                //assert
                Assert.AreEqual(coordinate, pawn.Coordinate);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to a position which has been occupied")]
        public void Pawn_Move_ILLegalCoordinates_Position_Occupied_DoesNotMove()
        {
            // arrange
            var firstPawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate1 = new Coordinate(7, 4);
            chessBoard.Add(firstPawn, coordinate1);

            var secondPawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate2 = new Coordinate(6, 3);
            chessBoard.Add(secondPawn, coordinate2);

            // act
            secondPawn.Move(coordinate1);

            //assert
            Assert.AreEqual(coordinate2, secondPawn.Coordinate);
        }

        [TestMethod]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
            //arrange
            var pawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate1 = new Coordinate(7, 4);
            chessBoard.Add(pawn, coordinate1);
            
            var coordinate2 = new Coordinate(7, 2);

            //act
            pawn.Move(coordinate2);

            //assert
            Assert.AreEqual(coordinate2, pawn.Coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Right_Diagonal_UpdatesCoordinates()
        {
            // arrange
            var pawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate1 = new Coordinate(6, 3);
            chessBoard.Add(pawn, coordinate1);

            var coordinate2 = new Coordinate(7, 4);

            // act
            pawn.Move(coordinate2);

            //assert
            Assert.AreEqual(coordinate2, pawn.Coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Left_Diagonal_UpdatesCoordinates()
        {
            // arrange
            var pawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate1 = new Coordinate(6, 3);
            chessBoard.Add(pawn, coordinate1);

            var coordinate2 = new Coordinate(5, 4);
            
            // act
            pawn.Move(coordinate2);

            //assert
            Assert.AreEqual(coordinate2, pawn.Coordinate);
        }
    }
}
