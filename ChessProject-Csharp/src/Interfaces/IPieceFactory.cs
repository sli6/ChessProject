namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Piece factory class.
    /// </summary>
    public interface IPieceFactory
    {
        /// <summary>
        /// Create a piece based on its type, colour.
        /// Inject coordinate validator to the piece object as a property.
        /// </summary>
        /// <param name="pieceType"></param>
        /// <param name="pieceColor"></param>
        /// <param name="coordinateValidator"></param>
        /// <returns>Piece object.</returns>
        IPiece Create(PieceType pieceType, PieceColor pieceColor, ICoordinateValidator coordinateValidator);
    }
}