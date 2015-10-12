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
        /// <summary>
        /// Key of the exit button.
        /// </summary>
        public const string ExitButtonKey = "exit";

        /// <summary>
        /// Key of the restart button.
        /// </summary>
        public const string RestartButtonKey = "restart";

        /// <summary>
        /// Key of the undo button.
        /// </summary>
        public const string UndoButtonKey = "undo";

        private readonly IDictionary<string, Button> commandButtons;

        /// <summary>
        /// Initializes a new instance of the <see cref="BalloonsView" /> class.
        /// </summary>
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
        /// Gets or sets an event when the user clicks on one of the window's controls.
        /// </summary>
        public EventHandler Raise { get; set; }

        /// <summary>
        /// Gets readonly indexers access to the button controls of the current window's instance.
        /// </summary>
        public IDictionary<string, Button> CommandButtons
        {
            get
            {
                return this.commandButtons;
            }
        }

        /// <summary>
        /// Gets access to the balloon field of the current window's instance.
        /// </summary>
        public Grid BalloonGrid
        {
            get
            {
                return this.BalloonField;
            }
        }

        /// <summary>
        /// Gets access to the start button control.
        /// </summary>
        public Button StartButton
        {
            get
            {
                return this.commandButtons[RestartButtonKey];
            }
        }

        /// <summary>
        /// Gets access to the exit button control.
        /// </summary>
        public Button ExitButton
        {
            get
            {
                return this.commandButtons[ExitButtonKey];
            }
        }

        /// <summary>
        /// Gets access to the undo button control.
        /// </summary>
        public Button UndoButton
        {
            get
            {
                return this.commandButtons[UndoButtonKey];
            }
        }

        /// <summary>
        /// Gets or sets an access to the message displayed to the user.
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
        /// Gets access to the grid with rankings.
        /// </summary>
        public Grid Rankings
        {
            get
            {
                return this.HighscoreTable;
            }
        }

        /// <summary>
        /// Gets a PlayerNicknameBox
        /// </summary>
        public TextBox PlayerNicknameBox
        {
            get
            {
                return this.PlayerNameBox;
            }
        }

        /// <summary>
        /// Gets or sets an access to the displayed user moves.
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
