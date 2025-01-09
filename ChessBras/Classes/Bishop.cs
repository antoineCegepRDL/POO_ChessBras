namespace ChessBras.Classes;

public class Bishop : APiece
{
    public Bishop(int row, int col, bool isWhite) : base(row, col, isWhite)
    {
    }

    public override bool IsMoveLegal(int row, int col, Board board)
    {
        if (Math.Abs(_row - row) != Math.Abs(_col - col))
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
        return "♗";
    }

    public override void Move(int row, int col)
    {
        base.Move(row, col);
    }
}
