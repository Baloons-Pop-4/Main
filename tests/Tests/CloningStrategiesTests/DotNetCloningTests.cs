namespace Tests.CloningStrategiesTests
{
    using System;

    using BalloonsPop.Saver.CloningStrategies;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DotNetCloningTests
    {
        private DotNetCloning<CloneableClass> cloning;
        private DotNetCloning<NonCloneableClass> invalidCloning;
        private CloneableClass testObject;
        private NonCloneableClass nonCloneableTestObject;

        [TestInitialize]
        public void TestInit()
        {
            this.cloning = new DotNetCloning<CloneableClass>();
            this.invalidCloning = new DotNetCloning<NonCloneableClass>();
            this.testObject = new CloneableClass();
            this.nonCloneableTestObject = new NonCloneableClass();
        }

        [TestMethod]
        public void TestIfIsMatchReturnTrueWithTypeThatImplementsICloneable()
        {
            Assert.IsTrue(this.cloning.IsMatch(this.testObject));
        }

        [TestMethod]
        public void TestIfIsMatchReturnFalseWithTypeThatDoesntImplementsICloneable()
        {
            Assert.IsFalse(this.invalidCloning.IsMatch(this.nonCloneableTestObject));
        }

        internal class NonCloneableClass
        {
        }

        internal class CloneableClass : ICloneable
        {
            public object Clone()
            {
                return new CloneableClass();
            }
        }
    }
}
