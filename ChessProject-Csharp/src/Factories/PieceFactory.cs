using System;

namespace SolarWinds.MSP.Chess
{
    public class PieceFactory
    {
        public static IPiece Create(PieceType pieceType, PieceColor pieceColor)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    return new Pawn(pieceColor);
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
