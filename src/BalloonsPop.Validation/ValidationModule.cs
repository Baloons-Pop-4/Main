namespace BalloonsPop.Validation
{
    using BalloonsPop.Common.Contracts;

    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// Custom module that binds the validators to the interface types.
    /// </summary>
    public class ValidationModule : NinjectModule
    {
        private static IKernel kernel;

        public ValidationModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        /// <summary>
        /// Binds the validators to the respective interfaces.
        /// </summary>
        public override void Load()
        {
            kernel.Bind<IMatrixValidator>().To<MatrixValidator>();
            kernel.Bind<IUserInputValidator>().To<UserInputValidator>();
        }
    }
}