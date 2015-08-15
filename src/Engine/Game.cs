namespace Engine
{
    using GameLogic;

    internal class Game
    {
        private byte[,] field;

        private int userMovesCount;

        public Game()
        {
            this.Reset();
        }

        public byte[,] Field
        {
            get
            {
                return this.field;
            }
        }

        public int UserMovesCount
        {
            get
            {
                return this.userMovesCount;
            }
        }

        public void Reset()
        {
            this.field = GameLogic.GenerateField();
            this.userMovesCount = 0;
        }

        public void IncrementMoves()
        {
            this.userMovesCount++;
        }
    }
}