namespace BalloonsPop
{
    using BalloonsPop.Bundling;
    using BalloonsPop.ConsoleUI.Contracts;
    using Ninject;

    public class ConsoleBundle : CoreBundle, IConsoleBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleBundle" /> class.
        /// </summary>
        /// <param name="matrix"></param>
        public ConsoleBundle(IKernel kernel) 
            : base(kernel)
        {
            kernel.Inject(this.Reader);
        }

        /// <summary>
        /// Gets or sets a Reader
        /// </summary>
        [Inject]
        public IInputReader Reader { get; set; }
    }
}