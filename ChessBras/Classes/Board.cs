using System.Windows;

namespace ChessBras.Classes;

public class Board
{
    private List<APiece> _pieces;
    public Board()
    {
        InitBoard();
    }

    private void InitBoard()
    {
        _pieces = new List<APiece>();
        // Création des pièces
        for (int col = 0; col < Constants.BOARD_SIZE; col++)
        {
            _pieces.Add(new Pawn(1, col, false));
            _pieces.Add(new Pawn(6, col, true));
        }

        for (int row = 0; row<= 7; row+=7)
        {
            for (int column = 0; column <= 7; column++)
            {
                _pieces.Add(PieceBuilder.Build(row, column, row != 0));
            }
        }
    }

    public APiece GetPiece(int row, int col)
    {
        foreach (APiece piece in _pieces)
        {
            if (piece.GetRow() == row && piece.GetCol() == col)
            {
                return piece;
            }
        }
        return null;
    }

    public bool IsKingInCheck(int row, int col, bool isWhite)
    {
        foreach (APiece piece in _pieces)
        {
            if (piece.GetIsWhite() == !isWhite && piece.IsMoveLegal(row, col, this))
            {
                return true;
            }
        }
        return false;
    }

    public bool HasPiece(int row, int col)
    {
        return GetPiece(row, col) != null;
    }

    public void MovePiece(Coordinates selectedCell, Coordinates destinationCell)
    {
        APiece piece = GetPiece(selectedCell.GetRow(), selectedCell.GetCol());
        if (HasPiece(destinationCell.GetRow(), destinationCell.GetCol()))
        {
            MessageBox.Show("CHOMP!");
            _pieces.Remove(GetPiece(destinationCell.GetRow(), destinationCell.GetCol()));
        }
        piece.Move(destinationCell.GetRow(), destinationCell.GetCol());
    }

    public bool IsMoveLegal(Coordinates selectedCell, Coordinates destinationCell)
    {
        APiece fromPiece = GetPiece(selectedCell.GetRow(), selectedCell.GetCol());
        APiece destinationPiece = GetPiece(destinationCell.GetRow(), destinationCell.GetCol());
        if (destinationPiece != null && destinationPiece.GetIsWhite() == fromPiece.GetIsWhite())
        {
            return false;
        }

        return fromPiece.IsMoveLegal(destinationCell.GetRow(), destinationCell.GetCol(), this);

    }

    /// <summary>
    /// Permet de valider la présence d'une pièce sur le chemin en cas de mouvement
    /// Le mouvement de la pièce doit être validé avant d'appeler cette méthode
    /// </summary>
    /// <param name="selectedCell.GetRow()">Point de départ</param>
    /// <param name="destinationCell">Point d'arrivée</param>
    /// <returns>true s'il y a une collision, false sinon</returns>
    public bool HasCollision(Coordinates selectedCell, Coordinates destinationCell)
    {
        //vertical
        if (selectedCell.GetRow() != destinationCell.GetRow() && selectedCell.GetCol() == destinationCell.GetCol())
        {
            for (int row = Math.Min(selectedCell.GetRow(), destinationCell.GetRow()) +1; row < Math.Max(selectedCell.GetRow(), destinationCell.GetRow()); row++)
            {
                if (GetPiece(row, selectedCell.GetCol()) != null)
                {
                    return true;
                }
            }
        }
        // horizontal
        else if (selectedCell.GetCol() != destinationCell.GetCol() && selectedCell.GetRow() == destinationCell.GetRow())
        {
            for (int col = Math.Min(selectedCell.GetCol(), destinationCell.GetCol()) +1; col < Math.Max(selectedCell.GetCol(), destinationCell.GetCol()); col++)
            {
                if (GetPiece(selectedCell.GetRow(), col) != null)
                {
                    return true;
                }
            }
        }
        // diagonalle
        else
        {
            for (int i = 1; i < Math.Abs(selectedCell.GetCol() - destinationCell.GetCol()); i++)
            {
                // On va toujours valider les mouvements en allant vers le bas
                int row = Math.Min(selectedCell.GetRow(), destinationCell.GetRow()) + i;
                // dans ce cas, c'est l'increment de la colonne qui change
                int col = selectedCell.GetCol() > destinationCell.GetCol()
                    ? Math.Min(selectedCell.GetCol(), destinationCell.GetCol()) + i
                    : Math.Max(selectedCell.GetCol(), destinationCell.GetCol()) - i;

                if (GetPiece(row, col) != null)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
