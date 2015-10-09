namespace Tests.Gadget_tests
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Gadgets;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IEnumerableExtensionTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
        "Cannot foreach null collection.")]
        public void ForeachOfNullCollectionShouldThrowNullReferenceException()
        {
            IEnumerable<byte> collection = new List<byte>();
            collection = null;
            Action<byte> action = null;

            IEnumerableExtensions.ForEach<byte>(collection, action);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
        "Cannot execute null method on a collection.")]
        public void ExecutingNullActionOnCollectionShouldThrowNullReferenceException()
        {
            IEnumerable<byte> collection = new List<byte> { 1, 2, 3, 4 };
            Action<byte> action = null;

            IEnumerableExtensions.ForEach<byte>(collection, action);
        }

        [TestMethod]
        public void ExecutingNotNullActionOnCollectionShouldNotBeNull()
        {
            IEnumerable<byte> collection = new List<byte> { 1, 2, 3, 4, 5, 6 };
            Action<byte> action = x => x++;

            IEnumerableExtension.ForEach<byte>(collection, action);

            Assert.IsNotNull(collection);
        }

        [TestMethod]
        public void ExecutingActionOnCollectionShouldWorkProperly()
        {
            var collection = new List<byte> { 1, 2, 3, 4, 5, 6 };
            var collection2 = new List<byte>();
            Action<byte> action = x => collection2.Add(x);

            IEnumerableExtension.ForEach<byte>(collection, action);

            Assert.AreEqual(collection.Count, collection2.Count);

            for (int i = 0, length = collection.Count; i < length; i++)
            {
                Assert.AreEqual(collection[i], collection2[i]);
            }
        }
    }
}
