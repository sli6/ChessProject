using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class PawnTest
	{
		private Pawn pawn;

		[TestInitialize]
		public void SetUp()
		{
		}

		[TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "Pawn cannot be moved to right or left")]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
        {
            pawn = new Pawn(PieceColor.Black);
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
            pawn = new Pawn(PieceColor.Black);
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
                pawn = new Pawn(color);
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
        public void Pawn_Move_ILLegalCoordinates_Position_Occupied_DoesNotMove()
        {
        }

        [TestMethod]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
        }

        [TestMethod]
        public void Pawn_Move_LegalCoordinates_Right_Diagonal_UpdatesCoordinates()
        {
        }

        [TestMethod]
        public void Pawn_Move_LegalCoordinates_Left_Diagonal_UpdatesCoordinates()
        {
        }
    }
}
