namespace SolarWinds.MSP.Chess
{
    public interface IChessBoard
    {
        void ValidateIfPositionOccupied(Coordinate coordinate);
    }
}
