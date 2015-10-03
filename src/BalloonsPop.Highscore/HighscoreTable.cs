// <copyright file="HighscoreTable.cs" company="TelerikAcademy">
// All rights reserved. The Baloons-Pop-4 team.
// </copyright>

namespace BalloonsPop.Highscore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Holds the logic for manipulating a list of player scores.
    /// </summary>
    public class HighscoreTable : IHighscoreTable
    {
        /// <summary>
        /// The max amount of players allowed to exist in a <see cref="HighscoreTable"/>.
        /// </summary>
        private const int HighscoreMaxPlayers = 5;

        /// <summary>
        /// A list of players (player scores) that actually represent a table.
        /// </summary>
        private List<IPlayerScore> table;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreTable"/> class.
        /// </summary>
        public HighscoreTable()
        {
            this.Table = new List<IPlayerScore>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreTable"/> class.
        /// </summary>
        /// <param name="table">An already filled list of players.</param>
        public HighscoreTable(List<IPlayerScore> table)
        {
            this.Table = table;
        }

        /// <summary>
        /// Gets a list of <see cref="IPlayerScore"/> entries, hence the actual table.
        /// </summary>
        public List<IPlayerScore> Table
        {
            get
            {
                return this.table;
            }

            private set
            {
                this.table = value;
            }
        }

        /// <summary>
        /// Checks if a player can be added to a <see cref="HighscoreTable"/>.
        /// </summary>
        /// <param name="movesCount">The amount of moves a player has.</param>
        /// <returns>Whether the player can be added or not.</returns>
        public bool CanAddPlayer(int movesCount)
        {
            bool listAcceptsEntries = this.table.Count < HighscoreMaxPlayers;
            bool hasLowerMoves = this.table.Any(x => movesCount < x.Moves);

            return listAcceptsEntries || hasLowerMoves;
        }

        /// <summary>
        /// Adds a player to a <see cref="HighscoreTable"/>.
        /// </summary>
        /// <param name="score">An instance of a class that implements the <see cref="IPlayerScore"/> interface.</param>
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
