namespace ChessBras.Classes;

public class Knight : APiece
{
    public Knight(int row, int col, bool isWhite) : base(row, col, isWhite)
    {
    }

    public override bool IsMoveLegal(int row, int col, Board board)
    {
        if (Math.Abs(_row - row) == 2 && Math.Abs(_col - col) == 1)
        {
            return true;
        }
        if (Math.Abs(_row - row) == 1 && Math.Abs(_col - col) == 2)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "♘";
    }

    public override void Move(int row, int col)
    {
        base.Move(row, col);
    }
}
