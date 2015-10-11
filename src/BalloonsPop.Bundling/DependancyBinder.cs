namespace BalloonsPop.Bundling
{
    using System.Collections.Generic;

    using Ninject.Modules;

    // TODO: remove this class and use Ninject loading

    /// <summary>
    /// Provides a consistent way to store, register, unregister and load ninject modules.
    /// </summary>
    public sealed class DependancyBinder
    {
        private static readonly DependancyBinder instance = new DependancyBinder();

        private DependancyBinder()
        {
            this.Modules = new List<NinjectModule>();
        }

        /// <summary>
        /// Gets access to the singleton instance.
        /// </summary>
        public static DependancyBinder Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the list of the currently registered ninject modules.
        /// </summary>
        public IList<NinjectModule> Modules { get; private set; }

        /// <summary>
        /// Registers the provided modules in the dependency loader.
        /// </summary>
        /// <param name="modules"></param>
        /// <returns>This method returns its caller(i.e. enables chaining)</returns>
        public DependancyBinder RegisterModules(params NinjectModule[] modules)
        {
            foreach (var item in modules)
            {
                if (!this.Modules.Contains(item))
                {
                    this.Modules.Add(item);
                }
            }

            return this;
        }

        /// <summary>
        /// Unregisters the provided module from the dependency loader.
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public DependancyBinder UnregisterModule(NinjectModule module)
        {
            if (this.Modules.Contains(module))
            {
                this.Modules.Remove(module);
            }

            return this;
        }

        /// <summary>
        /// Load all registered modules.
        /// </summary>
        public void LoadAll()
        {
            foreach (var module in this.Modules)
            {
                module.Load();
            }
        }
    }
}
