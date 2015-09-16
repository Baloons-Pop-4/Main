namespace BalloonsPop.Engine
{
    using System;
    using BalloonsPop.Common.Contracts;

    [Serializable]
    public class Game : IGameModel
    {
        private byte[,] field;

        private int userMovesCount;

        public Game(byte[,] field)
        {
            this.field = field;
        }

        public byte[,] Field
        {
            get
            {
                return this.field;
            }

            set
            {
                // TODO: validations here, logging here
                this.field = value;
            }
        }

        public int UserMovesCount
        {
            get
            {
                return this.userMovesCount;
            }
        }

        public void ResetUserMoves()
        {
            this.userMovesCount = 0;
        }

        public void IncrementMoves()
        {
            this.userMovesCount++;
        }
    }
}