namespace SolarWinds.MSP.Chess
{
    public interface IPiece
    {
        Coordinate Coordinate { get; set; }

        PieceType PieceType { get; }

        PieceColor PieceColor { get; }

        IChessBoard ChessBoard { get; set; }

        int CountLimit { get; }

        void ValidateCoordinate(Coordinate coordinate);
    }
}