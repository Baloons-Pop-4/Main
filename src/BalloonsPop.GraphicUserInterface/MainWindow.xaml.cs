namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.GraphicUserInterface.Contracts;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IEventBasedUserInterface
    {
        private const int BalloonImgHeight = 40;
        private const int BalloonImgWidth = 30;

        private readonly string[] colors = new string[] { "white", "red", "blue", "green", "yellow" };

        private string imageFolderPath;

        // private string userName;
        private Image[,] balloonField;

        public MainWindow()
        {
            this.InitializeComponent();

            // this.userName = this.ReadUserInput();
            this.InitializeImagePath();
            this.InitializeHighscoreGrid();
            this.balloonField = this.GetInitializedBalloonField();
        }

        public Grid BalloonGrid
        {
            get
            {
                return this.BalloonField;
            }
        }

        public Button StartButton
        {
            get
            {
                return this.StartButton;
            }
        }

        public Button ExitButton
        {
            get
            {
                return this.ExitButton;
            }
        }

        public event EventHandler Raise;

        public void PrintMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void PrintField(IBalloon[,] matrix)
        {
            for (int row = 0, rowsCount = matrix.GetLength(0); row < rowsCount; row++)
            {
                for (int col = 0, colsCount = matrix.GetLength(1); col < colsCount; col++)
                {
                    var sourceNumber = matrix[row, col].IsPopped ? 0 : matrix[row, col].Number;
                    this.SetSource(this.balloonField[row, col], sourceNumber);
                }
            }
        }

        public string ReadUserInput()
        {
            var enterUserNameDialog = new PromptWindow();
            enterUserNameDialog.ShowDialog();

            return enterUserNameDialog.UserName;
        }

        public void PrintHighscore(IHighscoreTable table)
        {
            // TODO: Implement this method
            throw new NotImplementedException("Implement highscore printing, u lazy ginger");
        }

        private void InitializeImagePath()
        {
            var currentDir = Environment.CurrentDirectory;

            this.imageFolderPath = currentDir.Substring(0, currentDir.IndexOf("bin"));
        }

        private Image[,] GetInitializedBalloonField()
        {
            var field = new Image[5, 10];

            for (int row = 0, rowsCount = 5; row < rowsCount; row++)
            {
                for (int col = 0, colsCount = 10; col < colsCount; col++)
                {
                    this.InitializeImageFielCell(row, col, field);
                }
            }

            return field;
        }

        private void InitializeImageFielCell(int row, int col, Image[,] field)
        {
            field[row, col] = new Image();

            var coordinatesAsString = row + " " + col;

            field[row, col].MouseDown += (sender, e) =>
            {
                this.Raise(sender, new ClickEventArgs(coordinatesAsString));
            };

            this.SetBalloonImageSize(field[row, col]);
            this.BalloonField.Children.Add(field[row, col]);
            this.SetPositionInGrid(field[row, col], row, col);
        }

        private void InitializeHighscoreGrid()
        {
            var wrappedPlayer = this.GetTextBlockWithBorder("Player");
            var wrappedPoints = this.GetTextBlockWithBorder("Points");

            this.HighscoreTable.Children.Add(wrappedPlayer);
            this.SetPositionInGrid(wrappedPlayer, 0, 1);

            this.HighscoreTable.Children.Add(wrappedPoints);
            this.SetPositionInGrid(wrappedPoints, 0, 2);
        }

        private void FillHighscoreGridRow(string playerName, string playerPoints, int row)
        {
            this.FillHighscoreGridField(playerName, row, 1);
            this.FillHighscoreGridField(playerPoints, row, 2);
        }

        private void FillHighscoreGridField(string content, int row, int col)
        {
            var wrappedPlayer = this.GetTextBlockWithBorder(content);
            this.HighscoreTable.Children.Add(wrappedPlayer);
            this.SetPositionInGrid(wrappedPlayer, row, col);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var senderAsButton = sender as Button;

            senderAsButton.Content = "Restart";

            this.Raise(sender, new ClickEventArgs("RESTART"));
        }

        private void SetBalloonImageSize(Image img)
        {
            img.Height = BalloonImgHeight;
            img.Width = BalloonImgWidth;
        }

        private void SetSource(Image img, int balloonNumber)
        {
            var uri = this.GetBalloonImageUri(this.colors[balloonNumber]);
            img.Source = new BitmapImage(uri);
            this.GetBalloonImageUri("white");
        }

        private Uri GetBalloonImageUri(string color)
        {
            var uri = new Uri(this.imageFolderPath + @"Images\" + color + ".png");
            return uri;
        }

        private void SetPositionInGrid(UIElement element, int row, int col)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, col);
        }

        private Border GetTextBlockWithBorder(string content)
        {
            return this.AddTextBlockToBorder(this.GetBorder(), content);
        }

        private Border GetBorder()
        {
            var result = new Border();

            result.BorderThickness = new Thickness(1, 2, 1, 2);
            result.BorderBrush = Brushes.Coral;

            return result;
        }

        private Border AddTextBlockToBorder(Border border, string content)
        {
            var textBlock = new TextBlock();
            textBlock.Text = content;
            this.StyleTextBlock(textBlock);
            border.Child = textBlock;

            return border;
        }

        private void StyleTextBlock(TextBlock block)
        {
            block.TextAlignment = TextAlignment.Center;
            block.VerticalAlignment = System.Windows.VerticalAlignment.Center;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(348944);
        }
    }
}
