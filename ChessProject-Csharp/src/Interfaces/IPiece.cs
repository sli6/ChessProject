namespace SolarWinds.MSP.Chess
{
    public interface IPiece
    {
        Coordinate Coordinate { get; set; }

        PieceType PieceType { get; }

        PieceColor PieceColor { get; }

        IChessBoard ChessBoard { get; set; }

        void ValidateCoordinate(Coordinate coordinate);
    }
}