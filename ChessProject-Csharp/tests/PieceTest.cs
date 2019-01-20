using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SolarWinds.MSP.Chess
{
    public class TestPieceClass : Piece
    {
        public TestPieceClass(PieceColor pieceColor) : base(pieceColor, PieceType.Pawn)
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

        [TestInitialize]
        public void Setup()
        {
            testPieceClass = new TestPieceClass(PieceColor.Black);
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
