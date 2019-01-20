namespace SolarWinds.MSP.Chess
{
    public interface ICoordinateValidator
    {
        void ValidateIfInsideChessBoard(Coordinate coordinate);
    }
}
