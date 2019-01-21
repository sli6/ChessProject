using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Base class of piece which will be inherited by concrete pieces.
    /// The base class contains base properties and functions.
    /// </summary>
    public abstract class Piece: IPiece
    {
        /// <summary>
        /// Contructor of piece.
        /// </summary>
        /// <param name="pieceColor"></param>
        /// <param name="pieceType"></param>
        protected Piece(PieceColor pieceColor, PieceType pieceType)
        {
            PieceColor = pieceColor;
            this.PieceType = pieceType;
        }

        /// <summary>
        /// Piece type.
        /// </summary>
        public PieceType PieceType { get; private set; }

        /// <summary>
        /// Chess board a piece is on.
        /// </summary>
        public IChessBoard ChessBoard { get; set; }

        /// <summary>
        /// Coordinate of a square a piece is in.
        /// </summary>
        public Coordinate Coordinate { get; set; }

        /// <summary>
        /// Piece color.
        /// </summary>
        public PieceColor PieceColor { get; private set; }

        /// <summary>
        /// Coordinate validator containing shared validation functions for coordinate. 
        /// </summary>
        public ICoordinateValidator CoordinateValidator { get; set; }

        /// <summary>
        /// Maximum number of pieces a chess board can contain.
        /// </summary>
        public int CountLimit { get => getCountLimit(); }

        protected PieceColor pieceColor;

        protected ICoordinateValidator coordinateValidator;

        /// <summary>
        /// Abstraction function for validating the coordinate of a square a piece is moved or added to.
        /// The function should be overridden in different types of pieces. 
        /// </summary>
        /// <param name="coordinate"></param>
        public abstract void ValidateCoordinate(Coordinate coordinate);
        
        /// <summary>
        /// Move a piece to a square.
        /// </summary>
        /// <param name="coordinate">Coordinate of the destination square</param>
        public void Move(Coordinate coordinate)
        {
            if (ChessBoard == null)
                throw new ArgumentNullException("Piece requires a chessboard to move");

            CoordinateValidator.ValidateIfInsideChessBoard(coordinate);
            ChessBoard.ValidateIfPositionOccupied(coordinate);

            ValidateMove(coordinate);

            Coordinate = coordinate;
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        /// <summary>
        /// Abstract function for validating the coordinate of a square a piece is moved to.
        /// </summary>
        /// <param name="coordinate"></param>
        protected abstract void ValidateMove(Coordinate coordinate);

        /// <summary>
        /// Maximum number of pieces a chess board can contain.
        /// The function can be implemented for different types of pieces.
        /// The default value is 1, e.g., for Queen or King. 
        /// </summary>
        /// <returns></returns>
        protected virtual int getCountLimit() => 1;

        protected string CurrentPositionAsString()
        {
            var a = string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, Coordinate.X, Coordinate.Y, PieceColor);
            return a;
        }
    }
}
