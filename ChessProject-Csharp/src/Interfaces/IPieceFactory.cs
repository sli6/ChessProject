namespace SolarWinds.MSP.Chess
{
    public interface IPieceFactory
    {
        IPiece Create(PieceType pieceType, PieceColor pieceColor, ICoordinateValidator coordinateValidator);
    }
}