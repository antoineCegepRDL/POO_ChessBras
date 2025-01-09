namespace ChessBras.Classes;

public class Coordinates
{
    private int _col;
    private int _row;

    public Coordinates(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public int GetCol()
    {
        return _col;
    }

    public int GetRow()
    {
        return _row;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Coordinates coordinates)
        {
            return _row == coordinates.GetRow() && _col == coordinates.GetCol();
        }
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
