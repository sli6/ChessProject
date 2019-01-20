namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor pieceColor): base(pieceColor, PieceType.Pawn)
        {
        }

        public override Coordinate Coordinate { get; set; }


        /// <summary>
        /// TODO: add validation to make sure the pawn move 1 - 2 step in the first step and one 1 step only after
        /// </summary>
        /// <param name="coordinate"></param>
        protected override void ValidateMove(Coordinate coordinate)
        {
            if (Coordinate.X != coordinate.X)
                throw new InvalidPieceMovement("Pawn cannot be moved to right or left");

            ChessBoard.ValidateIfPositionOccupied(coordinate);

            if ((PieceColor == PieceColor.Black && Coordinate.Y < coordinate.Y) ||
                (PieceColor == PieceColor.White && Coordinate.Y > coordinate.Y))
                throw new InvalidPieceMovement("Pawn cannot be moved backwards");
        }

        public override void ValidateCoordinate(Coordinate coordinate)
        {
            if (PieceColor == PieceColor.Black && coordinate.Y == 7)
                throw new InvalidCoordinateException("Black pawn is moved to an invalid coordinate");
 
            if (PieceColor == PieceColor.White && coordinate.Y == 0)
                throw new InvalidCoordinateException("White pawn is moved to an invalid coordinate");         
        }
    }
}
