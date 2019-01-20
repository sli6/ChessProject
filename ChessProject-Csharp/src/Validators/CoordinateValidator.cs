using System;

namespace SolarWinds.MSP.Chess
{
    public class CoordinateValidator : ICoordinateValidator
    {
        public void ValidateIfInsideChessBoard(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.X > 7
                || coordinate.Y < 0 || coordinate.Y > 7)
            {
                throw new InvalidCoordinateException(String.Format("Coordinate ({0}, {1}) is not inside the chessboard.",
                    coordinate.X, coordinate.Y));
            }
        }
    }
}
