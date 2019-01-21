namespace SolarWinds.MSP.Chess
{
    public interface IPiece
    {
        /// <summary>
        /// Coordinate of a square a piece is in.
        /// </summary>
        Coordinate Coordinate { get; set; }

        /// <summary>
        /// Piece type.
        /// </summary>
        PieceType PieceType { get; }

        /// <summary>
        /// Piece color.
        /// </summary>
        PieceColor PieceColor { get; }

        /// <summary>
        /// Chess board a piece is on.
        /// </summary>
        IChessBoard ChessBoard { get; set; }

        /// <summary>
        /// Maximum number of pieces a chess board can contain.
        /// </summary>
        int CountLimit { get; }

        /// <summary>
        /// Abstraction function for validating the coordinate of a square a piece is moved or added to.
        /// The function should be overridden in different types of pieces. 
        /// </summary>
        /// <param name="coordinate"></param>
        void ValidateCoordinate(Coordinate coordinate);

        /// <summary>
        /// Move a piece to a square.
        /// </summary>
        /// <param name="coordinate">Coordinate of the destination square</param>
        void Move(Coordinate coordinate);
    }
}