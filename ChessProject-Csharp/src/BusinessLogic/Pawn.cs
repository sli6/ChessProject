namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor pieceColor): base(pieceColor, PieceType.Pawn)
        {
        }

        public override Coordinate Coordinate { get; set; }

        public override void Move(Coordinate coordinate)
        {
            CoordinateValidator.ValidateIfInsideChessBoard(coordinate);

            if (Coordinate.X != coordinate.X)
            {
                throw new InvalidPieceMovement("Pawn cannot be moved to right or left");
            }

            if (ChessBoard != null && ChessBoard.Pieces[coordinate.X, coordinate.Y] != null)
            {
                throw new InvalidPieceMovement("Pawn cannot be moved to a position which has been occupied1");
            }

            if ((PieceColor == PieceColor.Black && Coordinate.Y < coordinate.Y) ||
                (PieceColor == PieceColor.White && Coordinate.Y > coordinate.Y))
            {
                throw new InvalidPieceMovement("Pawn cannot be moved backwards");
            }

            Coordinate = coordinate;
        }

        public override void ValidateCoordinate(Coordinate coordinate)
        {
            if (PieceColor == PieceColor.Black && coordinate.Y == 7)
            {
                throw new InvalidCoordinateException("Black pawn is moved to an invalid coordinate");
            }

            if (PieceColor == PieceColor.White && coordinate.Y == 0)
            {
                throw new InvalidCoordinateException("White pawn is moved to an invalid coordinate");
            }
        }
    }
}
