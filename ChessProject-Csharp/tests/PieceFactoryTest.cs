using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
    public class PieceFactoryTest
    {
        [TestInitialize]
        public void SetUp() { }

        [TestMethod]
        public void Create_Pawn_Piece()
        {
            var piece = PieceFactory.Create(PieceType.Pawn, PieceColor.Black);
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
                    var piece = PieceFactory.Create(pieceType, PieceColor.Black);
                }
                catch(NotImplementedException e)
                {
                    Assert.AreEqual(string.Format("{0} piece has not been implemented", pieceType), e.Message);
                }
            }
        }

        [TestMethod]
        public void Create_Invalid_Piece_Type()
        {
            var pieceType = (PieceType)7;

            try
            {
                var piece = PieceFactory.Create(pieceType, PieceColor.Black);
            }
            catch (InvalidPieceType e)
            {
                Assert.AreEqual("7 is not a valid piece type", e.Message);
            }
        }
    }
}
