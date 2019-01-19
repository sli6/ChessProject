using System;
using System.Collections.Generic;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        private IPiece[,] pieces = new IPiece[MaxBoardWidth, MaxBoardHeight];
        private Dictionary<PieceType, int> limitOfPieces = new Dictionary<PieceType, int>(){
            {PieceType.Queen, 1},
            {PieceType.King, 1 },
            {PieceType.Knight, 2 },
            {PieceType.Bishop, 2 },
            {PieceType.Pawn, 8 }
        };

        public void Add(IPiece piece, Coordinate coordinate)
        {
            ValidateIfInsideChessBoard(coordinate);
            piece.ValidateCoordinate(coordinate);
            ValidateDuplicatePositioning(piece, coordinate);
            ValidateIfLimitExceeded(piece);            
        }

        public void ValidateIfInsideChessBoard(Coordinate coordinate)
        {
            if (coordinate.XCoordinate < 0 || coordinate.XCoordinate > 7 
                || coordinate.YCoordinate < 0 || coordinate.YCoordinate > 7)
            {
                throw new InvalidCoordinateException(String.Format("Coordinate ({0}, {1}) is not inside the chessboard.",
                    coordinate.XCoordinate, coordinate.YCoordinate));
            }
        }

        private void ValidateDuplicatePositioning(IPiece piece, Coordinate coordinate)
        {
            if (pieces[coordinate.XCoordinate, coordinate.YCoordinate] == null)
            {
                piece.Coordinate = coordinate;
                pieces[coordinate.XCoordinate, coordinate.YCoordinate] = piece;
            }
            else
            {
                throw new DuplicatePositioningException(String.Format("Coordinate ({0}, {1}) of the chess board has been positioned.", coordinate.XCoordinate, coordinate.YCoordinate));
            }
        }

        private void ValidateIfLimitExceeded(IPiece piece)
        {
            int limit = GetLimitByPieceType(piece.PieceType);
            var count = 0;

            foreach (IPiece pieceOnChessBoard in pieces)
            {
                if (pieceOnChessBoard != null && pieceOnChessBoard.PieceType == piece.PieceType
                    && pieceOnChessBoard.PieceColor == piece.PieceColor)
                {
                    count += 1;
                }
            }

            if (count > limit)
            {
                throw new LimitExceededException("Exceed the limit of black pawn.");
            }
        }

        private int GetLimitByPieceType(PieceType pieceType)
        {
            if (limitOfPieces.ContainsKey(pieceType))
                return limitOfPieces[pieceType];

            throw new InvalidPieceType(String.Format("The {0} piece is not recognised.", pieceType));
        }

    }
}
