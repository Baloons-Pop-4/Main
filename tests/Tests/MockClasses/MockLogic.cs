namespace Tests.MockClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    public class MockLogic : IGameLogicProvider
    {
        public MockLogic()
        {
            this.Calls = new Dictionary<string, int>() 
            {
                { "GenerateField", 0 },
                { "PopBalloons", 0 },
                { "LetBalloonsFall", 0 },
                { "GameIsOver", 0 },
            };
        }

        public IDictionary<string, int> Calls { get; private set; }

        public void RandomizeBalloonField(IBalloon[,] field)
        {
            this.Calls["GenerateField"]++;
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
