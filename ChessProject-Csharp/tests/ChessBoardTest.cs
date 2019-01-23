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
        public void Has_MaxBoardLength_of_8()
        {
            // assert
            Assert.AreEqual(8, ChessBoard.MaxBoardLength);
        }

        [TestMethod]
        public void Add_Piece_Valid_Positioning()
        {
            // arrange
            var firstPawn = new Pawn(PieceColor.Black);

            var secondPawn = new Pawn(PieceColor.Black);

            var coordinate1 = new Coordinate(6, 3);
            var coordinate2 = new Coordinate(5, 3);

            // act
            chessBoard.AddPiece(firstPawn, coordinate1);
            chessBoard.AddPiece(secondPawn, coordinate2);

            // assert
            Assert.AreEqual(coordinate1, firstPawn.Coordinate);
            Assert.AreEqual(coordinate2, secondPawn.Coordinate);
            Assert.AreEqual(chessBoard, firstPawn.ChessBoard);
            Assert.AreEqual(chessBoard, firstPawn.ChessBoard);
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
            chessBoard.AddPiece(pawn.Object, coordinate);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicatePositioningException), "Coordinate (6, 3) of the chess board has been positioned.")]
        public void Add_Piece_Avoids_Duplicate_Positioning()
        {
            // arrange
            var firstPawn = new Pawn(PieceColor.Black);
            var secondPawn = new Pawn(PieceColor.Black);
            var coordinate = new Coordinate(6, 3);

            chessBoard.AddPiece(firstPawn, coordinate);

            // act
            chessBoard.AddPiece(secondPawn, coordinate);
        }

        [TestMethod]
        public void Add_Piece_Limits_The_Number_Of_Pawns_Same_Color()
        {
            Test_Add_Piece_Limits(PieceColor.Black, 8, 6);
        }

        [TestMethod]
        public void Add_Piece_Limits_The_Number_Of_Pawns_Different_Color()
        {
            Test_Add_Piece_Limits(PieceColor.Black, 8, 6);
            Test_Add_Piece_Limits(PieceColor.White, 3, 2);
        }

        private void Test_Add_Piece_Limits(PieceColor pieceColor, int count, int start_row)
        {
            for (int i = 0; i < count; i++)
            {
                // arrange
                var pawn = new Pawn(pieceColor);

                int row = i / ChessBoard.MaxBoardLength;
                var coordinate = new Coordinate(i % ChessBoard.MaxBoardLength, start_row + row);

                if (row < 1)
                {
                    // act
                    chessBoard.AddPiece(pawn, coordinate);
                }
                else
                {
                    // act
                    try
                    {
                        chessBoard.AddPiece(pawn, coordinate);
                    }
                    catch (LimitExceededException e)
                    {
                        Assert.AreEqual(string.Format("Exceed the limit of {0} pawn.", pieceColor), e.Message);
                    }
                }
            }
        }

        [TestMethod]
        public void GetPiece_Returned()
        {
            // arrange
            var piece = new Pawn(PieceColor.White);

            var coordinate = new Coordinate(5, 3);
            chessBoard.AddPiece(piece, coordinate);

            // action
            IPiece result = chessBoard.GetPiece(coordinate);

            // assert
            Assert.AreEqual(piece, result);
        }

        [TestMethod]
        public void RemovePiece_Removed_Successful()
        {
            // arrange
            var piece = new Pawn(PieceColor.Black);
            var coordinate = new Coordinate(5, 3);
            chessBoard.AddPiece(piece, coordinate);

            // action
            IChessBoard result = chessBoard.RemovePiece(piece, coordinate);

            // assert
            Assert.AreEqual(chessBoard, result);
            Assert.AreEqual(null, chessBoard.GetPiece(coordinate));
            Assert.AreEqual(null, piece.ChessBoard);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPieceMovement), "The piece to be removed is not at Coordinate({0}, {1})")]
        public void RemovePiece_Removed_Failed()
        {
            // arrange
            var piece1 = new Pawn(PieceColor.Black);
            var coordinate1 = new Coordinate(5, 3);
            chessBoard.AddPiece(piece1, coordinate1);

            var piece2 = new Pawn(PieceColor.Black);
            var coordinate2 = new Coordinate(2, 3);
            chessBoard.AddPiece(piece2, coordinate2);

            // assert
            chessBoard.RemovePiece(piece2, coordinate1);
        }
    }
}
