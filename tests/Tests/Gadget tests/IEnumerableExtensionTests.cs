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
        public void ExecutingNullMethodOnCollectionShouldThrowNullReferenceException()
        {
            IEnumerable<byte> collection = new List<byte>();
            collection = null;
            Action<byte> action = null;

            IEnumerableExtensions.ForEach<byte>(collection, action);
        }
    }
}
