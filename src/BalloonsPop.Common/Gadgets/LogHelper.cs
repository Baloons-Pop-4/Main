namespace BalloonsPop.Common.Gadgets
{
    using System.Runtime.CompilerServices;
    using BalloonsPop.Common.Contracts;

    public static class LogHelper
    {
        public static ILogger GetLogger([CallerFilePath]string filename = "")
        {
            return new Log4NetWrapper(filename);
        }
    }
}
