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
    public partial class MainWindow : Window//, IEventBasedUserInterface
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
                return this.StartGameButton;
            }
        }

        public Button ExitButton
        {
            get
            {
                return this.ExitButton;
            }
        }

        public string Message
        {
            get
            {
                return this.MessageContainer.Text;
            }

            set
            {
                this.MessageContainer.Text = value;
            }
        }

        public Grid Rankings
        {
            get
            {
                return this.HighscoreTable;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(348944);
        }
    }
}
