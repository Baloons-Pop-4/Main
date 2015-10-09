namespace BalloonsPop.GraphicUserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The application's graphic interface model.
    /// </summary>
    public partial class BalloonsView : Window
    {
        public const string ExitButtonKey = "exit";
        public const string RestartButtonKey = "restart";
        public const string UndoButtonKey = "undo";

        private readonly IDictionary<string, Button> commandButtons;

        public BalloonsView()
        {
            this.InitializeComponent();
            this.commandButtons = new Dictionary<string, Button>()
            {
                { ExitButtonKey, this.ExitBtn },
                { RestartButtonKey, this.StartBtn },
                { UndoButtonKey, this.UndoBtn }
            };
        }

        /// <summary>
        /// Raises an event when the user clicks on one of the window's controls.
        /// </summary>
        public EventHandler Raise { get; set; }

        /// <summary>
        /// Provides readonly indexers access to the button controls of the current window's instance.
        /// </summary>
        public IDictionary<string, Button> CommandButtons
        {
            get
            {
                return this.commandButtons;
            }
        }

        /// <summary>
        /// Provides readonly access to the balloon field of the current window's instance.
        /// </summary>
        public Grid BalloonGrid
        {
            get
            {
                return this.BalloonField;
            }
        }

        /// <summary>
        /// Provides readonly access to the start button control.
        /// </summary>
        public Button StartButton
        {
            get
            {
                return this.commandButtons[RestartButtonKey];
            }
        }

        /// <summary>
        /// Provides readonly access to the exit button control.
        /// </summary>
        public Button ExitButton
        {
            get
            {
                return this.commandButtons[ExitButtonKey];
            }
        }

        /// <summary>
        /// Provides readonly access to the undo button control.
        /// </summary>
        public Button UndoButton
        {
            get
            {
                return this.commandButtons[UndoButtonKey];
            }
        }

        /// <summary>
        /// Provides get/set access to the message displayed to the user.
        /// </summary>
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

        /// <summary>
        /// Provides readonly access to the grid with rankings.
        /// </summary>
        public Grid Rankings
        {
            get
            {
                return this.HighscoreTable;
            }
        }

        /// <summary>
        /// Provides get/set access to the displayed user moves.
        /// </summary>
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
