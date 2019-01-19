using System;

namespace SolarWinds.MSP.Chess
{
    public abstract class Piece: IPiece
    {
        private ChessBoard chessBoard;
        private PieceType pieceType; 
        private int xCoordinate;
        private int yCoordinate;
        protected PieceColor pieceColor;

        protected Piece(PieceColor pieceColor, PieceType pieceType)
        {
            this.pieceColor = pieceColor;
            this.pieceType = pieceType;
        }

        public PieceType PieceType
        {
            get { return pieceType; }
            private set { pieceType = value;  }
        }

        public ChessBoard ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        public abstract Coordinate Coordinate { get; set; }

        public PieceColor PieceColor
        {
            get { return pieceColor; }
            private set { pieceColor = value; }
        }

        public abstract bool IsCoordinateValid();

        public abstract void Move(MovementType movementType, Coordinate coordinate);

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, Coordinate.XCoordinate, Coordinate.YCoordinate, PieceColor);
        }

    }
}
