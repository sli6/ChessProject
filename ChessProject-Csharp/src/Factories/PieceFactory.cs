using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Piece factory class.
    /// </summary>
    public class PieceFactory : IPieceFactory
    {
        /// <summary>
        /// Create a piece based on its type, colour.
        /// Inject coordinate validator to the piece object as a property.
        /// </summary>
        /// <param name="pieceType"></param>
        /// <param name="pieceColor"></param>
        /// <param name="coordinateValidator"></param>
        /// <returns>Piece object.</returns>
        public IPiece Create(PieceType pieceType, PieceColor pieceColor, ICoordinateValidator coordinateValidator)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return new Pawn(pieceColor) { CoordinateValidator = coordinateValidator };
                case PieceType.Queen:
                case PieceType.King:
                case PieceType.Bishop:
                case PieceType.Knight:
                case PieceType.Rook:
                    throw new NotImplementedException(string.Format("{0} piece has not been implemented", pieceType));
                default:
                    throw new InvalidPieceType(string.Format("{0} is not a valid piece type", pieceType));
            }
        }
    }
}
