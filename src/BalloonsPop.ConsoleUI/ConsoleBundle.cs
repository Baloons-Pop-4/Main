namespace BalloonsPop
{
    using BalloonsPop.Bundling;
    using BalloonsPop.ConsoleUI.Contracts;
    using Ninject;

    public class ConsoleBundle : CoreBundle, IConsoleBundle
    {
        public ConsoleBundle(IKernel kernel) 
            : base(kernel)
        {
            kernel.Inject(this.Reader);
        }

        [Inject]
        public IInputReader Reader { get; set; }
    }
}