namespace ChessBras.Classes;

public class Board
{
    private List<APiece> _pieces;
    public Board()
    {
        InitBoard();
    }

    /// <summary>
    /// Initializes the board with the pieces in their starting positions
    /// </summary>
    private void InitBoard()
    {
        _pieces = new List<APiece>();
    }
}
