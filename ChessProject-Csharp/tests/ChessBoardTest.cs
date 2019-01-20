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
			chessBoard = new ChessBoard() { CoordinateValidator = coordinateValidator.Object };
		}

        [TestMethod]
		public void Has_MaxBoardWidth_of_8()
        {         
            // assert
			Assert.AreEqual(8, ChessBoard.MaxBoardWidth);
		}

        [TestMethod]
		public void Has_MaxBoardHeight_of_8()
        {
            // assert
            Assert.AreEqual(8, ChessBoard.MaxBoardHeight); 
		}
        
        [TestMethod]
		public void Add_Piece_Valid_Positioning()
		{
            // arrange
            var firstPawn = new Mock<IPiece>();
            firstPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            firstPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);
            firstPawn.Setup(obj => obj.CountLimit).Returns(8);

            var secondPawn = new Mock<IPiece>();
            secondPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            secondPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);
            secondPawn.Setup(obj => obj.CountLimit).Returns(8);

            var coordinate1 = new Coordinate(6, 3);
            var coordinate2 = new Coordinate(5, 3);

            // act
            chessBoard.Add(firstPawn.Object, coordinate1);
            chessBoard.Add(secondPawn.Object, coordinate2);

            // assert
            firstPawn.VerifySet(obj => obj.Coordinate = coordinate1);
            secondPawn.VerifySet(obj => obj.Coordinate = coordinate2);
            firstPawn.VerifySet(obj => obj.ChessBoard = chessBoard);
            secondPawn.VerifySet(obj => obj.ChessBoard = chessBoard);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "")]
        public void Add_Piece_Invalid_Positioning_Based_On_Piece_Type()
        {
            // arrange
            var pawn = new Mock<IPiece>();
            pawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            pawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);
            pawn.Setup(obj => obj.CountLimit).Returns(8);

            var coordinate = new Coordinate(6, 3);

            pawn.Setup(obj => obj.ValidateCoordinate(coordinate)).Throws<InvalidCoordinateException>();

            // act
            chessBoard.Add(pawn.Object, coordinate);
        }
        
        [TestMethod]
        [ExpectedException(typeof(DuplicatePositioningException), "Coordinate (6, 3) of the chess board has been positioned.")]
        public void Add_Piece_Avoids_Duplicate_Positioning()
        {
            // arrange
            var firstPawn = new Mock<IPiece>();
            firstPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            firstPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);
            firstPawn.Setup(obj => obj.CountLimit).Returns(8);

            var secondPawn = new Mock<IPiece>();
            secondPawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
            secondPawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);
            secondPawn.Setup(obj => obj.CountLimit).Returns(8);

            var coordinate = new Coordinate(6, 3);

            chessBoard.Add(firstPawn.Object, coordinate);
            
            // act
            chessBoard.Add(secondPawn.Object, coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(LimitExceededException), "Exceed the limit of black pawn.")]
        public void Add_Piece_Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
            {
                // arrange
                var pawn = new Mock<IPiece>();
                pawn.Setup(obj => obj.PieceColor).Returns(PieceColor.Black);
                pawn.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

                int row = i / ChessBoard.MaxBoardWidth;
                var coordinate = new Coordinate(i % ChessBoard.MaxBoardWidth, 6 + row);

                if (row < 1)
                {
                    // act
                    chessBoard.Add(pawn.Object, coordinate);
				}
				else
                {
                    // act
                    chessBoard.Add(pawn.Object, coordinate);
                }
			}
		}

        [TestMethod]
        public void ValidateIfPositionOccupied_Not_Occupied()
        {
            // arrange
            var coordinate = new Coordinate(5, 3);

            // act
            chessBoard.ValidateIfPositionOccupied(coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(PositionOccupiedException), "Position(5, 3) has been occupied")]
        public void ValidateIfPositionOccupied_Occupied()
        {
            // arrange
            var piece = new Mock<IPiece>();
            piece.Setup(obj => obj.CountLimit).Returns(8);
            piece.Setup(obj => obj.PieceType).Returns(PieceType.Pawn);

            var coordinate = new Coordinate(5, 3);
            chessBoard.Add(piece.Object, coordinate);

            // act
            chessBoard.ValidateIfPositionOccupied(coordinate);
        }

    }
}
