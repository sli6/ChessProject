using System;

namespace SolarWinds.MSP.Chess
{
    public class Pawn : Piece
    {
        private Coordinate coordinate;

        public Pawn(PieceColor pieceColor): base(pieceColor, PieceType.Pawn)
        {
        }

        public override Coordinate Coordinate
        {
            get { return coordinate; }
            set {
                if (PieceColor == PieceColor.Black && value.YCoordinate == 6)
                {
                    throw new InvalidCoordinateException("Black pawn is moved to an invalid coordinate");
                }
                if (PieceColor == PieceColor.White && value.YCoordinate == 0)
                {
                    throw new InvalidCoordinateException("White pawn is moved to an invalid coordinate");
                }

                coordinate = value;
            }
        }

        public override void Move(MovementType movementType, Coordinate coordinate)
        {
            throw new NotImplementedException("Need to implement Pawn.Move()");
        }

        public override bool IsCoordinateValid()
        {
            throw new NotImplementedException("Need to implement Pawn.Move()");
        }
    }
}
