using System;

namespace SolarWinds.MSP.Chess
{
    public abstract class Piece: IPiece
    {
        protected PieceColor pieceColor;
        protected ICoordinateValidator coordinateValidator;

        protected Piece(PieceColor pieceColor, PieceType pieceType)
        {
            PieceColor = pieceColor;
            this.PieceType = pieceType;
        }

        public PieceType PieceType { get; private set; }

        public IChessBoard ChessBoard { get; set; }

        public abstract Coordinate Coordinate { get; set; }

        public PieceColor PieceColor { get; private set; }

        public ICoordinateValidator CoordinateValidator { get; set; }

        public abstract void ValidateCoordinate(Coordinate coordinate);

        protected abstract void ValidateMove(Coordinate coordinate);


        public void Move(Coordinate coordinate)
        {
            if (ChessBoard == null)
                throw new ArgumentNullException("Piece requires a chessboard to move");

            CoordinateValidator.ValidateIfInsideChessBoard(coordinate);
            ValidateMove(coordinate);
            Coordinate = coordinate;
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            var a = string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, Coordinate.X, Coordinate.Y, PieceColor);
            return a;
        }

    }
}
