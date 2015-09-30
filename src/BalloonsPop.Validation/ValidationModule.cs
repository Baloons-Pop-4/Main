namespace BalloonsPop.Validation
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

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