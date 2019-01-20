namespace SolarWinds.MSP.Chess
{
    public class Coordinate
    {
        public Coordinate(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}
