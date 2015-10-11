namespace BalloonsPop.Saver
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

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

        public void PushItem(T state)
        {
            this.memory.Push(state);
        }

        public T GetItem()
        {
            return this.memory.Pop();
        }
    }
}
