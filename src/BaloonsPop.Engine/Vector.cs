namespace BaloonsPop.Engine
{
    using BaloonsPop.Common.Contracts;

    public struct Vector : IVector
    {
        private const int DIMENSION = 2;

        private int[] coordinates;

        public Vector(int x, int y)
        {
            this.coordinates = new int[DIMENSION];
            this.coordinates[0] = x;
            this.coordinates[1] = y;
        }

        public int X
        {
            get
            {
                return this.coordinates[0];
            }
        }

        public int Y
        {
            get
            {
                return this.coordinates[1];
            }
        }
    }
}