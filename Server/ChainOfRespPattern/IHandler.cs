using System;
using System.Collections.Generic;
using System.Text;

namespace Server.ChainOfRespPattern
{
    public interface IHandler
    {
        void HandleRequest();
        IHandler SetSuccessor(IHandler successor);
    }
}
