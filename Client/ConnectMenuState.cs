using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class ConnectMenuState : IState
    {
        public void PressSpace(Form1 contex)
        {
            // Join
            contex.ClickJoin();
        }
    }
}
