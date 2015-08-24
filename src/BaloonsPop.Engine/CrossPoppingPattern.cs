namespace BaloonsPop.Engine
{
    using System;
    using BaloonsPop.Common.Contracts;

    public class CrossPoppingPattern : IPopPattern
    {
        private IVector[] directions;

        public CrossPoppingPattern()
        {
            this.directions = new IVector[] { new Vector(1, 1), new Vector(-1, 1), new Vector(-1, -1), new Vector(1, -1) };
        }

        public IVector[] Directions
        {
            get
            {
                return this.directions;
            }
        }
    }
}