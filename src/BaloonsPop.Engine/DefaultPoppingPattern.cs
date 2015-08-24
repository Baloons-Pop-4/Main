namespace BaloonsPop.Engine
{
    using System;
    using BaloonsPop.Common.Contracts;
    
    public class DefaultPoppingPattern : IPopPattern
    {
        private IVector[] directions;

        public DefaultPoppingPattern()
        {
            this.directions = new IVector[]{ new Vector(0, 1), new Vector(0, -1), new Vector(1, 0), new Vector(-1, 0) };
        }

        public IVector[] Directions
        {
            get
            {
                return (IVector[])this.directions.Clone();
            }
        }
    }
}