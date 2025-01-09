namespace ChessBras.Classes;

public class Pawn : APiece
{
    private bool _hasMoved = false;
    public Pawn(int row, int col, bool isWhite) : base(row, col, isWhite)
    {
        _hasMoved = false;
    }

    public override bool IsMoveLegal(int row, int col, Board board)
    {
        if (_isWhite && _row - row <= 0)
        {
            return false;
        }
        if (!_isWhite && _row - row >= 0)
        {
            return false;
        }
        if (Math.Abs(row - _row) > 2)
        {
            return false;
        }
        if (_hasMoved && Math.Abs(row - _row) > 1)
        {
            return false;
        }
        if (board.HasCollision(_row, _col, row, col))
        {
            return false;
        }
        // si on tente de manger une autre piece
        if (board.GetPiece(row, col) != null)
        {
            // le changement doit être d'une seule case en diagonale.
            if (Math.Abs(col - _col) != 1 || Math.Abs(row - _row) != 1)
            {
                return false;
            }
        }
        else if (_col != col)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return "♙";
    }

    public override void Move(int row, int col)
    {
        _hasMoved = true;
        base.Move(row, col);
    }
}
