using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolarWinds.MSP.Chess
{
    [TestClass]
    public class CoordinateTest
    {
        [TestInitialize]
        public void SetUp()
        {
        }

        [TestMethod]
        public void IsInsideChessBoard_True_X_equals_0_Y_equals_0()
        {
            var coordinate = new Coordinate(0, 0);
        }

        [TestMethod]
        public void IsInsideChessBoard_True_X_equals_5_Y_equals_5()
        {
            var coordinate = new Coordinate(5, 5);
        }

        [TestMethod]
        public void IsInsideChessBoard_False_X_equals_11_Y_equals_5()
        {
            try
            {
                var coordinate = new Coordinate(11, 5);
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (11, 5) is not inside the chessboard.", e.Message);
            }
        }


        [TestMethod]
        public void IsInsideChessBoard_False_X_equals_0_Y_equals_9()
        {
            try
            {
                var coordinate = new Coordinate(0, 9);
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (0, 9) is not inside the chessboard.", e.Message);
            }
        }

        [TestMethod]
        public void IsInsideChessBoard_False_X_equals_11_Y_equals_0()
        {
            try
            {
                var coordinate = new Coordinate(11, 0);
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (11, 0) is not inside the chessboard.", e.Message);
            }
        }

        [TestMethod]
        public void IsInsideChessBoard_False_For_Negative_X_Values()
        {
            try
            {
                var coordinate = new Coordinate(-1, 5);
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (-1, 5) is not inside the chessboard.", e.Message);
            }
        }

        [TestMethod]
        public void IsInsideChessBoard_False_For_Negative_Y_Values()
        {
            try
            {
                var coordinate = new Coordinate(5, -1);
            }
            catch (InvalidCoordinateException e)
            {
                Assert.AreEqual("Coordinate (5, -1) is not inside the chessboard.", e.Message);
            }
        }
    }
}
