using System.Windows;

namespace ChessBras.Classes;

public class Board
{
    private readonly List<APiece> _pieces = new List<APiece>();

    public Board()
    {
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

    internal void MovePiece(Coordinates selectedCell, Coordinates destinationCell)
    {
        APiece piece = GetPiece(selectedCell.GetRow(), selectedCell.GetCol());
        if (HasPiece(destinationCell.GetRow(), destinationCell.GetCol()))
        {
            MessageBox.Show("CHOMP!");
            _pieces.Remove(GetPiece(destinationCell.GetRow(), destinationCell.GetCol()));
        }
        piece.Move(destinationCell.GetRow(), destinationCell.GetCol());
    }

    internal bool IsMoveLegal(Coordinates selectedCell, Coordinates destinationCell)
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
    /// <param name="fromRow">Rangée de départ</param>
    /// <param name="fromCol">Colonne de départ</param>
    /// <param name="destinationRow">Rangée d'arrivée</param>
    /// <param name="destinationCol">Colonne d'arrivée</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal bool HasCollision(int fromRow, int fromCol, int destinationRow, int destinationCol)
    {
        //vertical
        if (fromRow != destinationRow && fromCol == destinationCol)
        {
            for (int row = Math.Min(fromRow, destinationRow) +1; row < Math.Max(fromRow, destinationRow); row++)
            {
                if (GetPiece(row, fromCol) != null)
                {
                    return true;
                }
            }
        }
        // horizontal
        else if (fromCol != destinationCol && fromRow == destinationRow)
        {
            for (int col = Math.Min(fromCol, destinationCol) +1; col < Math.Max(fromCol, destinationCol); col++)
            {
                if (GetPiece(fromRow, col) != null)
                {
                    return true;
                }
            }
        }
        // diagonalle
        else
        {
            for (int i = 1; i < Math.Abs(fromCol - destinationCol); i++)
            {
                // On va toujours valider les mouvements en allant vers le bas
                int row = Math.Min(fromRow, destinationRow) + i;
                // dans ce cas, c'est l'increment de la colonne qui change
                int col = fromCol > destinationCol
                    ? Math.Min(fromCol, destinationCol) + i
                    : Math.Max(fromCol, destinationCol) - i;

                if (GetPiece(row, col) != null)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
