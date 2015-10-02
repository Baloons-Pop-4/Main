namespace BalloonsPop
{
    using BalloonsPop.ConsoleUI.Contracts;
    using BalloonsPop.Bundling;
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