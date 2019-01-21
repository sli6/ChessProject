using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Coordinate validator class.
    /// </summary>
    public class CoordinateValidator : ICoordinateValidator
    {
        /// <summary>
        /// Validate if a coordinate a piece is added or moved to is inside the chess board.
        /// </summary>
        /// <param name="coordinate"></param>
        public void ValidateIfInsideChessBoard(Coordinate coordinate)
        {
            if (Math.Min(coordinate.X, coordinate.Y) < 0 ||
                Math.Max(coordinate.X, coordinate.Y) > ChessBoard.MaxBoardWidth - 1)
                throw new InvalidCoordinateException(String.Format("Coordinate ({0}, {1}) is not inside the chessboard.",
                    coordinate.X, coordinate.Y));
        }
    }
}
