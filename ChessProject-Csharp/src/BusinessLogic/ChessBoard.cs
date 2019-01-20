using System;
using System.Collections.Generic;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Chess board 
    /// </summary>
    public class ChessBoard: IChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        private IPiece[,] pieces = new IPiece[MaxBoardWidth, MaxBoardHeight];

        public ICoordinateValidator CoordinateValidator { get; set; }

        private Dictionary<PieceType, int> countOfPieces = new Dictionary<PieceType, int>(){
            {PieceType.Pawn, 0}
        };
        
        public void ValidateIfPositionOccupied(Coordinate coordinate)
        {
           if (pieces[coordinate.X, coordinate.Y] != null)
                throw new PositionOccupiedException(string.Format("Position ({0}, {1}) has been occupied", coordinate.X, coordinate.Y));
        }

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
