namespace BalloonsPop.Core
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    public class EngineCore
    {
        #region Constants
        protected const string Exit = "EXIT";
        protected const string Top = "TOP";
        protected const string Restart = "RESTART";
        protected const string WrongInputMessage = "Wrong input! Try Again!";
        protected const string CannotPopMissingBalloonMessage = "Cannot pop missing ballon!";
        protected const string WinMessageTemplate = "Gratz ! You completed it in {0} moves.";
        protected const string NotInTopFiveMessage = "I am sorry you are not skillful enough for TopFive chart!";
        protected const string MovePrompt = "Enter a row and column: ";
        protected const string OnExitMessage = "Good Bye!";
        #endregion

        private IUserInputValidator validator;

        private ICommandFactory commandFactory;

        private IContext context;

        protected EngineCore(IContext ctx, IUserInputValidator inputValidator, ICommandFactory cmdFactory)
        {
            this.Context = ctx;
            this.Validator = inputValidator;
            this.commandFactory = cmdFactory;
            this.Context.LogicProvider.RandomizeBalloonField(this.Context.Game.Field);   
        }

        protected IContext Context
        {
            get
            {
                return this.context;
            }
            set
            {
                this.context = value;
            }
        }

        protected ICommandFactory CommandFactory
        {
            get
            {
                return this.commandFactory;
            }
            set
            {
                this.commandFactory = value;
            }
        }

        protected IUserInputValidator Validator
        {
            get
            {
                return this.validator;
            }
            set
            {
                this.validator = value;
            }
        }

        protected virtual IList<ICommand> GetCommandList(string userCommand)
        {
            var commandList = new List<ICommand>();

            new Switch<string>(userCommand.ToUpper())
                               .Case(
                               Restart,
                               () =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("save"));
                                   commandList.Add(this.commandFactory.CreateCommand("restart"));
                                   commandList.Add(this.commandFactory.CreateCommand("field"));
                               })
                               .Case(
                               Top,
                               () =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("top"));
                               })
                               .Case(
                               "UNDO",
                               () =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("undo"));
                                   commandList.Add(this.commandFactory.CreateCommand("field"));
                               })
                               .Case(
                               Exit,
                               () =>
                               {
                                   this.context.Message = OnExitMessage;
                                   commandList.Add(this.commandFactory.CreateCommand("message"));
                                   commandList.Add(this.commandFactory.CreateCommand("exit"));
                                   this.Context.HighscoreHandling.Save(this.context.HighscoreTable);
                               })
                               .Case(
                               !this.validator.IsValidUserMove(userCommand), 
                               () =>
                               {
                                   this.context.Message = WrongInputMessage;
                                   commandList.Add(this.commandFactory.CreateCommand("message"));
                               })
                               .Default(() =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("save"));

                                   var userRow = userCommand[0].ToInt32();
                                   var userColumn = userCommand[2].ToInt32();

                                   if (this.context.Game.Field[userRow, userColumn].IsPopped)
                                   {
                                       this.context.Message = CannotPopMissingBalloonMessage;
                                       commandList.Add(this.commandFactory.CreateCommand("message"));
                                   }
                                   else
                                   {
                                       this.context.UserRow = userRow;
                                       this.context.UserCol = userColumn;
                                       commandList.Add(this.commandFactory.CreateCommand("pop"));
                                   }

                                   commandList.Add(this.commandFactory.CreateCommand("gameover"));
                                   commandList.Add(this.commandFactory.CreateCommand("field"));
                               });

            return commandList;
        }

        protected virtual void ExecuteCommandList(IList<ICommand> commandList)
        {
            foreach (var command in commandList)
            {
                command.Execute(this.context);
            }
        }
    }
}