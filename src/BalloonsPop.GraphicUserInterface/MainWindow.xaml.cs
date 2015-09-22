using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BalloonsPop.GraphicUserInterface
{
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.GraphicUserInterface;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IEventBasedUserInterface
    {
        private const int BALLOON_IMG_HEIGHT = 40;
        private const int BALLOON_IMG_WIDTH = 30;

        private string[] colors = new string[] { "white", "red", "blue", "green", "yellow" };

        private string imageFolderPath;

        private string[,] sampleHighscoreChart = new string[,] { 
                                                                 {"Gosho", "20"},
                                                                 {"Bay Ivan", "28"},
                                                                 {"Mariya(umna e kato za jena)", "19"},
                                                                 {"Pesh0", "19"},
                                                                 {"Bate Borko", "20"}
                                                                };

        private Image[,] balloonField = new Image[5, 10];

        public event EventHandler Raise;

        public MainWindow()
        {
            InitializeComponent();



            this.InitializeImagePath();
            this.InitializeHighscoreGrid();
            this.InitializeBalloonField();
        }

        private void InitializeImagePath()
        {
            var currentDir = Environment.CurrentDirectory;

            imageFolderPath = currentDir.Substring(0, currentDir.IndexOf("bin"));
        }

        private void InitializeBalloonField()
        {
            for (int row = 0, rowsCount = 5; row < rowsCount; row++)
            {
                for (int col = 0, colsCount = 10; col < colsCount; col++)
                {
                    this.balloonField[row, col] = new Image();

                    var coordinatesAsString = row + " " + col;

                    this.balloonField[row, col].MouseDown += (sender, e) =>
                    {
                        this.Raise(sender, new ClickEventArgs(coordinatesAsString));
                    };

                    this.SetBalloonImageSize(this.balloonField[row, col]);
                    this.BalloonField.Children.Add(this.balloonField[row, col]);
                    this.SetPositionInGrid(this.balloonField[row, col], row, col);
                }
            }
        }

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
                    var sourceNumber = matrix[row, col].isPopped ? 0 : matrix[row, col].Number;
                    this.SetSource(this.balloonField[row, col], sourceNumber);
                }
            }
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

        public void PrintHighscore(string[,] highscore)
        {
            this.HighscoreTable.Children.RemoveRange(2, this.HighscoreTable.Children.Count - 2);
            for (int i = 1; i < highscore.GetLength(0); i++)
            {
                this.FillHighscoreGridRow("IMPLEMENT IN WPF PLZ :D", highscore[i - 1, 0], i);
            }
        }

        private void FillHighscoreGridRow(string playerName, string playerPoints, int row)
        {
            var wrappedPlayer = this.GetTextBlockWithBorder(playerName);
            var wrappedPoints = this.GetTextBlockWithBorder(playerPoints);

            this.HighscoreTable.Children.Add(wrappedPlayer);
            this.HighscoreTable.Children.Add(wrappedPoints);

            this.SetPositionInGrid(wrappedPlayer, row, 1);
            this.SetPositionInGrid(wrappedPoints, row, 2);
        }

        public string ReadUserInput()
        {
            var enterUserNameDialog = new PromptWindow();
            enterUserNameDialog.ShowDialog();

            return enterUserNameDialog.UserName;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var senderAsButton = sender as Button;

            senderAsButton.Content = "Restart";

            Raise(sender, new ClickEventArgs("RESTART"));
        }

        private void SetBalloonImageSize(Image img)
        {
            img.Height = BALLOON_IMG_HEIGHT;
            img.Width = BALLOON_IMG_WIDTH;
        }

        private void SetSource(Image img, int balloonNumber)
        {
            img.Source = new BitmapImage(new Uri(this.imageFolderPath + @"Images\" + this.colors[balloonNumber] + ".png"));
        }

        private void SetPositionInGrid(UIElement element, int row, int col)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, col);
        }

        private Border GetTextBlockWithBorder(string content)
        {
            var result = new Border();

            result.BorderThickness = new Thickness(1, 2, 1, 2);
            result.BorderBrush = Brushes.Coral;

            var textBlock = new TextBlock();
            textBlock.Text = content;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            result.Child = textBlock;

            return result;
        }
    }
}
