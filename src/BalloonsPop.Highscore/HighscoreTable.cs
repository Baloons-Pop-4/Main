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
        public const int MaxPlayers = 5;

        /// <summary>
        /// A list of players (player scores) that actually represent a table.
        /// </summary>
        private List<PlayerScore> table;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreTable"/> class.
        /// </summary>
        public HighscoreTable(List<PlayerScore> playerScores = null)
        {
            this.Table = playerScores ?? new List<PlayerScore>();
        }

        /// <summary>
        /// Gets a list of <see cref="IPlayerScore"/> entries, hence the actual table.
        /// </summary>
        public List<PlayerScore> Table
        {
            get
            {
                return new List<PlayerScore>(this.table);
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
            bool listAcceptsEntries = this.table.Count < HighscoreTable.MaxPlayers;
            bool hasLowerMoves = this.table.Any(x => movesCount < x.Moves);

            return listAcceptsEntries || hasLowerMoves;
        }

        /// <summary>
        /// Adds a player to a <see cref="HighscoreTable"/>.
        /// </summary>
        /// <param name="score">An instance of a class that implements the <see cref="IPlayerScore"/> interface.</param>
        public void AddPlayer(PlayerScore score)
        {
            this.table.Add(score);
            this.table.Sort();

            if (this.table.Count > HighscoreTable.MaxPlayers)
            {
                this.table.RemoveAt(this.table.Count - 1);
            }
        }
    }
}
