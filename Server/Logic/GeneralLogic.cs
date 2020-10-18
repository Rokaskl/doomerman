using Server.CommandPattern;
using Server.FacadePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Logic
{
    class GeneralLogic : IReceiver, ILogicFacade
    {
        public void Action(Command command)
        {
            
        }

        public void FinalizeExecute()
        {
            
        }
    }
}
