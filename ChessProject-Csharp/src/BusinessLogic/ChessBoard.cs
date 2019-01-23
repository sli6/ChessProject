using System;
using System.Collections.Generic;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Chess board containing chess board properties and functions.
    /// </summary>
    public class ChessBoard: IChessBoard
    {
        /// <summary>
        /// Maximum board length.
        /// </summary>
        public static readonly int MaxBoardLength = 8;
        
        /// <summary>
        /// Coordinate validator containing shared coordinate validation functions.
        /// </summary>
        public ICoordinateValidator CoordinateValidator { get; set; }

        private IPiece[,] pieces = new IPiece[MaxBoardLength, MaxBoardLength];

        private Dictionary<string, int> countOfPieces = new Dictionary<string, int>(){
            {"Pawn_Black", 0},
            {"Pawn_White", 0}
        };

        /// <summary>
        /// Add a piece to a square when setting up a chess board.
        /// </summary>
        /// <param name="piece">A piece object.</param>
        /// <param name="coordinate">The coordinate of a square into which a piece is to be added.</param>
        public void AddPiece(IPiece piece, Coordinate coordinate)
        {
            // validation
            CoordinateValidator.ValidateIfInsideChessBoard(coordinate);
            piece.ValidateCoordinate(coordinate);
            ValidateDuplicatePositioning(piece, coordinate);
            ValidateIfLimitExceeded(piece);

            // add
            piece.Coordinate = coordinate;
            pieces[coordinate.X, coordinate.Y] = piece;
            piece.ChessBoard = this;
            countOfPieces[piece.GetColorType()]++;
        }

        /// <summary>
        /// Get a piece from a coordinate.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public IPiece GetPiece(Coordinate coordinate)
        {
            // validation
            CoordinateValidator.ValidateIfInsideChessBoard(coordinate);

            // get
            return pieces[coordinate.X, coordinate.Y];
        }

        /// <summary>
        /// Remove a piece from a coordinate.
        /// </summary>
        /// <param name="coordinate">The coordinate of the square a piece is removed from.</param>
        /// <returns></returns>
        public IChessBoard RemovePiece(IPiece piece, Coordinate coordinate)
        {
            // validation
            CoordinateValidator.ValidateIfInsideChessBoard(coordinate);
            ValidatePieceAtCoordinate(piece, coordinate);

            // remove
            pieces[coordinate.X, coordinate.Y] = null;
            piece.ChessBoard = null;
            countOfPieces[piece.GetColorType()]--;
            return this;
        }
        
        private void ValidatePieceAtCoordinate(IPiece piece, Coordinate coordinate)
        {
            if (pieces[coordinate.X, coordinate.Y] != piece)
                throw new InvalidPieceMovement(string.Format("The piece to be removed is not at Coordinate({0}, {1})", coordinate.X, coordinate.Y));
        }

        private void ValidateDuplicatePositioning(IPiece piece, Coordinate coordinate)
        {
            if (pieces[coordinate.X, coordinate.Y] != null)
                throw new DuplicatePositioningException(string.Format("Coordinate ({0}, {1}) of the chess board has been positioned.", coordinate.X, coordinate.Y));
        }

        private void ValidateIfLimitExceeded(IPiece piece)
        {
            var colorType = piece.GetColorType();
            if (countOfPieces[colorType] >= piece.CountLimit)
                throw new LimitExceededException(string.Format("Exceed the limit of {0} pawn", piece.PieceColor));
        }
    }
}
