namespace ChessBras.Classes;

public abstract class APiece
{
    protected int _row;
    protected int _col;
    protected bool _isWhite;
    public APiece(int row, int col, bool isWhite)
    {
        if (row < 0 || row >= Constants.BOARD_SIZE || col < 0 || col >= Constants.BOARD_SIZE)
        {
            throw new ArgumentException("Invalid position");
        }

        _row = row;
        _col = col;
        _isWhite = isWhite;
    }
    public virtual void Move(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public abstract bool IsMoveLegal(int row, int col, Board board);

    public override string ToString()
    {
        return "INVALID";
    }

    public int GetRow()
    {
        return _row;
    }

    public int GetCol()
    {
        return _col;
    }

    public bool GetIsWhite()
    {
        return _isWhite;
    }
}
