namespace BalloonsPop.Engine
{
    using BalloonsPop.Common.Contracts;

    public class Game : IGameModel
    {
        private IBaloonsField baloons;

        private int userMovesCount;

        public Game(IBaloonsField field)
        {
            this.baloons = field;
        }

        public IBaloonsField Field
        {
            get
            {
                return this.baloons;
            }
        }

        public int UserMovesCount
        {
            get
            {
                return this.userMovesCount;
            }
        }

        public void IncrementMoves()
        {
            this.userMovesCount++;
        }

        public void NullifyUserMoves()
        {
            this.userMovesCount = 0;
        }
    }
}