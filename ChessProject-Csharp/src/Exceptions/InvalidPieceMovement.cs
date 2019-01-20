using System;

namespace SolarWinds.MSP.Chess
{
    public class InvalidPieceMovement : Exception
    {
        public InvalidPieceMovement() : base() { }
        public InvalidPieceMovement(string message) : base(message) { }
        public InvalidPieceMovement(string message, Exception inner) : base(message, inner) { }
    }
}
