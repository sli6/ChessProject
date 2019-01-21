namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Coordinate class of a square on chess board containg properties of a coordinate. 
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Constructor of coordinate class.
        /// </summary>
        /// <param name="xCoordinate">X-axis of coordinate.</param>
        /// <param name="yCoordinate">Y-axis of coordinate.</param>
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        /// <summary>
        /// X-axis of coordinate.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Y-axis of coordinate.
        /// </summary>
        public int Y { get; private set; }
    }
}
