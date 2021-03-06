﻿namespace BalloonsPop.Saver
{
    using System;
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Saver.CloningStrategies;

    /// <summary>
    /// Provides generic state saving via replicating objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Saver<T> : IStateSaver<T>
    {
        /// <summary>
        /// Serves as a container for different cloning routines.
        /// </summary>
        private static IList<ICloningStrategy<T>> cloningStratgies = new List<ICloningStrategy<T>>() 
        {
            new CustomCloning<T>(),
            new DotNetCloning<T>(),
            new SerializationCloning<T>()
        };

        private IMemory<T> memory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Saver{T}" /> class. 
        /// </summary>
        public Saver()
        {
            this.memory = new Memory<T>();
        }

        /// <summary>
        /// Gets a value indicating whether the saver has a state
        /// </summary>
        public bool HasStates
        {
            get
            {
                return !this.memory.IsEmpty;
            }
        }

        /// <summary>
        /// Saves a state for later retrieval.
        /// </summary>
        /// <param name="obj">The object state to save.</param>
        public void SaveState(T obj)
        {
            this.memory.PushItem(this.DeepClone(obj));
        }

        /// <summary>
        /// Fetches and returnd a state.
        /// </summary>
        /// <returns>A state of type T.</returns>
        public T GetState()
        {
            return this.memory.GetItem();
        }

        // uses the .IsMatch method of the cloning routines to determine which one to use
        private T DeepClone(T obj)
        {
            T result = default(T);
            var hasMatched = false;

            foreach (var cloningStrategy in cloningStratgies)
            {
                if (cloningStrategy.IsMatch(obj))
                {
                    result = cloningStrategy.Clone(obj);
                    hasMatched = true;
                    break;
                }
            }

            if (!hasMatched)
            {
                throw new ArgumentException("Me no can clone dis T_T");
            }

            return result;
        }
    }
}