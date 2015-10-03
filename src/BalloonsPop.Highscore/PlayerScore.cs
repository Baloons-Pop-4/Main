// <copyright file="PlayerScore.cs" company="TelerikAcademy">
// All rights reserved. The Baloons-Pop-4 team.
// </copyright>

namespace BalloonsPop.Highscore
{
    using System;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// A class that has the required properties of a player score.
    /// </summary>
    public class PlayerScore : IPlayerScore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerScore"/> class.
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="moves">The current amount of moves the player</param>
        /// <param name="time">The current time</param>
        public PlayerScore(string name, int moves, DateTime time)
        {
            this.Name = name;
            this.Moves = moves;
            this.Time = time;
        }

        /// <summary>
        /// Gets the name of the player who has achieved the <see cref="PlayerScore"/>.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the player who has achieved the <see cref="PlayerScore"/>.
        /// </summary>
        public int Moves { get; private set; }

        /// <summary>
        /// Gets the time when a player has achieved the <see cref="PlayerScore"/>.
        /// </summary>
        public DateTime Time { get; private set; }

        /// <summary>
        /// Compares two <see cref="PlayerScore"/> instances.
        /// </summary>
        /// <param name="other">A <see cref="PlayerScore"/> instance to compare to.</param>
        /// <returns>The result from the comparison.</returns>
        public int CompareTo(IPlayerScore other)
        {
            return this.Moves.CompareTo(other.Moves);
        }
    }
}