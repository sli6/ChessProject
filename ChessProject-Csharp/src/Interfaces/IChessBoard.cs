namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Chess board interface.
    /// </summary>
    public interface IChessBoard
    {
        /// <summary>
        /// Validate if a square contains a piece. 
        /// </summary>
        /// <param name="coordinate">Coordinate of a square.</param>
        void ValidateIfPositionOccupied(Coordinate coordinate);
    }
}
