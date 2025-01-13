using ChessBras.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace ChessBras
{
    public partial class MainWindow : Window
    {
        private Board _board { get; set; }
        private Coordinates _selectedCell, _destinationCell;

        public MainWindow()
        {
            _board = new Board();
            InitializeComponent();
            CreateChessBoard();
            RefreshUI();
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateChessBoard()
        {
            // Créer les cases
            for (int x = 0; x < Constants.BOARD_SIZE; x++)
            {
                for (int y = 0; y < Constants.BOARD_SIZE; y++)
                {
                    var rect = new Rectangle
                    {
                        Fill = (x + y) % 2 == 0 ? Brushes.Bisque : Brushes.SaddleBrown
                    };
                    rect.MouseLeftButtonDown += Rectangle_MouseLeftButtonDown;
                    Grid.SetRow(rect, x);
                    Grid.SetColumn(rect, y);
                    GBoard.Children.Add(rect);
                }
            }
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rect)
            {
                int row = Grid.GetRow(rect);
                int col = Grid.GetColumn(rect);
                APiece piece = _board.GetPiece(row, col);
                if (_selectedCell == null && _board.HasPiece(row, col))
                {
                    _selectedCell = new Coordinates(row, col);
                    rect.BeginAnimation(OpacityProperty, new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.5)));
                }
                else if (_selectedCell != null)
                {
                    _destinationCell = new Coordinates(row, col);
                    if (_board.IsMoveLegal(_selectedCell, _destinationCell))
                    {
                        _board.MovePiece(_selectedCell, _destinationCell);
                    }
                    else
                    {
                        MessageBox.Show("Mouvement invalide");
                    }
                    RefreshUI();
                    _selectedCell = null;
                    _destinationCell = null;
                }
            }
        }

        private void RefreshUI()
        {
            // fournir aux étudiants dans un helper
            GBoard.Children.OfType<TextBlock>().ToList().ForEach(x => GBoard.Children.Remove(x));
            foreach (var item in GBoard.Children)
            {
                if (item is Rectangle rectangle)
                {
                    rectangle.BeginAnimation(OpacityProperty, new DoubleAnimation(1.0, TimeSpan.FromSeconds(0.1)));
                }
            }

            for (int x = 0; x < Constants.BOARD_SIZE; x++)
            {
                for (int y = 0; y < Constants.BOARD_SIZE; y++)
                {
                    APiece piece = _board.GetPiece(x, y);
                    TextBlock textBlock = new TextBlock()
                    {
                        FontSize = 36,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontWeight = FontWeights.ExtraBold,
                        IsHitTestVisible = false // pour que le clic se rende jusqu'au rectangle
                    };
                    if (piece != null)
                    {
                        textBlock.Text = piece.ToString();
                        textBlock.Foreground = piece.GetIsWhite() ? Brushes.White : Brushes.Black;
                        textBlock.Effect = new DropShadowEffect
                        {
                            Color = Colors.Gray,
                            BlurRadius = 5,
                            ShadowDepth = 2,
                            Opacity = 0.5
                        };

                    }

                    Grid.SetRow(textBlock, x);
                    Grid.SetColumn(textBlock, y);
                    GBoard.Children.Add(textBlock);
                }
            }
        }

        //    // Placement des pièces blanches

    }
}