namespace BalloonsPop.Core
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Gadgets;
    using BalloonsPop.Core.Contexts;
    using BalloonsPop.Core.Memento;
    using BalloonsPop.Highscore;

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

        protected string[,] highScoreChart;

        protected IUserInputValidator validator;

        protected ICommandFactory commandFactory;

        protected IHighscoreHandlingStrategy highscoreHandlingStrategy;

        protected IContext context;

        protected EngineCore(ICoreBundle dependencyBundle)
            : this(
                   dependencyBundle.Printer,
                   dependencyBundle.UserInputValidator,
                   dependencyBundle.HighScoreTable,
                   dependencyBundle.HighscoreHandlingStrategy,
                   dependencyBundle.CommandFactory,
                   dependencyBundle.GameModel,
                   dependencyBundle.LogicProvider)
        {
        }

        protected EngineCore(
                            IPrinter printer,
                            IUserInputValidator validator,
                            IHighscoreTable highScoreTable,
                            IHighscoreHandlingStrategy highscoreHandlingStrategy,
                            ICommandFactory commandFactory,
                            IGameModel gameModel,
                            IGameLogicProvider gameLogicProvider)
        {
            this.context = new Context()
            {
                Printer = printer,
                Game = gameModel,
                HighscoreTable = highScoreTable,
                LogicProvider = gameLogicProvider,
                Memento = new Saver<IGameModel>(),
            };

            this.validator = validator;
            this.highscoreHandlingStrategy = highscoreHandlingStrategy;
            this.commandFactory = commandFactory;
        }

        protected virtual IList<ICommand> GetCommandList(string userCommand)
        {
            var commandList = new List<ICommand>();

            new Switch<string>(userCommand)
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
                                   this.highscoreHandlingStrategy.Save(this.context.HighscoreTable);
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

                                   var userRow = int.Parse(userCommand[0].ToString());
                                   var userColumn = int.Parse(userCommand[2].ToString());

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

                                   if (this.context.LogicProvider.GameIsOver(this.context.Game.Field))
                                   {
                                       this.context.Message = "Gratz, completed in " + this.context.Game.UserMovesCount + " moves.";
                                       if (this.context.HighscoreTable.CanAddPlayer(this.context.Game.UserMovesCount))
                                       {
                                           // TODO: Abstract to work with all types of UIs, not just the console?
                                           Console.WriteLine("Type in your name: ");
                                           string username = Console.ReadLine();

                                           this.context.HighscoreTable.AddPlayer(new PlayerScore(username, this.context.Game.UserMovesCount, DateTime.Now));
                                       }

                                       commandList.Add(this.commandFactory.CreateCommand("message"));
                                       commandList.Add(this.commandFactory.CreateCommand("restart"));
                                   }
                                   else
                                   {
                                       commandList.Add(this.commandFactory.CreateCommand("field"));
                                   }
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