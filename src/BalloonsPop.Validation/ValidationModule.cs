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

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationModule" /> class.
        /// </summary>
        /// <param name="bindingKernel"></param>
        public ValidationModule(IKernel bindingKernel)
        {
            kernel = bindingKernel;
        }

        /// <summary>
        /// Binds the validators to the respective interfaces.
        /// </summary>
        public override void Load()
        {
            kernel.Unbind<IMatrixValidator>();
            kernel.Unbind<IUserInputValidator>();
            kernel.Bind<IMatrixValidator>().To<MatrixValidator>();
            kernel.Bind<IUserInputValidator>().To<UserInputValidator>();
        }
    }
}