using System;

namespace SolarWinds.MSP.Chess
{
    public class CoordinateValidator : ICoordinateValidator
    {
        public void ValidateIfInsideChessBoard(Coordinate coordinate)
        {
            if (Math.Min(coordinate.X, coordinate.Y) < 0 || 
                Math.Max(coordinate.X, coordinate.Y) > ChessBoard.MaxBoardWidth - 1)
            {
                throw new InvalidCoordinateException(String.Format("Coordinate ({0}, {1}) is not inside the chessboard.",
                    coordinate.X, coordinate.Y));
            }
        }
    }
}
