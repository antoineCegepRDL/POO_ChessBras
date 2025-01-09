namespace ChessBras.Classes;

public class King : APiece
{
    public King(int row, int col, bool isWhite) : base(row, col, isWhite)
    {
    }

    public override bool IsMoveLegal(int row, int col, Board board)
    {
        if (Math.Abs(_row - row) > 1)
        {
            return false;
        }
        if (Math.Abs(_col - col) > 1)
        {
            return false;
        }
        if (IsDangerousPosition(row, col, board))
        {
            return false;
        }

        return true;
    }

    private bool IsDangerousPosition(int row, int col, Board board)
    {
        // ici, on fait semblait que le roi se déplace pour valider si le roi serait en échec sur le plateau
        Coordinates tempCoordinates = new(_row, _col);
        Move(row, col);
        bool isInvalidMove = board.IsKingInCheck(row, col, _isWhite);
        // on remet le roi à sa place
        Move(tempCoordinates.GetRow(), tempCoordinates.GetCol());
        return isInvalidMove;
    }

    public override string ToString()
    {
        return "♔";
    }

    public override void Move(int row, int col)
    {
        base.Move(row, col);
    }
}
