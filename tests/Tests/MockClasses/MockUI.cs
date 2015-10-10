namespace Tests.MockClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    public class MockPrinter : IPrinter
    {
        public readonly Dictionary<string, int> MethodCallCounts = new Dictionary<string, int>()
        {
            { "message", 0 },
            { "field", 0 },
            { "highscore", 0 }
        };

        public MockPrinter()
        {
        }

        public void PrintPlayerMoves(string moves)
        {}

        public void PrintMessage(string message)
        {
            this.MethodCallCounts["message"]++;
        }

        public void PrintField(IBalloon[,] matrix)
        {
            this.MethodCallCounts["field"]++;
        }

        public void PrintHighscore(IHighscoreTable table)
        {
            this.MethodCallCounts["highscore"]++;
        }
    }
}
