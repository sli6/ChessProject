namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Coordinate class of a square on chess board containg properties of a coordinate. 
    /// </summary>
    public interface ICoordinate
    {
        /// <summary>
        /// X-axis of coordinate.
        /// </summary>
        int XCoordinate { get; set; }

        /// <summary>
        /// Y-axis of coordinate.
        /// </summary>
        int YCoordinate { get; set; }
    }
}
