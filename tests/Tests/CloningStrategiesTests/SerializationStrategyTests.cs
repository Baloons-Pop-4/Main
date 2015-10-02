using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.CloningStrategiesTests
{
    using System.Runtime.Serialization;
    using BalloonsPop.Core.Memento.CloningStrategies;


    [TestClass]
    public class SerializationStrategyTests
    {
        [Serializable]
        internal class SerializableClass
        {
            internal int field;
            internal string field2;
            internal double[] field3;

            public override bool Equals(object obj)
            {
                if(obj as SerializableClass == null)
                {
                    return false;
                }

                var asSerializableClass = obj as SerializableClass;

                if(asSerializableClass.field3.Length != this.field3.Length)
                {
                    return false;
                }

                for (int i = 0, length = asSerializableClass.field3.Length; i < length; i++)
                {
                    if(asSerializableClass.field3[i] != this.field3[i])
                    {
                        return false;
                    }
                }

                return asSerializableClass.field == this.field && asSerializableClass.field2 == this.field2;
            }
        }

        internal class NonSerializableClass
        { }

        SerializableClass testObject;
        NonSerializableClass testObject2;
        SerializationCloning<SerializableClass> serializationCloning;
        SerializationCloning<NonSerializableClass> serializationCloning2;

        [TestInitialize]
        public void TestInit()
        {
            this.testObject = new SerializableClass()
            {
                field = 3,
                field2 = "gosho",
                field3 = new double[] { 1, 3.4, 5.1, -5.9, 1010101 }
            };

            this.serializationCloning = new SerializationCloning<SerializableClass>();
            this.serializationCloning2 = new SerializationCloning<NonSerializableClass>();
            this.testObject2 = new NonSerializableClass();
        }

        public SerializationStrategyTests()
        {
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
    }
}
