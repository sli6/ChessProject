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
			pawn = new Pawn(PieceColor.Black);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
        }

        [TestMethod]
        public void Pawn_Move_IllegalCoordinates_Backward_DoesNotMove()
        {
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
