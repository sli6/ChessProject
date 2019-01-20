using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
    public class CoordinateValidatorTest
    {
        CoordinateValidator coordinateValidator;

        [TestInitialize]
        public void SetUp()
        {
            coordinateValidator = new CoordinateValidator();
        }

        [TestMethod]
        public void ValidateIfInsideChessBoard_Valid_X_equals_0_Y_equals_0()
        {
            coordinateValidator.ValidateIfInsideChessBoard(new Coordinate(0, 0));
        }

        [TestMethod]
        public void ValidateIfInsideChessBoard_Valid_X_equals_5_Y_equals_5()
        {
            coordinateValidator.ValidateIfInsideChessBoard(new Coordinate(5, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "Coordinate (11, 5) is not inside the chessboard.")]
        public void ValidateIfInsideChessBoard_Valid_X_equals_11_Y_equals_5()
        {
            coordinateValidator.ValidateIfInsideChessBoard(new Coordinate(11, 5));
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "Coordinate (0, 9) is not inside the chessboard.")]
        public void ValidateIfInsideChessBoard_Invalid_X_equals_0_Y_equals_9()
        {
            coordinateValidator.ValidateIfInsideChessBoard(new Coordinate(0, 9));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "Coordinate (11, 0) is not inside the chessboard.")]
        public void ValidateIfInsideChessBoard_Invalid_X_equals_11_Y_equals_0()
        {
            coordinateValidator.ValidateIfInsideChessBoard(new Coordinate(11, 0));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "Coordinate (-1, 5) is not inside the chessboard.")]
        public void ValidateIfInsideChessBoard_Invalid_For_Negative_X_Values()
        {
            coordinateValidator.ValidateIfInsideChessBoard(new Coordinate(-1, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCoordinateException), "Coordinate (5, -1) is not inside the chessboard.")]
        public void ValidateIfInsideChessBoard_Invalid_For_Negative_Y_Values()
        {
            coordinateValidator.ValidateIfInsideChessBoard(new Coordinate(5, -1));
        }
    }
}
