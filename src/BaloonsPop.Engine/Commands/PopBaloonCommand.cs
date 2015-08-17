namespace BaloonsPop.Engine.Commands
{
    using Common.Validators;

    public class PopBaloonCommand : GameCommand
    {
        private GameLogic gameLogicProvider;

        private IUserInputValidator validator;

        private string rawCommand;

        private int row;

        private int col;

        private bool inputIsValid;

        public PopBaloonCommand(Game gameModel, GameLogic gameLogicProvider, IUserInputValidator validator, string commandLine) 
            : base(gameModel)
        {
            this.gameLogicProvider = gameLogicProvider;
            this.validator = validator;
            this.rawCommand = commandLine;
        }

        public override void Execute()
        {
            if(!this.inputIsValid)
            {
                return;
            }

        }

        private void TryParseUserInput()
        {
            if(!validator.IsValidUserMove(rawCommand))
            {
                this.inputIsValid = false;

                return;
            }

            bool rowParsedSuccessfully = int.TryParse(this.rawCommand[0].ToString(), out this.row);

            bool colParsedSuccessfully = int.TryParse(this.rawCommand[2].ToString(), out this.col);

            this.inputIsValid = rowParsedSuccessfully && colParsedSuccessfully;
        }
    }
}