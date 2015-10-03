namespace BalloonsPop.Core.Memento
{
    using System.Collections.Generic;

    using BalloonsPop.Common.Contracts;

    public class Memory<T> : IMemory<T>
    {
        private Stack<T> memory;

        public Memory()
        {
            this.memory = new Stack<T>();
        }

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
