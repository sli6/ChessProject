namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Coordinate validator class.
    /// </summary>
    public interface ICoordinateValidator
    {
        /// <summary>
        /// Validate if a coordinate a piece is added or moved to is inside the chess board.
        /// </summary>
        /// <param name="coordinate"></param>
        void ValidateIfInsideChessBoard(Coordinate coordinate);
    }
}
