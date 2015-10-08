namespace BalloonsPop.Core
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;

    using BalloonsPop.Core.Gadgets;

    public class EngineCore
    {
        #region Constants
        protected const string WrongInputMessage = "Wrong input! Try Again!";
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

            bool isValidPopMove = this.validator.IsValidUserMove(userCommand)
                                    && !this.Context.Game.At(userCommand).IsPopped;

            if (isValidPopMove)
            {
                commandList.Add(this.commandFactory.CreateCommand("save"));

                this.context.UserRow = userCommand[0].ToInt32();
                this.context.UserCol = userCommand[2].ToInt32();
                commandList.Add(this.commandFactory.CreateCommand("pop"));


                commandList.Add(this.commandFactory.CreateCommand("gameover"));
                commandList.Add(this.commandFactory.CreateCommand("field"));
            }
            else if (this.CommandFactory.ContainsKey(userCommand.ToLower()))
            {
                commandList.Add(this.CommandFactory.CreateCommand(userCommand.ToLower()));
            }
            else
            {
                this.context.Message = WrongInputMessage;
                commandList.Add(this.commandFactory.CreateCommand("message"));
            }

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