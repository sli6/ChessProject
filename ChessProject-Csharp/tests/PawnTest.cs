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
            Test_Move_Pawn(PieceColor.Black, 6, 3, 7, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
        {
            Test_Move_Pawn(PieceColor.Black, 6, 3, 5, 3);
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

            foreach (var testCase in testCases)
            {
                var pawn = new Pawn(testCase.color) { CoordinateValidator = mockCoordinateValidator.Object };
                var coordinate = new Coordinate(6, 3);
                chessBoard.AddPiece(pawn, coordinate);

                var new_coordinate = new Coordinate(6, (testCase.color == PieceColor.Black) ? 4 : 2);

                // act
                pawn.Move(new_coordinate);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicatePositioningException), "Coordinate (6, 3) of the chess board has been positioned.")]
        public void Pawn_Move_ILLegalCoordinates_Position_Occupied_DoesNotMove()
        {
            // arrange
            var firstPawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate1 = new Coordinate(6, 3);
            chessBoard.AddPiece(firstPawn, coordinate1);

            var secondPawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate2 = new Coordinate(6, 4);
            chessBoard.AddPiece(secondPawn, coordinate2);

            // act
            secondPawn.Move(coordinate1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Right_Diagonal_UpdatesCoordinates()
        {
            Test_Move_Pawn(PieceColor.Black, 6, 3, 7, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Left_Diagonal_UpdatesCoordinates()
        {
            Test_Move_Pawn(PieceColor.Black, 6, 3, 5, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot move for the required number of steps")]
        public void Pawn_Move_IllegalCoordinate_Extra_Steps_After_First_Move()
        {
            // arrange
            var testCases = new[]
            {
                new { color = PieceColor.Black, fromXCoordinate = 6, fromYCoordinate = 5, toYCoordinate = 3 },
                new { color = PieceColor.Black, fromXCoordinate = 6, fromYCoordinate = 5, toYCoordinate = 2 },
                new { color = PieceColor.White, fromXCoordinate = 6, fromYCoordinate = 2, toYCoordinate = 4 },
                new { color = PieceColor.White, fromXCoordinate = 6,  fromYCoordinate = 2, toYCoordinate = 5 }
            };

            foreach (var testCase in testCases)
            {
                chessBoard = new ChessBoard() { CoordinateValidator = mockCoordinateValidator.Object };
                Test_Move_Pawn(testCase.color, testCase.fromXCoordinate, testCase.fromYCoordinate, testCase.fromXCoordinate, testCase.toYCoordinate);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot move for the required number of steps")]
        public void Pawn_Move_IllegalCoordinate_Extra_Steps_At_First_Move()
        {
            // arrange
            var testCases = new[]
            {
                new { color = PieceColor.Black, fromXCoordinate = 6, fromYCoordinate = 6, toYCoordinate = 2 },
                new { color = PieceColor.Black, fromXCoordinate = 6, fromYCoordinate = 6, toYCoordinate = 3 },
                new { color = PieceColor.White, fromXCoordinate = 6, fromYCoordinate = 1, toYCoordinate = 4},
                new { color = PieceColor.White, fromXCoordinate = 6,  fromYCoordinate = 1, toYCoordinate = 5}
            };

            foreach (var testCase in testCases)
            {
                chessBoard = new ChessBoard() { CoordinateValidator = mockCoordinateValidator.Object };
                Test_Move_Pawn(testCase.color, testCase.fromXCoordinate, testCase.fromYCoordinate, testCase.fromXCoordinate, testCase.toYCoordinate);
            }
        }

        [TestMethod]
        public void Pawn_Move_LegalCoordinate_Valid_Steps_At_First_Move()
        {
            // arrange
            var testCases = new[]
            {
                new { color = PieceColor.Black, fromXCoordinate = 6, fromYCoordinate = 6, toYCoordinate = 4 },
                new { color = PieceColor.Black, fromXCoordinate = 6, fromYCoordinate = 6, toYCoordinate = 5 },
                new { color = PieceColor.White, fromXCoordinate = 6, fromYCoordinate = 1, toYCoordinate = 2},
                new { color = PieceColor.White, fromXCoordinate = 6,  fromYCoordinate = 1, toYCoordinate = 3}
            };

            foreach(var testCase in testCases)
            {
                chessBoard = new ChessBoard() { CoordinateValidator = mockCoordinateValidator.Object };
                Test_Move_Pawn(testCase.color, testCase.fromXCoordinate, testCase.fromYCoordinate, testCase.fromXCoordinate, testCase.toYCoordinate);
            }
        }

        [TestMethod]
        public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
        {
            Test_Move_Pawn(PieceColor.Black, 7, 4, 7, 3);
        }

        [TestMethod]
        public void CountLimit_Returned()
        {
            var pawn = new Pawn(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };

            Assert.AreEqual(8, pawn.CountLimit);
        }

        private void Test_Move_Pawn(PieceColor pieceColor, int fromXCoordinate, int fromYCoordinate, int toXCoordinate, int toYCoordinate, bool assertCoordinateEqualsDestination = true)
        {
            //arrange
            var pawn = new Pawn(pieceColor) { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate1 = new Coordinate(fromXCoordinate, fromYCoordinate);
            chessBoard.AddPiece(pawn, coordinate1);

            var coordinate2 = new Coordinate(toXCoordinate, toYCoordinate);

            //act
            pawn.Move(coordinate2);

            //assert
            if (assertCoordinateEqualsDestination)
            {
                Assert.AreEqual(coordinate2, pawn.Coordinate);
                Assert.AreEqual(null, chessBoard.GetPiece(coordinate1));
                Assert.AreEqual(pawn, chessBoard.GetPiece(coordinate2));
            }
        }
    }
}
