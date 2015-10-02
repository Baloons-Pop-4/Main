namespace BalloonsPop.Bundling
{
    using System.Collections.Generic;

    using Ninject.Modules;

    public sealed class DependancyBinder
    {
        public IList<NinjectModule> Modules { get; set; }

        private static DependancyBinder instance = new DependancyBinder();

        public static DependancyBinder Instance
        {
            get
            {
                return instance;
            }
        }

        private DependancyBinder()
        {
            this.Modules = new List<NinjectModule>();
        }

        public DependancyBinder RegisterModule(NinjectModule module)
        {
            if (!this.Modules.Contains(module))
            {
                this.Modules.Add(module);
            }

            return this;
        }

        public DependancyBinder RegisterModules(params NinjectModule[] modules)
        {
            foreach (var item in modules)
            {
                this.Modules.Add(item);
            }

            return this;
        }

        public DependancyBinder UnregisterModule(NinjectModule module)
        {
            if (this.Modules.Contains(module))
            {
                this.Modules.Remove(module);
            }

            return this;
        }

        public void LoadAll()
        {
            foreach (var module in this.Modules)
            {
                module.Load();
            }
        }
    }
}
