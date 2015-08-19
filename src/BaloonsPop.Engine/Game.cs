namespace BaloonsPop.Engine
{
    using BaloonsPop.Common.Contracts;

    public class Game : IGameModel
    {
        private byte[,] field;

        private int userMovesCount;

        private GameLogic gameLogicProvider;

        public Game(GameLogic gameLogicProvider)
        {
            this.gameLogicProvider = gameLogicProvider;
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
            this.field = this.gameLogicProvider.GenerateField();
            this.userMovesCount = 0;
        }

        public void IncrementMoves()
        {
            this.userMovesCount++;
        }
    }
}