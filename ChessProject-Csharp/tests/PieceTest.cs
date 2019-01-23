using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    public class TestPieceClass : Piece
    {
        public TestPieceClass(PieceColor pieceColor) : base(pieceColor, PieceType.Pawn)
        {
        }

        public override void ValidateCoordinate(Coordinate coordinate)
        {
            return;
        }

        protected override void ValidateMove(Coordinate coordinate)
        {
            return;
        }
    }

    [TestClass]
    public class PieceTest
    {
        private TestPieceClass testPieceClass;
        private Mock<ICoordinateValidator> mockCoordinateValidator;

        [TestInitialize]
        public void Setup()
        {

            mockCoordinateValidator = new Mock<ICoordinateValidator>();
            testPieceClass = new TestPieceClass(PieceColor.Black);
        }

        [TestMethod]
        public void ToString_Return_Coordinate()
        {
            // arrange
            var coordinate = new Coordinate(1, 2);
            testPieceClass.Coordinate = coordinate;

            // test
            Assert.AreEqual("Current X: 1\r\nCurrent Y: 2\r\nPiece Color: Black", testPieceClass.ToString());
        }

        [TestMethod]
        public void CountLimit_Returned()
        {
            // act
            var pawn = new TestPieceClass(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };

            // assert
            Assert.AreEqual(1, pawn.CountLimit);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Piece requires a chessboard to move")]
        public void Move_No_ChessBoard_Failed()
        {
            // arrange
            var pawn = new TestPieceClass(PieceColor.Black);
            var coordinate = new Coordinate(2, 3);

            // act
            pawn.Move(coordinate);
        }

        [TestMethod]
        public void Move_Successful()
        {
            // arrange
            var chessBoard = new ChessBoard() { CoordinateValidator = mockCoordinateValidator.Object };
            var coordinate1 = new Coordinate(4, 3);
            var coordinate2 = new Coordinate(3, 3);
            var testPiece = new TestPieceClass(PieceColor.Black);

            chessBoard.AddPiece(testPiece, coordinate1);

            // act
            testPiece.Move(coordinate2);

            // assert
            Assert.AreEqual(null, chessBoard.GetPiece(coordinate1));
            Assert.AreEqual(testPiece, chessBoard.GetPiece(coordinate2));
            Assert.AreEqual(chessBoard, testPiece.ChessBoard);
        }

        [TestMethod]
        public void GetColorType_Returned()
        {
            // arrange
            var pawn = new TestPieceClass(PieceColor.Black);

            // act
            Assert.AreEqual("Pawn_Black", pawn.GetColorType());
        }
    }
}
