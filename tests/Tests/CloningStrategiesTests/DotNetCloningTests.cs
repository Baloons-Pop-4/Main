namespace Tests.CloningStrategiesTests
{
    using System;
    using System.Text;
    using BalloonsPop.Saver.CloningStrategies;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class DotNetCloningTests
    {
        private DotNetCloning<Object> cloning = new DotNetCloning<object>();
        [TestMethod]
        public void TestIfIsMatchReturnTrueWithTypeThatImplementsICloneable()
        {
            var moqCloneable = new Mock<ICloneable>();
            
            Assert.IsTrue(this.cloning.IsMatch(moqCloneable.Object));
        }

        [TestMethod]
        public void TestIfIsMatchReturnFalseWithTypeThatDoesntImplementsICloneable()
        {
            var notCLoneableObj = new StringBuilder();
            Assert.IsFalse(this.cloning.IsMatch(notCLoneableObj));
        }

        [TestMethod]
        public void TestIfCloneMethodUsesTheICloneablesInterfaceClone()
        {
            var moqCloneable = new Mock<ICloneable>();
            moqCloneable.Setup(x => x.Clone()).Returns(new object()).Verifiable();

            this.cloning.Clone(moqCloneable.Object);

            moqCloneable.Verify(x => x.Clone(), Times.Once);
        }
    }
}
