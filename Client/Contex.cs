using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public class Contex
    {
        private IState state;

        public Contex()
        {
            this.state = null;
        }

        public IState GetState() => this.state;

        public void SetState(IState state) => this.state = state;
    }
}
