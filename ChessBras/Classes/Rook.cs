namespace ChessBras.Classes;

public class Rook : APiece
{
    public Rook(int row, int col, bool isWhite) : base(row, col, isWhite)
    {
    }

    public override bool IsMoveLegal(int row, int col, Board board)
    {
        if (row != _row && col != _col)
        {
            return false;
        }
        if (board.HasCollision(_row, _col, row, col))
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return "♖";
    }

    public override void Move(int row, int col)
    {
        base.Move(row, col);
    }

}
