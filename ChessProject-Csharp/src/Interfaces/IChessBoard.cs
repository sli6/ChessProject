namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Chess board interface.
    /// </summary>
    public interface IChessBoard
    {
        /// <summary>
        /// Add a piece to a square when setting up a chess board.
        /// </summary>
        /// <param name="piece">A piece object.</param>
        /// <param name="coordinate">The coordinate of a square into which a piece is to be added.</param>
        void AddPiece(IPiece piece, Coordinate coordinate);

        /// <summary>
        /// Get a piece from a coordinate.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        IPiece GetPiece(Coordinate coordinate);

        /// <summary>
        /// Remove a piece from a coordinate.
        /// </summary>
        /// <param name="coordinate">The coordinate of the square a piece is removed from.</param>
        IChessBoard RemovePiece(IPiece piece, Coordinate coordinate);
    }
}
