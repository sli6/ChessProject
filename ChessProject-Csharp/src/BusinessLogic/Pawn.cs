﻿using System;

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
            if (Coordinate.YCoordinate == coordinate.YCoordinate)
            {
                throw new InvalidPieceMovement("Pawn cannot be moved to right or left");
            }

            if (Coordinate.XCoordinate == coordinate.XCoordinate && 
                (PieceColor == PieceColor.Black && Coordinate.YCoordinate < coordinate.YCoordinate ||
                PieceColor == PieceColor.White && Coordinate.YCoordinate > coordinate.YCoordinate))
            {
                throw new InvalidPieceMovement("Pawn cannot be moved backwards");
            }
        }

        public override void ValidateCoordinate(Coordinate coordinate)
        {
            if (PieceColor == PieceColor.Black && coordinate.YCoordinate == 7)
            {
                throw new InvalidCoordinateException("Black pawn is moved to an invalid coordinate");
            }
            if (PieceColor == PieceColor.White && coordinate.YCoordinate == 0)
            {
                throw new InvalidCoordinateException("White pawn is moved to an invalid coordinate");
            }
        }
    }
}
