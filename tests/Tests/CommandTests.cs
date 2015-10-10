namespace Tests
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.Core.Contexts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
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
                catch (Exception)
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
            var mockLogic = new Mock<IGameLogicProvider>();
            mockLogic.Setup(x => x.PopBalloons(It.IsAny<IBalloon[,]>(), It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            var mockGame = new Mock<IGameModel>();
            mockGame.Setup(x => x.Field).Verifiable();

            var context = new Context() 
            {
                LogicProvider = mockLogic.Object,
                Game = mockGame.Object
            };

            var popCmd = this.commandFactory.CreateCommand("pop");

            popCmd.Execute(context);

            mockLogic.Verify(x => x.PopBalloons(It.IsAny<IBalloon[,]>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockLogic.Verify(x => x.LetBalloonsFall(It.IsAny<IBalloon[,]>()), Times.Once);
            mockGame.Verify(x => x.Field, Times.Once);
        }

        [TestMethod]
        public void TestIfRestartCommandCallsTheNeededMethodsFromGameModelAndGameLogic()
        {
            var moqGame = new Mock<IGameModel>();
            moqGame.Setup(x => x.ResetUserMoves()).Verifiable();
            moqGame.SetupGet<IBalloon[,]>(x => x.Field).Returns(() => new IBalloon[5, 10]).Verifiable();
            var moqLogic = new Mock<IGameLogicProvider>();
            moqLogic.Setup(x => x.RandomizeBalloonField(It.IsAny<IBalloon[,]>())).Verifiable();
           
            var ctx = new Context()
            {
                Game = moqGame.Object,
                LogicProvider = moqLogic.Object
            };

            new RestartCommand().Execute(ctx);

            moqGame.Verify(x => x.ResetUserMoves(), Times.Once, "2 or 0");
            moqLogic.Verify(x => x.RandomizeBalloonField(It.IsAny<IBalloon[,]>()), Times.Once, "no msg 4 u betch");
        }

        [TestMethod]
        public void TestIfPrintFieldCommandCallsThePrintFieldMethodOfTheUI()
        {
            var moqPrinter = new Mock<IPrinter>();
            moqPrinter.Setup(x => x.PrintField(It.IsAny<IBalloon[,]>())).Verifiable();
            var moqGame = new Mock<IGameModel>();
            moqGame.SetupGet<IBalloon[,]>(x => x.Field).Verifiable();
            this.context = new Context() { Printer = moqPrinter.Object, Game = moqGame.Object };

            var printFieldCommand = this.commandFactory.CreateCommand("field");

            printFieldCommand.Execute(this.context);

            moqPrinter.Verify(x => x.PrintField(It.IsAny<IBalloon[,]>()), Times.Once);

            // Assert.AreEqual(1, (this.context.Printer as MockPrinter).MethodCallCounts["field"]);
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