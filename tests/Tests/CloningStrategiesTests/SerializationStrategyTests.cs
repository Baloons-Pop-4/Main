namespace Tests.CloningStrategiesTests
{
    using System;
    using System.Runtime.Serialization;

    using BalloonsPop.Core.Memento.CloningStrategies;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SerializationStrategyTests
    {
        private SerializableClass testObject;
        private NonSerializableClass testObject2;
        private SerializationCloning<SerializableClass> serializationCloning;
        private SerializationCloning<NonSerializableClass> serializationCloning2;

        public SerializationStrategyTests()
        {
        }

        [TestInitialize]
        public void TestInit()
        {
            this.testObject = new SerializableClass()
            {
                Field = 3,
                Field2 = "gosho",
                Field3 = new double[] { 1, 3.4, 5.1, -5.9, 1010101 }
            };

            this.serializationCloning = new SerializationCloning<SerializableClass>();
            this.serializationCloning2 = new SerializationCloning<NonSerializableClass>();
            this.testObject2 = new NonSerializableClass();
        }

        [TestMethod]
        public void TestIfSerializationCloningWorksWithSerializableClassWithFieldsIntStringAndDoubleArray()
        {
            var original = this.testObject;
            var cloned = this.serializationCloning.Clone(original);

            bool areSame = ReferenceEquals(cloned, original);
            bool areEqual = original.Equals(cloned);

            Assert.IsTrue(areEqual && !areSame);
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void TestIfCloneThrowsExceptionWithNonSerializableClass()
        {
            this.serializationCloning2.Clone(this.testObject2);
        }

        [TestMethod]
        public void TestIfIsMatchMethodReturnTrueWithSerializableClass()
        {
            Assert.IsTrue(this.serializationCloning.IsMatch(this.testObject));
        }

        [TestMethod]
        public void TestIfIsMatchMethodReturnFalseWithNonSerializableClass()
        {
            Assert.IsFalse(this.serializationCloning2.IsMatch(this.testObject2));
        }

        [Serializable]
        internal class SerializableClass
        {
            internal int Field;
            internal string Field2;
            internal double[] Field3;

            public override bool Equals(object obj)
            {
                if (obj as SerializableClass == null)
                {
                    return false;
                }

                var asSerializableClass = obj as SerializableClass;

                if (asSerializableClass.Field3.Length != this.Field3.Length)
                {
                    return false;
                }

                for (int i = 0, length = asSerializableClass.Field3.Length; i < length; i++)
                {
                    if (asSerializableClass.Field3[i] != this.Field3[i])
                    {
                        return false;
                    }
                }

                return asSerializableClass.Field == this.Field && asSerializableClass.Field2 == this.Field2;
            }
        }

        internal class NonSerializableClass
        {
        }
    }
}
