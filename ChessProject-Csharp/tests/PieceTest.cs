using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    public class TestPieceClass : Piece
    {
        public TestPieceClass(PieceColor pieceColor, ICoordinateValidator coordinateValidator) : base(pieceColor, PieceType.Pawn, coordinateValidator)
        {
        }

        public override Coordinate Coordinate { get; set; }

        public override void Move(Coordinate coordinate)
        {
            throw new NotImplementedException("Need to implement SubPiece.Move()");
        }

        public override void ValidateCoordinate(Coordinate coordinate)
        {
            throw new NotImplementedException("Need to implement SubPiece.ValidateCoordinate()");
        }
    }

    [TestClass]
    public class PieceTest
    {
        private TestPieceClass testPieceClass;
        private dynamic mockCoordinateValidator;

        [TestInitialize]
        public void Setup()
        {

            mockCoordinateValidator = new Mock<ICoordinateValidator>().Object;
            testPieceClass = new TestPieceClass(PieceColor.Black, mockCoordinateValidator);
        }

        [TestMethod]
        public void ToString_Return_Coordinate()
        {
            var coordinate = new Coordinate(1, 2);
            testPieceClass.Coordinate = coordinate;
            Assert.AreEqual("Current X: 1\r\nCurrent Y: 2\r\nPiece Color: Black", testPieceClass.ToString());
        }
    }
}
