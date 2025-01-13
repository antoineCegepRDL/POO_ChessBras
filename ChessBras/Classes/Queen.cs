namespace ChessBras.Classes;

public class Queen : APiece
{
    public Queen(int row, int col, bool isWhite) : base(row, col, isWhite)
    {
    }

    public override bool IsMoveLegal(int row, int col, Board board)
    {
        // si ce n'est pas en ligne droite, alors cest diagonale
        if (row != _row && col != _col)
        {
            if (Math.Abs(_row - row) != Math.Abs(_col - col))
            {
                return false;
            }
        }
        if (board.HasCollision(new Coordinates(_row, _col), new Coordinates(row, col)))
        {
            return false;
        }
        return true;
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return "♕";
    }

    public override void Move(int row, int col)
    {
        base.Move(row, col);
    }
}
