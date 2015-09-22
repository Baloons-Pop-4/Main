using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BalloonsPop.Common.Contracts;

namespace Tests.MockClasses
{
    public class MementoMock : IMemento<IGameModel>
    {
        public int CallsToSetCount { get; private set; }

        public MementoMock()
        {
            this.CallsToSetCount = 0;
        }

        public IGameModel State
        {
            get
            {
                return new GameMock();
            }
            set
            {
                CallsToSetCount++;
            }
        }
    }
}
