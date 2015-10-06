namespace BalloonsPop.GraphicUserInterface
{
    using System;
using System.Collections.Generic;
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
        private const string ExitButtonKey = "exit";
        private const string RestartButtonKey = "restart";
        private const string UndoButtonKey = "undo";

        private readonly IDictionary<string, Button> commandButtons;

        public MainWindow()
        {
            this.InitializeComponent();
            this.commandButtons = new Dictionary<string, Button>()
            {
                { ExitButtonKey, this.ExitBtn },
                { RestartButtonKey, this.StartBtn },
                { UndoButtonKey, this.UndoBtn }
            };
        }

        public IDictionary<string, Button> CommandButtons
        {
            get
            {
                return this.commandButtons;
            }
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
                return this.commandButtons[RestartButtonKey];
            }
        }

        public Button ExitButton
        {
            get
            {
                return this.commandButtons[ExitButtonKey];
            }
        }

        public Button UndoButton
        {
            get
            {
                return this.commandButtons[UndoButtonKey];
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
    }
}
