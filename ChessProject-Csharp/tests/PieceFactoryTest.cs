﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
    public class PieceFactoryTest
    {
        private Mock<ICoordinateValidator> mockCoordinateValidator;
        private PieceFactory pieceFactory;

        [TestInitialize]
        public void SetUp()
        {
            mockCoordinateValidator = new Mock<ICoordinateValidator>();
            pieceFactory = new PieceFactory();
        }

        [TestMethod]
        public void Create_Pawn_Piece()
        {
            var piece = pieceFactory.Create(PieceType.Pawn, PieceColor.Black, mockCoordinateValidator.Object);
            Assert.AreEqual("SolarWinds.MSP.Chess.Pawn", piece.GetType().FullName);
        }

        [TestMethod]
        public void Create_Other_Piece_Not_implemented()
        {
            var pieceTypes = new PieceType[] {
                PieceType.Bishop, PieceType.King, PieceType.Queen,
                PieceType.Knight, PieceType.Rook };

            foreach(PieceType pieceType in pieceTypes)
            {
                try
                {
                    var piece = pieceFactory.Create(pieceType, PieceColor.Black, mockCoordinateValidator.Object);
                }
                catch(NotImplementedException e)
                {
                    Assert.AreEqual(string.Format("{0} piece has not been implemented", pieceType), e.Message);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceType), "7 is not a valid piece type")]
        public void Create_Invalid_Piece_Type()
        {
            var pieceType = (PieceType)7;

            var piece = pieceFactory.Create(pieceType, PieceColor.Black, mockCoordinateValidator.Object);
        }
    }
}
