namespace BalloonsPop.Engine
{
    using System;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Common.Contracts;
    using System.Collections.Generic;
    using BalloonsPop.Engine.Memento;
    using BalloonsPop.Engine.Contexts;

    public class Engine
    {
        #region Constants
        protected const string EXIT = "EXIT";
        protected const string TOP = "TOP";
        protected const string RESTART = "RESTART";
        protected const string WRONG_INPUT = "Wrong input! Try Again!";
        protected const string CANNOT_POP_MISSING_BALLOON = "Cannot pop missing ballon!";
        protected const string WIN_MESSAGE_TEMPLATE = "Gratz ! You completed it in {0} moves.";
        protected const string NOT_IN_TOP_FIVE = "I am sorry you are not skillful enough for TopFive chart!";
        protected const string MOVE_PROMPT = "Enter a row and column: ";
        protected const string ON_EXIT_MESSAGE = "Good Bye!";
        #endregion

        protected string[,] highScoreChart;

        protected IUserInputValidator validator;

        protected ICommandFactory commandFactory;

        //private IGameModel game;

        //private IGameLogicProvider gameLogicProvider;

        //private IMemento<IGameModel> memento = new Memento<IGameModel>();

        protected IContext context;

        public Engine(IPrinter printer, IUserInputValidator validator, ICommandFactory commandFactory, IGameModel gameModel, IGameLogicProvider gameLogicProvider)
        {
            this.validator = validator;
            this.commandFactory = commandFactory;
            //this.game = gameModel;
            //this.gameLogicProvider = gameLogicProvider;
            this.highScoreChart = new string[2, 5];

            this.context = new Context()
            {
                Game = gameModel,
                LogicProvider = gameLogicProvider,
                Memento = new Saver<IGameModel>(),
                Printer = printer
            };
        }



        protected virtual IList<ICommand> GetCommandList(string userCommand)
        {
            var commandList = new List<ICommand>();

            new Switch<string>(userCommand)
                               .Case(RESTART, () =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("save"));
                                   commandList.Add(this.commandFactory.CreateCommand("restart"));
                                   commandList.Add(this.commandFactory.CreateCommand("field"));
                               })
                               .Case(TOP, () =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("highscore"));
                               })
                               .Case("UNDO", () =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("undo"));
                                   commandList.Add(this.commandFactory.CreateCommand("field"));
                               })
                               .Case(EXIT, () =>
                               {
                                   this.context.Message = ON_EXIT_MESSAGE;
                                   commandList.Add(this.commandFactory.CreateCommand("message"));
                                   commandList.Add(this.commandFactory.CreateCommand("exit"));
                               })
                               .Case(!this.validator.IsValidUserMove(userCommand), () =>
                               {
                                   this.context.Message = WRONG_INPUT;
                                   commandList.Add(this.commandFactory.CreateCommand("message"));
                               })
                               .Default(() =>
                               {
                                   commandList.Add(this.commandFactory.CreateCommand("save"));

                                   var userRow = int.Parse(userCommand[0].ToString());
                                   var userColumn = int.Parse(userCommand[2].ToString());

                                   if (this.context.Game.Field[userRow, userColumn].isPopped)
                                   {
                                       this.context.Message = CANNOT_POP_MISSING_BALLOON;
                                       commandList.Add(this.commandFactory.CreateCommand("message"));
                                   }
                                   else
                                   {
                                       this.context.UserRow = userRow;
                                       this.context.UserCol = userColumn;
                                       commandList.Add(this.commandFactory.CreateCommand("pop"));
                                   }

                                   if (this.context.LogicProvider.GameIsOver(this.context.Game.Field))
                                   {
                                       this.context.Message = "Gratz, completed in " + this.context.Game.UserMovesCount + " moves";
                                       commandList.Add(this.commandFactory.CreateCommand("message"));
                                       commandList.Add(this.commandFactory.CreateCommand("restart"));
                                   }
                                   else
                                   {
                                       commandList.Add(this.commandFactory.CreateCommand("field"));
                                   }
                               });

            //switch (userCommand)
            //{
            //    case RESTART:

            //        commandList.Add(this.commandFactory.CreateCommand("save"));
            //        commandList.Add(this.commandFactory.CreateCommand("restart"));
            //        commandList.Add(this.commandFactory.CreateCommand("field"));
            //        break;

            //    case TOP:
            //        commandList.Add(this.commandFactory.CreateCommand("highscore"));
            //        break;

            //    case EXIT:
            //        this.context.Message = ON_EXIT_MESSAGE;
            //        commandList.Add(this.commandFactory.CreateCommand("message"));
            //        commandList.Add(this.commandFactory.CreateCommand("exit"));

            //        break;

            //    case "UNDO":

            //        commandList.Add(this.commandFactory.CreateCommand("undo"));
            //        commandList.Add(this.commandFactory.CreateCommand("field"));
            //        break;

            //    default:
            //        commandList.Add(this.commandFactory.CreateCommand("save"));

            //        if (!this.validator.IsValidUserMove(userCommand))
            //        {
            //            this.context.Message = WRONG_INPUT;
            //            commandList.Add(this.commandFactory.CreateCommand("message"));
            //            break;
            //        }

            //        var userRow = int.Parse(userCommand[0].ToString());
            //        var userColumn = int.Parse(userCommand[2].ToString());

            //        if (this.context.Game.Field[userRow, userColumn] == 0)
            //        {
            //            this.context.Message = CANNOT_POP_MISSING_BALLOON;
            //            commandList.Add(this.commandFactory.CreateCommand("message"));
            //        }
            //        else
            //        {
            //            this.context.UserRow = userRow;
            //            this.context.UserCol = userColumn;
            //            commandList.Add(this.commandFactory.CreateCommand("pop"));
            //        }

            //        if (this.context.LogicProvider.GameIsOver(this.context.Game.Field))
            //        {
            //            this.context.Message = "Gratz, completed in " + this.context.Game.UserMovesCount + " moves";
            //            commandList.Add(this.commandFactory.CreateCommand("message"));
            //            commandList.Add(this.commandFactory.CreateCommand("restart"));
            //        }
            //        else
            //        {
            //            commandList.Add(this.commandFactory.CreateCommand("field"));
            //        }

            //        break;
            //}

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