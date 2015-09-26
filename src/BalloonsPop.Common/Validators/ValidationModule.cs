using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Common.Validators
{
    using Ninject;
    using Ninject.Modules;

    using BalloonsPop.Common.Contracts;

    public class ValidationModule : NinjectModule
    {
        private static IKernel kernel;

        public ValidationModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        public override void Load()
        {
            kernel.Bind<IMatrixValidator>().To<MatrixValidator>();
            kernel.Bind<IUserInputValidator>().To<UserInputValidator>();
        }
    }
}
