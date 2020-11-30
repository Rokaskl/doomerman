using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class GameState : IState
    {
        public void PressSpace(Form1 formContext)
        {
            formContext.DropBomb();
        }
    }
}
