namespace Tests
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Engine.Commands;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandTests
    {
        private ICommandFactory commandFactory;

        public CommandTests()
        {
            this.commandFactory = new CommandFactory();
        }

        [TestMethod]
        public void TestIfNonNullObjectIsReturnedWithValidCommandKey()
        {
            var commands = new string[] {"message", "exit", "undo", "pop", "restart", "field", "save", "top" };

            foreach (var key in commands)
            {
                var cmd = this.commandFactory.CreateCommand(key);

                Assert.AreNotEqual(null, cmd);
            }
        }

        [TestMethod]
        public void TestIfAnExceptionIsThrowWithInvalidCommandKeys()
        {
            var invalidKeys = new string[] { "jksdfjds", "redo", "quit", "pop_all", "cheat", "throw", "" };

            foreach (var key in invalidKeys)
            {
                try
                {
                    this.commandFactory.CreateCommand(key);
                }
                catch(ArgumentException)
                {
                    continue;
                }

                Assert.Fail();
            }
        }


    }
}