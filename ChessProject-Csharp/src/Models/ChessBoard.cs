using System;
using System.Collections.Generic;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        private IPiece[,] pieces = new Piece[MaxBoardWidth, MaxBoardHeight];
        private Dictionary<PieceType, int> limitOfPieces = new Dictionary<PieceType, int>(){
            {PieceType.Queen, 1},
            {PieceType.King, 1 },
            {PieceType.Knight, 2 },
            {PieceType.Bishop, 2 },
            {PieceType.Pawn, 8 }
        };

        public ChessBoard ()
        {
        }

        public void Add(Piece piece, Coordinate coordinate)
        {
            if (pieces[coordinate.XCoordinate, coordinate.YCoordinate] == null)
            {
                piece.Coordinate = coordinate;
                pieces[coordinate.XCoordinate, coordinate.YCoordinate] = piece;
            } 
            else
            {
                throw new DuplicatePositioningException("Coordinate ({0}, {1}) of the chess board has been positioned.");
            }

            int limit = getLimitByPieceType(piece.PieceType);
            var count = 0;

            foreach(Piece pieceOnChessBoard in pieces)
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

        private int getLimitByPieceType(PieceType pieceType)
        {
            if (limitOfPieces.ContainsKey(pieceType))
                return limitOfPieces[pieceType];

            throw new InvalidPieceType(String.Format("The {0} piece is not recognised.", pieceType));
        }

    }
}
