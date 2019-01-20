using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class ChessBoardTest
	{
		private ChessBoard chessBoard;
        private Mock<ICoordinateValidator> coordinateValidator;

        [TestInitialize]
		public void SetUp()
		{
            coordinateValidator = new Mock<ICoordinateValidator>();
			chessBoard = new ChessBoard(coordinateValidator.Object);
		}

        [TestMethod]
		public void Has_MaxBoardWidth_of_8()
        {          
			Assert.AreEqual(8, ChessBoard.MaxBoardWidth);
		}

        [TestMethod]
		public void Has_MaxBoardHeight_of_8()
		{
			Assert.AreEqual(8, ChessBoard.MaxBoardHeight); 
		}
        
        [TestMethod]
		public void Add_Piece_Valid_Positioning()
		{
            var firstPawn = new Mock<IPiece>();
            firstPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            firstPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var secondPawn = new Mock<IPiece>();
            secondPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            secondPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var coordinate1 = new Coordinate(6, 3);
            var coordinate2 = new Coordinate(5, 3);
            
            chessBoard.Add(firstPawn.Object, coordinate1);
            chessBoard.Add(secondPawn.Object, coordinate2);

            firstPawn.VerifySet(obj => obj.Coordinate = coordinate1);
            secondPawn.VerifySet(obj => obj.Coordinate = coordinate2);
            firstPawn.VerifySet(obj => obj.ChessBoard = chessBoard);
            secondPawn.VerifySet(obj => obj.ChessBoard = chessBoard);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "")]
        public void Add_Piece_Invalid_Positioning_Based_On_Piece_Type()
        {
            var pawn = new Mock<IPiece>();
            pawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            pawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var coordinate = new Coordinate(6, 3);

            pawn.Setup(obj => obj.ValidateCoordinate(coordinate)).Throws<InvalidCoordinateException>();

            chessBoard.Add(pawn.Object, coordinate);
        }
        
        [TestMethod]
        [ExpectedException(typeof(DuplicatePositioningException), "Coordinate (6, 3) of the chess board has been positioned.")]
        public void Add_Piece_Avoids_Duplicate_Positioning()
        {
            var firstPawn = new Mock<IPiece>();
            firstPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            firstPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var secondPawn = new Mock<IPiece>();
            secondPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            secondPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var coordinate = new Coordinate(6, 3);

            chessBoard.Add(firstPawn.Object, coordinate);
            chessBoard.Add(secondPawn.Object, coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(LimitExceededException), "Exceed the limit of black pawn.")]
        public void Add_Piece_Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
			{
                var pawn = new Mock<IPiece>();
                pawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
                pawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

                int row = i / ChessBoard.MaxBoardWidth;
                var coordinate = new Coordinate(i % ChessBoard.MaxBoardWidth, 6 + row);

                if (row < 1)
                {
                    chessBoard.Add(pawn.Object, coordinate);
				}
				else
				{
                    chessBoard.Add(pawn.Object, coordinate);
                }
			}
		}
	}
}
