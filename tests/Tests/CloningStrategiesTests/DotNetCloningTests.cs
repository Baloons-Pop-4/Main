using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CloningStrategiesTests
{
    using BalloonsPop.Core.Memento.CloningStrategies;

    [TestClass]
    public class DotNetCloningTests
    {
        internal class NonCloneableClass
        { }

        internal class CloneableClass : ICloneable
        {
            public object Clone()
            {
                return new CloneableClass();
            }
        }

        DotNetCloning<CloneableClass> cloning;
        DotNetCloning<NonCloneableClass> invalidCloning;
        CloneableClass testObject;
        NonCloneableClass nonCloneableTestObject;

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
            Assert.IsTrue(this.cloning.IsMatch(testObject));
        }

        [TestMethod]
        public void TestIfIsMatchReturnFalseWithTypeThatDoesntImplementsICloneable()
        {
            Assert.IsFalse(this.invalidCloning.IsMatch(nonCloneableTestObject));
        }
    }
}
