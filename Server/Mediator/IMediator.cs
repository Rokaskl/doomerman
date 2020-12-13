using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mediator
{
    public interface IMediator
    {
        void ExecuteCommand(string command, IColleague colleague, params object[] args);
        void Register(IColleague colleague);
    }
}
