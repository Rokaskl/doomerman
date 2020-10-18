using System;
using System.Collections.Generic;
using System.Text;

namespace Server.CommandPattern
{
    public interface IReceiver
    {
        public void Action(Command command);
    }
}
