using System.Windows;

namespace ChessBras.Classes;

public static class PieceBuilder
{
    public static APiece Build(int row, int column, bool isWhite)
    {
        switch(column) {
            case 0:
            case 7:
                return new Rook(row, column, isWhite);
            case 1:
            case 6:
                return new Knight(row, column, isWhite);
            case 2:
            case 5:
                return new Bishop(row, column, isWhite);
            case 3:
                return isWhite ? new King(row, column, isWhite) : new Queen(row, column, isWhite);
            case 4:
                return isWhite ? new Queen(row, column, isWhite) : new King(row, column, isWhite);
            default:
                throw new ArgumentException("Invalid column");
        }
    }
}
