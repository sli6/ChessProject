﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    public class TestPieceClass : Piece
    {
        public TestPieceClass(PieceColor pieceColor) : base(pieceColor, PieceType.Pawn)
        {
        }

        public override Coordinate Coordinate { get; set; }

        public override void ValidateCoordinate(Coordinate coordinate)
        {
            throw new NotImplementedException("Need to implement SubPiece.ValidateCoordinate()");
        }

        protected override void ValidateMove(Coordinate coordinate)
        {
            throw new NotImplementedException();
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
            testPieceClass = new TestPieceClass(PieceColor.Black) { CoordinateValidator = mockCoordinateValidator.Object };
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
