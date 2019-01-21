using System;
using System.Collections.Generic;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Pawn class containing properties and functions. 
    /// </summary>
    public class Pawn : Piece
    {
        /// <summary>
        /// Contractor of pawn class.
        /// </summary>
        /// <param name="pieceColor">Color of Pawn.</param>
        public Pawn(PieceColor pieceColor) : base(pieceColor, PieceType.Pawn)
        {
        }
        
        private Dictionary<PieceColor, int> initialPosition = new Dictionary<PieceColor, int>() {
            {PieceColor.White, 1},
            {PieceColor.Black, 6}
        };

        /// <summary>
        /// Validate the coordinate of a square which a pawn is added or moved. 
        /// </summary>
        /// <param name="coordinate">Coordinate of the square a pawn is added or moved to.</param>
        public override void ValidateCoordinate(Coordinate coordinate)
        {
            if (PieceColor == PieceColor.Black && coordinate.Y == 7)
                throw new InvalidCoordinateException("Black pawn is moved to an invalid coordinate");

            if (PieceColor == PieceColor.White && coordinate.Y == 0)
                throw new InvalidCoordinateException("White pawn is moved to an invalid coordinate");
        }

        protected override int getCountLimit() => 8;

        protected override void ValidateMove(Coordinate coordinate)
        {
            if (Coordinate.X != coordinate.X)
                throw new InvalidPieceMovement("Pawn cannot move to right or left");

            if (PieceColor == PieceColor.Black && Coordinate.Y < coordinate.Y ||
                PieceColor == PieceColor.White && Coordinate.Y > coordinate.Y)
                throw new InvalidPieceMovement("Pawn cannot move backwards");

            if (!IsNumberOfStepsLegalForPawn(coordinate))
                throw new InvalidPieceMovement("Pawn cannot move for the required number of steps");
        }

        private bool IsNumberOfStepsLegalForPawn(Coordinate coordinate)
        {
            var steps = Math.Abs(coordinate.Y - Coordinate.Y);
            var validStep = GetValidSteps();

            return steps <= validStep;
        }

        private int GetValidSteps()
        {
            return (Coordinate.Y == initialPosition[PieceColor] ? 2 : 1);
        }
    }
}
