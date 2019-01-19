using System;

namespace SolarWinds.MSP.Chess
{
    public class Coordinate
    {
        private int xCoordinate;
        private int yCoordinate;

        public Coordinate(int xCoordinate, int yCoordinate)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public int XCoordinate
        {
            get { return xCoordinate; }
            private set { xCoordinate = value; }
        }
        
        public int YCoordinate
        {
            get { return yCoordinate; }
            private set { yCoordinate = value; }
        }
    }
}
