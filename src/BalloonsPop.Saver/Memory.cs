namespace BalloonsPop.Saver
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    /// <summary>
    /// Provides a generic container for objects that is used by the Save class to store states.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Memory<T> : IMemory<T>
    {
        private readonly Stack<T> memory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Memory{T}" /> class. 
        /// </summary>
        public Memory()
        {
            this.memory = new Stack<T>();
        }

        /// <summary>
        /// Gets a value indicating whether the memory is empty
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return this.memory.Count == 0;
            }
        }

        /// <summary>
        /// Adds a state in the memory.
        /// </summary>
        /// <param name="state"></param>
        public void PushItem(T state)
        {
            this.memory.Push(state);
        }

        /// <summary>
        /// Gets the last added element from the memory. If the memory is empty, throws an exception.
        /// </summary>
        /// <returns></returns>
        public T GetItem()
        {
            return this.memory.Pop();
        }
    }
}
