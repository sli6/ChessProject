using System;

namespace SolarWinds.MSP.Chess
{
    public class InvalidPieceType : Exception
    {
        public InvalidPieceType(): base() { }
        public InvalidPieceType(string message) : base(message) { }
        public InvalidPieceType(string message, Exception inner) : base(message, inner) { }     
    }
}
