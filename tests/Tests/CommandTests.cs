namespace Tests
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Core.Commands;
    using BalloonsPop.Core.Contexts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using BalloonsPop.Highscore;
    using BalloonsPop.GameModels;

    [TestClass]
    public class CommandTests
    {
        private ICommandFactory commandFactory;

        private IContext context;

        [TestInitialize]
        public void TestInit()
        {
            this.commandFactory = new CommandFactory();
        }

        [TestMethod]
        public void TestIfContainsKeyReturnsTrueWhenCommandWithGivenKeyHasBeenAdded()
        {
            this.commandFactory.RegisterCommand("gosho", () => null);
            Assert.IsTrue(this.commandFactory.ContainsKey("gosho"));
        }

        [TestMethod]
        public void TestIfCountainsKeyReturnFalseWhenNoSuchCommandKeyIsRegistered()
        {
            Assert.IsFalse(this.commandFactory.ContainsKey("sdfdsf"));
        }

        [TestMethod]
        public void TestIfNonNullObjectIsReturnedWithValidCommandKey()
        {
            var commands = new string[] { "message", "undo", "pop", "restart", "field", "save", "top" };

            foreach (var key in commands)
            {
                var cmd = this.commandFactory.CreateCommand(key);

                Assert.IsNotNull(cmd);
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
        public void TestIfUnregisterRemovesTheCommandWithTheProvidedKey()
        {
            this.commandFactory.RegisterCommand("minko donchov", () => new RestartCommand());
            this.commandFactory.UnregisterCommand("minko donchov");
            Assert.IsFalse(this.commandFactory.ContainsKey("minko donchov"));
        }

        [TestMethod]
        public void TestIfPopBalloonsCommandCallsTheNeededMethodsFromGameModelAndGameLogic()
        {
            var mockLogic = new Mock<IGameLogicProvider>();
            mockLogic.Setup(x => x.PopBalloons(It.IsAny<IBalloon[,]>(), It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            var mockGame = new Mock<IGameModel>();
            mockGame.SetupGet<IBalloon[,]>(x => x.Field).Returns(() => new IBalloon[5, 10]).Verifiable();

            var context = new Context() 
            {
                LogicProvider = mockLogic.Object,
                Game = mockGame.Object
            };

            var popCmd = new PopBalloonCommand();

            popCmd.Execute(context);

            mockLogic.Verify(x => x.PopBalloons(It.IsAny<IBalloon[,]>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            mockLogic.Verify(x => x.LetBalloonsFall(It.IsAny<IBalloon[,]>()), Times.Once);
            //mockGame.Verify(x => x.Field, Times.Once);
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
        public void TestIfAddHighscoreCommandAddsNewPlayerScoreToHighscoreTableInContext()
        {
            var ctx = new Context() 
            {
                HighscoreTable = new HighscoreTable(),
                PlayerName = "Gosho",
                Game = new GameModel()
            };

            new AddPlayerscoreCommand().Execute(ctx);

            Assert.AreEqual("Gosho", ctx.HighscoreTable.Table[0].Name);
        }

        [TestMethod]
        public void TestIfPrintHighscoreCommandCallsThePrintHighscoreMethodOfTheUI()
        {
            var moqPrinter = new Mock<IPrinter>();
            moqPrinter.Setup(x => x.PrintHighscore(It.IsAny<IHighscoreTable>())).Verifiable();

            this.context = new Context() { Printer = moqPrinter.Object };

            var printHighscoreCommand = this.commandFactory.CreateCommand("top");

            printHighscoreCommand.Execute(this.context);

            moqPrinter.Verify(x => x.PrintHighscore(It.IsAny<IHighscoreTable>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void TestIfPrintMessageCommandCallsThePrintMessageMethodOfTheUI()
        {
            var moqPrinter = new Mock<IPrinter>();
            moqPrinter.Setup(x => x.PrintMessage(It.Is<string>(a => a == "gosho"))).Verifiable();
            this.context = new Context() { Printer = moqPrinter.Object, Message = "gosho" };

            var printMessageCommand = this.commandFactory.CreateCommand("message");

            printMessageCommand.Execute(this.context);

            moqPrinter.Verify(x => x.PrintMessage(It.Is<string>(a => a == "gosho")), Times.Once);
        }

        [TestMethod]
        public void TestIfSaveHighscoreCallsTheSaveMethodOfTheSavingStrategy()
        {
            var moqHighsoreSaver = new Mock<IHighscoreHandlingStrategy>();
            moqHighsoreSaver.Setup(x => x.Save(It.IsAny<IHighscoreTable>())).Verifiable();

            var ctx = new Context()
            {
                HighscoreHandling = moqHighsoreSaver.Object
            };

            new SaveHighscoreCommand().Execute(ctx);

            moqHighsoreSaver.Verify(x => x.Save(It.IsAny<IHighscoreTable>()), Times.Once);
        }

        //[TestMethod]
        //public void TestIfSaveCommandUsesTheMementoSetter()
        //{
        //    this.context = new Context() { Game = new GameMock(), Memento = new MockSaver() };

        //    var saveCommand = this.commandFactory.CreateCommand("save");

        //    saveCommand.Execute(this.context);

        //    Assert.AreEqual(1, (this.context.Memento as MockSaver).CallsToSetCount);
        //}
    }
}