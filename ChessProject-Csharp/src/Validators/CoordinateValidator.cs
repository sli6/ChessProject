using System;

namespace SolarWinds.MSP.Chess
{
    public class CoordinateValidator : ICoordinateValidator
    {
        public void ValidateIfInsideChessBoard(Coordinate coordinate)
        {
            if (coordinate.XCoordinate < 0 || coordinate.XCoordinate > 7
                || coordinate.YCoordinate < 0 || coordinate.YCoordinate > 7)
            {
                throw new InvalidCoordinateException(String.Format("Coordinate ({0}, {1}) is not inside the chessboard.",
                    coordinate.XCoordinate, coordinate.YCoordinate));
            }
        }
    }
}
