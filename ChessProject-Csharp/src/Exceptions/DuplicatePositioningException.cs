using System;

namespace SolarWinds.MSP.Chess
{
    public class DuplicatePositioningException : Exception
    {
        public DuplicatePositioningException(): base() { }
        public DuplicatePositioningException(string message) : base(message) { }
        public DuplicatePositioningException(string message, Exception inner) : base(message, inner) { }     
    }
}
