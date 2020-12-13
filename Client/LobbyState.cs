using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class LobbyState : IState
    {
        public void PressSpace(Form1 formContex)
        {
            // Check ready
            formContex.ClickReady();
        }
    }
}
