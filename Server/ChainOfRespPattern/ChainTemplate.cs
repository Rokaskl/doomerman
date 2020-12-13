using System;
using System.Collections.Generic;
using System.Text;

namespace Server.ChainOfRespPattern
{
    public abstract class ChainTemplate : IHandler
    {
        public abstract void HandleRequest();
        public abstract IHandler SetSuccessor(IHandler successor);
    }
}
