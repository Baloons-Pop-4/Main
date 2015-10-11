namespace Tests.DependancyBinderTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BalloonsPop.Bundling;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ninject.Modules;

    [TestClass]
    public class DependencyBinderTests
    {
        private DependancyBinder binder = DependancyBinder.Instance;

        public DependencyBinderTests()
        {
            this.binder.Modules.Clear();
        }

        [TestMethod]
        public void TestIfModulesPropertyIsAnEmptyCollectionWhenNoModulesHaveBeenRegistered()
        {
            Assert.AreEqual(0, this.binder.Modules.Count);
        }

        [TestMethod]
        public void TestIfRegisterModulesAddsAModuleToTheModulesList()
        {
            var moqModule = new Mock<NinjectModule>();
            moqModule.Setup(x => x.Load()).Verifiable();
            Assert.AreEqual(0, this.binder.Modules.Count);

            this.binder.RegisterModules(moqModule.Object).LoadAll();

            moqModule.Verify(x => x.Load(), Times.Once);

            this.binder.UnregisterModule(moqModule.Object);
        }

        [TestMethod]
        public void TestIfUnregisterModuleRemovesAddedModules()
        {
            var moqModule = new Mock<NinjectModule>();
            moqModule.Setup(x => x.Load()).Verifiable();
            Assert.AreEqual(0, this.binder.Modules.Count);

            this.binder.RegisterModules(moqModule.Object).LoadAll();

            Assert.AreEqual(1, this.binder.Modules.Count);

            this.binder.UnregisterModule(moqModule.Object);

            Assert.AreEqual(0, this.binder.Modules.Count);
        }

        [TestMethod]
        public void TestIfRegisterModulesAddsAndLoadAllModulesFromProvidedModulesCollection()
        {
            var moqCollection = new List<Mock<NinjectModule>>();
            int modulesCount = 5;

            for (int i = 0; i < modulesCount; i++)
            {
                var moqModule = new Mock<NinjectModule>();
                moqModule.Setup(x => x.Load()).Verifiable();

                moqCollection.Add(moqModule);
            }

            this.binder.RegisterModules(moqCollection.Select(x => x.Object).ToArray()).LoadAll();

            foreach (var item in moqCollection)
            {
                Assert.IsTrue(this.binder.Modules.Contains(item.Object));
                item.Verify(x => x.Load(), Times.Once);
            }

            this.binder.Modules.Clear();
        }
    }
}