using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BalloonsPop.Common.Contracts;

namespace Tests.MockClasses
{
    public class GameMock : IGameModel
    {
        private byte[,] field = new byte[5, 10];

        public byte[,] Field
        {
            get
            {
                return this.field;
            }
            set
            {
                this.field = value;
            }
        }

        public int UserMovesCount
        {
            get { throw new NotImplementedException(); }
        }

        public void ResetUserMoves()
        {
            throw new NotImplementedException();
        }

        public void IncrementMoves()
        {
            throw new NotImplementedException();
        }

        public IGameModel Clone()
        {
            throw new NotImplementedException();
        }
    }
}
