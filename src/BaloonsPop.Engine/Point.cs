namespace BaloonsPop.Engine
{
    using System;
    using BaloonsPop.Common.Contracts;

    public class Point : IPoint
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public object Clone()
        {
            return new Point(this.X, this.Y);
        }

        public void Update(IVector vector)
        {
            this.X += vector.X;
            this.Y += vector.Y;
        }
    }
}