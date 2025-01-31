using ChessBras.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ChessBras
{
    public partial class MainWindow : Window
    {
        // étape 1. Ajouter le board.

        public MainWindow()
        {
            InitializeComponent();
            CreateChessBoard();
            RefreshUI();
        }

        /// <summary>
        /// Pour faciliter la création du plateau de jeu, j'ai ajouté 8 colonnes et 8 rangées de rectangles. Ces rectangles sont colorés en alternance pour simuler un plateau d'échecs.
        /// Je te laisse deux bouts de code pour t'aider à démarrer soit l'ajout de deux cases dans deux endroits dans le jeu.
        /// </summary>
        private void CreateChessBoard()
        {
            var rect1 = new Rectangle
            {
                Fill = Brushes.Bisque
            };

            var rect2 = new Rectangle
            {
                Fill = Brushes.SaddleBrown
            };

            // Pour chosir la rangée et la colonne on fait ainsi  :
            Grid.SetRow(rect1, 0);
            Grid.SetColumn(rect1, 0);

            Grid.SetRow(rect2, 2);
            Grid.SetColumn(rect2, 2);

            // Je te laisse ajouter les rectangles à la grille. Tu l'as déjà fait avant!
            // Je te laisse aussi ajouter l'évènement OnRectangleMouseClick à MouseLeftButtonDown au rectangle que tu viens de créer
            // Tu l'as déjà fait avant aussi, mais avec un clic sur un bouton..... pour devninner un chiffre.....
        }

        private void OnRectangleMouseClick(object sender, MouseButtonEventArgs e)
        {
            // Permet de savoir si le clic est sur un rectangle (transtypage)
            if (sender is Rectangle rect)
            {
                int row = Grid.GetRow(rect);
                int col = Grid.GetColumn(rect);
                // On va se créer une classe Coordinate pour stocker les coordonnées sélectionnées

                // si on clic sur une case vide la première fois on ajoute une petite animation: 
                rect.BeginAnimation(OpacityProperty, new DoubleAnimation(0.5, TimeSpan.FromSeconds(0.5)));
                // sinon, pour l'instant on ne fait rien
                // Plus tard, on va aller chercher la pièce dans le board avec les coordonnées row et col
                // et on va la déplacer
                RefreshUI();
            }
        }

        /// <summary>
        /// Je te fourni le code avec des commentaires.
        /// N'hésite pas à me demander si tu as des questions.
        /// Tu dois comprendre ce qui se passe, sans pour autant être en mesure d'écrire ce code toi-même.
        /// </summary>
        private void RefreshUI()
        {
            // Retire tous les TextBlock du board. Ce sont les pièces.
            GBoard.Children
                .OfType<TextBlock>()
                .ToList()
                .ForEach(x => GBoard.Children
                    .Remove(x));

            // On fait une boucle pour tous les rectangles du board
            // ça perment de remettre la couleur des cases à 1.0 (ne plus highlighter la case qu'on a sélectionné)
            foreach (var item in GBoard.Children)
            {
                if (item is Rectangle rectangle)
                {
                    rectangle.BeginAnimation(OpacityProperty, new DoubleAnimation(1.0, TimeSpan.FromSeconds(0.1)));
                }
            }

            // Pour toutes les cases, on va ajouter un TextBlock pour afficher les pièces s'il y en a une à afficher
            for (int x = 0; x < Constants.BOARD_SIZE; x++)
            {
                for (int y = 0; y < Constants.BOARD_SIZE; y++)
                {
                    // TODO décommenter
                    //APiece piece = _board.GetPiece(x, y);
                    //TextBlock textBlock = new TextBlock()
                    //{
                    //    FontSize = 36,
                    //    HorizontalAlignment = HorizontalAlignment.Center,
                    //    VerticalAlignment = VerticalAlignment.Center,
                    //    FontWeight = FontWeights.ExtraBold,
                    //    IsHitTestVisible = false // pour que le clic se rende jusqu'au rectangle
                    //};
                    //if (piece != null)
                    //{
                    //    textBlock.Text = piece.ToString();
                    //    textBlock.Foreground = piece.GetIsWhite() ? Brushes.White : Brushes.Black;
                    //    textBlock.Effect = new DropShadowEffect // permet de donner un effet de relief aux pièces
                    //    {
                    //        Color = Colors.Gray,
                    //        BlurRadius = 5,
                    //        ShadowDepth = 2,
                    //        Opacity = 0.5
                    //    };

                    //}

                    //Grid.SetRow(textBlock, x);
                    //Grid.SetColumn(textBlock, y);
                    //GBoard.Children.Add(textBlock);
                }
            }
        }
    }
}