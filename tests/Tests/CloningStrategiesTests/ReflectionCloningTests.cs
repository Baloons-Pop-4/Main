namespace Tests.CloningStrategiesTests
{
    using System;

    using BalloonsPop.Core.Memento.CloningStrategies;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReflectionCloningTests
    {
        private ReflectionCloning<ClasWithEmptyConstructor> validReflectionCloning;
        private ReflectionCloning<ClassWithNoEmptyConstructor> invalidReflectionCloning;

        private ClasWithEmptyConstructor validTestObj;
        private ClassWithNoEmptyConstructor invalidTestObj;

        [TestInitialize]
        public void TestInit()
        {
            this.validReflectionCloning = new ReflectionCloning<ClasWithEmptyConstructor>();
            this.invalidReflectionCloning = new ReflectionCloning<ClassWithNoEmptyConstructor>();

            this.validTestObj = new ClasWithEmptyConstructor();
            this.invalidTestObj = new ClassWithNoEmptyConstructor(true);
        }

        [TestMethod]
        public void TestIfIsMatchReturnsTrueForTypesWithEmptyConstructor()
        {
            Assert.IsTrue(this.validReflectionCloning.IsMatch(this.validTestObj));
        }

        [TestMethod]
        public void TestIfIsMatchReturnsFalseForTypesWithNoEmptyConstructor()
        {
            Assert.IsFalse(this.invalidReflectionCloning.IsMatch(this.invalidTestObj));
        }

        internal class ClasWithEmptyConstructor
        {
            public ClasWithEmptyConstructor()
            {
            }
        }

        internal class ClassWithNoEmptyConstructor
        {
            public ClassWithNoEmptyConstructor(bool someVariable)
            {
            }
        }
    }
}
