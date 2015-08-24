namespace BaloonsPop.Common.Contracts
{
    using System;

    public interface IPoint : ICloneable
    {
        int X { get; }
        int Y { get; }
        void Update(IVector vector);
    }
}