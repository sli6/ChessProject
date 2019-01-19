using System;

namespace SolarWinds.MSP.Chess
{
    public class LimitExceededException : Exception
    {
        public LimitExceededException() : base() { }
        public LimitExceededException(string message) : base(message) { }
        public LimitExceededException(string message, Exception inner) : base(message, inner) { }
    }
}
