using System;
using System.Collections.Generic;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard: IChessBoard
    {
        public static readonly int MaxBoardWidth = 8;
        public static readonly int MaxBoardHeight = 8;
        private ICoordinateValidator coordinateValidator;
        private IPiece[,] pieces = new IPiece[MaxBoardWidth, MaxBoardHeight];

        private Dictionary<PieceType, int> limitOfPieces = new Dictionary<PieceType, int>(){
            {PieceType.Queen, 1},
            {PieceType.King, 1 },
            {PieceType.Knight, 2 },
            {PieceType.Bishop, 2 },
            {PieceType.Pawn, 8 }
        };

        public ChessBoard(ICoordinateValidator coordinateValidator)
        {
            this.coordinateValidator = coordinateValidator;
        }

        public IPiece[,] Pieces
        {
            get
            {
                return pieces;
            }
        }

        public void Add(IPiece piece, Coordinate coordinate)
        {
            this.coordinateValidator.ValidateIfInsideChessBoard(coordinate);
            piece.ValidateCoordinate(coordinate);
            ValidateDuplicatePositioning(piece, coordinate);
            ValidateIfLimitExceeded(piece);

            piece.Coordinate = coordinate;
            pieces[coordinate.X, coordinate.Y] = piece;
            piece.ChessBoard = this;
        }

        private void ValidateDuplicatePositioning(IPiece piece, Coordinate coordinate)
        {
            if (pieces[coordinate.X, coordinate.Y] != null)
            {
                throw new DuplicatePositioningException(String.Format("Coordinate ({0}, {1}) of the chess board has been positioned.", coordinate.X, coordinate.Y));
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
