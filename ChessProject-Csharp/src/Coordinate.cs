using System;

namespace SolarWinds.MSP.Chess
{
    public class Coordinate
    {
        private int xCoordinate;
        private int yCoordinate;

        public Coordinate(int xCoordinate, int yCoordinate)
        {
            if (!isInsideChessBoard(xCoordinate, yCoordinate))
            {
                throw new InvalidCoordinateException(String.Format("Coordinate ({0}, {1}) is not inside the chessboard.", xCoordinate, yCoordinate));
            }

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

        private bool isInsideChessBoard(int xCoordinate, int yCoordinate)
        {
            if (xCoordinate < 0 || xCoordinate > 7 || yCoordinate < 0 || yCoordinate > 7)
            {
                return false;
            }

            return true;
        }
    }
}
