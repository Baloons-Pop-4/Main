namespace Tests.MockClasses
{
    using System;
    using System.Linq;

    using BalloonsPop.Common.Contracts;

    public class MockSaver : IStateSaver<IGameModel>
    {
        public MockSaver()
        {
            this.CallsToSetCount = 0;
        }

        public int CallsToSetCount { get; private set; }

        public int CallsToGetCount { get; private set; }

        public bool HasStates
        {
            get
            {
                return false;
            }
        }

        public IGameModel GetState()
        {
            this.CallsToGetCount++;
            return null;
        }

        public void SaveState(IGameModel obj)
        {
            this.CallsToSetCount++;
        }
    }
}
