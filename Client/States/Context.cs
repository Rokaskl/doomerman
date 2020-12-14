using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public class Context
    {
        private IState state;
        private IState prevState;

        public IState GetState()
        {
            return this.state;
        }

        public IState GetPreviousState()
        {
            if (this.prevState == null)
                return this.state;

            return this.prevState;
        }

        public void SetState(IState state)
        {
            this.prevState = this.state;
            this.state = state;
        }
    }
}
