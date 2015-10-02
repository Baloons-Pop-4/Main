using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CloningStrategiesTests
{
    using BalloonsPop.Core.Memento.CloningStrategies;

    [TestClass]
    public class ReflectionCloningTests
    {
        internal class ClasWithEmptyConstructor
        {
            public ClasWithEmptyConstructor()
            {

            }
        }

        internal class ClassWithNoEmptyConstructor
        {
            public ClassWithNoEmptyConstructor(bool someVariable)
            {}
        }

        ReflectionCloning<ClasWithEmptyConstructor> validReflectionCloning;
        ReflectionCloning<ClassWithNoEmptyConstructor> invalidReflectionCloning;

        ClasWithEmptyConstructor validTestObj;
        ClassWithNoEmptyConstructor invalidTestObj;

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
    }
}
