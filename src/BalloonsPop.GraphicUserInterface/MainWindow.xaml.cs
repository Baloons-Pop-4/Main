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
                return this.ExitBtn;
            }
        }

        public Button UndoButton
        {
            get
            {
                return this.UndoBtn;
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

        public string UserMoves
        {
            get
            {
                return this.UserMovesCount.Text;
            }

            set
            {
                this.UserMovesCount.Text = value;
            }
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown(348944);
        //}
    }
}
