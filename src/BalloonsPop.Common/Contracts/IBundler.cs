namespace BalloonsPop.Common.Contracts
{
    using Ninject;

    public interface IBundler
    {
        ICoreBundle GetWrappedDependencies(IKernel kernel);
    }
}