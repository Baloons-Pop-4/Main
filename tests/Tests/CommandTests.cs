namespace Tests
{
    using System;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.Core.Contexts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tests.MockClasses;

    [TestClass]
    public class CommandTests
    {
        private ICommandFactory commandFactory;

        private IContext context;

        public CommandTests()
        {
            this.commandFactory = new CommandFactory();
        }

        [TestMethod]
        public void TestIfNonNullObjectIsReturnedWithValidCommandKey()
        {
            var commands = new string[] { "message", "exit", "undo", "pop", "restart", "field", "save", "top" };

            foreach (var key in commands)
            {
                var cmd = this.commandFactory.CreateCommand(key);

                Assert.AreNotEqual(null, cmd);
            }
        }

        [TestMethod]
        public void TestIfAnExceptionIsThrowWithInvalidCommandKeys()
        {
            var invalidKeys = new string[] { "jksdfjds", "redo", "quit", "pop_all", "cheat", "throw", string.Empty };

            foreach (var key in invalidKeys)
            {
                try
                {
                    this.commandFactory.CreateCommand(key);
                }
                catch (ArgumentException)
                {
                    continue;
                }

                Assert.Fail();
            }
        }

        [TestMethod]
        [Ignore]
        public void TestIfPopBalloonsCommandCallsTheNeededMethodsFromGameModelAndGameLogic()
        {
            var mockLogic = new MockLogic();
            var mockGame = new GameMock();

            var context = new Context() 
            {
                LogicProvider = mockLogic,
                Game = mockGame
            };

            var popCmd = this.commandFactory.CreateCommand("pop");

            popCmd.Execute(context);

            Assert.AreEqual(1, mockLogic.Calls["PopBalloons"]);
            Assert.AreEqual(1, mockLogic.Calls["LetBalloonsFall"]);
            Assert.AreEqual(1, mockGame.Calls["IncrementMoves"]);
        }

        [TestMethod]
        public void TestIfRestartCommandCallsTheNeededMethodsFromGameModelAndGameLogic()
        {
            var mockLogic = new MockLogic();
            var mockGame = new GameMock();

            var context = new Context() 
            {
                LogicProvider = mockLogic,
                Game = mockGame
            };
            this.commandFactory.UnregisterCommand("restart");
            this.commandFactory.RegisterCommand("restart", () => new RestartCommand());
            var restartCmd = this.commandFactory.CreateCommand("restart");

            restartCmd.Execute(context);

            Assert.AreEqual(1, mockLogic.Calls["GenerateField"]);
            Assert.AreEqual(1, mockGame.Calls["ResetMoves"]);
        }

        [TestMethod]
        public void TestIfPrintFieldCommandCallsThePrintFieldMethodOfTheUI()
        {
            this.context = new Context() { Printer = new MockPrinter(), Game = new GameMock() };

            var printFieldCommand = this.commandFactory.CreateCommand("field");

            printFieldCommand.Execute(this.context);

            Assert.AreEqual(1, (this.context.Printer as MockPrinter).MethodCallCounts["field"]);
        }

        [TestMethod]
        public void TestIfPrintHighscoreCommandCallsThePrintHighscoreMethodOfTheUI()
        {
            this.context = new Context() { Printer = new MockPrinter(), Game = new GameMock() };

            var printHighscoreCommand = this.commandFactory.CreateCommand("top");

            printHighscoreCommand.Execute(this.context);

            Assert.AreEqual(1, (this.context.Printer as MockPrinter).MethodCallCounts["highscore"]);
        }

        [TestMethod]
        public void TestIfPrintMessageCommandCallsThePrintMessageMethodOfTheUI()
        {
            this.context = new Context() { Printer = new MockPrinter(), Game = new GameMock() };

            var printMessageCommand = this.commandFactory.CreateCommand("message");

            printMessageCommand.Execute(this.context);

            Assert.AreEqual(1, (this.context.Printer as MockPrinter).MethodCallCounts["message"]);
        }

        [TestMethod]
        public void TestIfSaveCommandUsesTheMementoSetter()
        {
            this.context = new Context() { Game = new GameMock(), Memento = new MockSaver() };

            var saveCommand = this.commandFactory.CreateCommand("save");

            saveCommand.Execute(this.context);

            Assert.AreEqual(1, (this.context.Memento as MockSaver).CallsToSetCount);
        }
    }
}