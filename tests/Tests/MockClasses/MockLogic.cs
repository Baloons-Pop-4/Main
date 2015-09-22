using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BalloonsPop.Common.Contracts;

namespace Tests.MockClasses
{
    public class MockLogic : IGameLogicProvider
    {
        public IDictionary<string, int> Calls { get; private set; }

        public MockLogic()
        {
            this.Calls = new Dictionary<string, int>() 
            {
                {"GenerateField", 0},
                {"PopBalloons", 0},
                {"LetBalloonsFall", 0},
                {"GameIsOver", 0},
            };
        }

        public IBalloon[,] GenerateField()
        {
            this.Calls["GenerateField"]++;
            return null;
        }

        public void PopBalloons(IBalloon[,] field, int row, int col)
        {
            this.Calls["PopBalloons"]++;
        }

        public void LetBalloonsFall(IBalloon[,] field)
        {
            this.Calls["LetBalloonsFall"]++;
        }

        public bool GameIsOver(IBalloon[,] field)
        {
            this.Calls["GameIsOver"]++;
            return true;
        }
    }
}
