using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Gadget_tests
{
    using BalloonsPop.Common.Gadgets;

    [TestClass]
    public class FluentSwitchTest
    {
        Switch<string> fluentSwitch;

        [TestMethod]
        public void TestIfSwitchMatchesWithValuesOfTheSameType()
        {
            bool called = false;

            new Switch<string>("stringy")
                .Case("pesho", () => { })
                .Case("string", () => { })
                .Case("strng", () => { })
                .Case("stringy", () => { called = true; })
                .Default(() => { called = false; });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void TestIfSwitchMatchesWithBooleanValues()
        {
            bool called = false;

            new Switch<string>("stringy")
                .Case(false, () => { })
                .Case(called, () => { })
                .Case(3 % 2 == 5, () => { })
                .Case("stringy".Length == 7, () => { called = true; })
                .Default(() => { called = false; });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void TestIfSwitchMatchesWithPredicates()
        {
            bool called = false;

            new Switch<string>("stringy")
                .Case(arg => arg.Length == 1, () => { })
                .Case(arg => 3 % 2 == 5, () => { })
                .Case(arg => false, () => { })
                .Case(arg => arg.Length == 7, () => { called = true; })
                .Default(() => { called = false; });

            Assert.IsTrue(called);
        }

        [TestMethod]
        public void TestIfSwitchCallsDefaultCaseWhenNoMatchesOccur()
        {
            bool defaultCalled = false;

            new Switch<string>("stringy")
                .Case("pesho", () => { })
                .Case(arg => 3 % 2 == 5, () => { })
                .Case(false, () => { })
                .Case(arg => arg.Length == 3, () => { })
                .Default(() => { defaultCalled = true; });

            Assert.IsTrue(defaultCalled);
        }

        [TestMethod]
        public void TestIfSwitchFallthroughCanBeSetOffCorrectly()
        {
            int methodCalls = 0;

            var test = new Switch<string>("stringy", true);

            test
                .Case("stringy", () => { methodCalls++; })
                .Case(true, () => { methodCalls++; })
                .Case(arg => true, () => { methodCalls++; test.FallThrough = false; })
                // shouldn't call any of these methods
                .Case(false, () => { })
                .Case(true, () => { methodCalls++; test.FallThrough = true; })
                .Case(false, () => { })
                .Case("strin" + "gy", () => { methodCalls++; })
                .Default(() => { methodCalls++; });

            Assert.AreEqual(3, methodCalls);
        }
    }
}
