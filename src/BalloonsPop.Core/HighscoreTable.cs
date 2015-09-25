﻿namespace BalloonsPop.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BalloonsPop.Common.Contracts;

    public class HighscoreTable : IHighscoreTable
    {
        private const int HighscoreMaxPlayers = 5;
        private List<IPlayerScore> table;

        public HighscoreTable()
        {
            this.table = new List<IPlayerScore>();
        }

        public List<IPlayerScore> Table
        {
            get
            {
                return this.table;
            }
        }

        public bool CanAddPlayer(int movesCount)
        {
            bool listAcceptsEntries = this.table.Count < HighscoreMaxPlayers;
            bool hasLowerMoves = this.table.Any(x => movesCount < x.Moves);

            return listAcceptsEntries || hasLowerMoves;
        }

        public void AddPlayer(IPlayerScore score)
        {
            this.table.Add(score);
            this.table.Sort();

            if (this.table.Count > HighscoreMaxPlayers)
            {
                this.table.RemoveAt(this.table.Count - 1);
            }
        }
    }
}
