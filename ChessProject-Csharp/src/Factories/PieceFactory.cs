using System;

namespace SolarWinds.MSP.Chess
{
    public class PieceFactory : IPieceFactory
    {
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
