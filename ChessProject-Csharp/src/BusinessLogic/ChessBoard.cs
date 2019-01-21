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
        /// Maximum board width.
        /// </summary>
        public static readonly int MaxBoardWidth = 8;

        /// <summary>
        /// Maximum board height.
        /// </summary>
        public static readonly int MaxBoardHeight = 8;

        /// <summary>
        /// Coordinate validator containing shared coordinate validation functions.
        /// </summary>
        public ICoordinateValidator CoordinateValidator { get; set; }

        private IPiece[,] pieces = new IPiece[MaxBoardWidth, MaxBoardHeight];

        private Dictionary<PieceType, int> countOfPieces = new Dictionary<PieceType, int>(){
            {PieceType.Pawn, 0}
        };

        /// <summary>
        /// Validate if a square contains a piece. 
        /// </summary>
        /// <param name="coordinate">Coordinate of a square.</param>
        public void ValidateIfPositionOccupied(Coordinate coordinate)
        {
           if (pieces[coordinate.X, coordinate.Y] != null)
                throw new PositionOccupiedException(string.Format("Position ({0}, {1}) has been occupied", coordinate.X, coordinate.Y));
        }

        /// <summary>
        /// Add a piece to a square when setting up a chess board.
        /// </summary>
        /// <param name="piece">A piece object.</param>
        /// <param name="coordinate">The coordinate of a square into which a piece is to be added.</param>
        public void Add(IPiece piece, Coordinate coordinate)
        {
            CoordinateValidator.ValidateIfInsideChessBoard(coordinate);
            piece.ValidateCoordinate(coordinate);
            ValidateDuplicatePositioning(piece, coordinate);
            ValidateIfLimitExceeded(piece);

            AddPiece(piece, coordinate);
        }

        private void ValidateDuplicatePositioning(IPiece piece, Coordinate coordinate)
        {
            if (pieces[coordinate.X, coordinate.Y] != null)
                throw new DuplicatePositioningException(String.Format("Coordinate ({0}, {1}) of the chess board has been positioned.", coordinate.X, coordinate.Y));
        }

        private void ValidateIfLimitExceeded(IPiece piece)
        {
            if (countOfPieces[piece.PieceType] >= piece.CountLimit)
                throw new LimitExceededException("Exceed the limit of black pawn.");
        }

        private void AddPiece(IPiece piece, Coordinate coordinate)
        {
            piece.Coordinate = coordinate;
            pieces[coordinate.X, coordinate.Y] = piece;
            piece.ChessBoard = this;
            countOfPieces[piece.PieceType]++;
        }
    }
}
