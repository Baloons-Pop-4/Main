using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BalloonsPop.Common.Contracts;

namespace Tests.MockClasses
{
    public class MockSaver : IStateSaver<IGameModel>
    {
        public int CallsToSetCount { get; private set; }
        public int CallsToGetCount { get; private set; }

        public MockSaver()
        {
            this.CallsToSetCount = 0;
        }
       
        public IGameModel GetState()
        {
            this.CallsToGetCount++;
            return null;
        }

        public bool HasStates
        {
            get
            {
                return false;
            }
        }

        public void SaveState(IGameModel obj)
        {
            this.CallsToSetCount++;
        }
    }
}
