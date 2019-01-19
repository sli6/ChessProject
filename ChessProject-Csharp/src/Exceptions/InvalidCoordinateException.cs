using System;

namespace SolarWinds.MSP.Chess
{
    public class InvalidCoordinateException: Exception
    {
        public InvalidCoordinateException(): base() { }
        public InvalidCoordinateException(string message) : base(message) { }
        public InvalidCoordinateException(string message, Exception inner) : base(message, inner) { }     
    }
}
