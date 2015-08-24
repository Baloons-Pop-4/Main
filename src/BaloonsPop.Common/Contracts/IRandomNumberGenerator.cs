namespace BaloonsPop.Common.Contracts
{
    public interface IRandomNumberGenerator
    {
        int Next(int lowerBound, int upperBound);
    }
}