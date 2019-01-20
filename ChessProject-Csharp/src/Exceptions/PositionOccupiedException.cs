using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarWinds.MSP.Chess
{
    public class PositionOccupiedException : Exception
    {
        public PositionOccupiedException() : base() { }
        public PositionOccupiedException(string message) : base(message) { }
        public PositionOccupiedException(string message, Exception inner) : base(message, inner) { }

    }
}
