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
        private IBalloon[,] field = new IBalloon[5, 10];

        public GameMock()
        {
            this.Calls = new Dictionary<string, int>() 
            {
                {"ResetMoves",0},
                {"IncrementMoves",0},
            };
        }

        public IDictionary<string, int> Calls { get; private set; }

        public IBalloon[,] Field
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
            this.Calls["ResetMoves"]++;
        }

        public void IncrementMoves()
        {
            this.Calls["IncrementMoves"]++;
        }

        public IGameModel Clone()
        {
            throw new NotImplementedException();
        }
    }
}
