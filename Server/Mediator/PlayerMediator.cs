using System;
using System.Collections.Generic;
using System.Text;
using Server.FacadePattern;

namespace Server.Mediator
{
    public class PlayerMediator : IMediator
    {
        private List<IColleague> registered = new List<IColleague>();

        public PlayerMediator()
        {
            App.Inst.Log("Player mediator created");
        }

        public void ExecuteCommand(string command, IColleague receiver, params object[] args)
        {
            switch (command)
            {
                case "Listen":
                    {
                        (receiver as PlayerServiceProxyColleague).Listen(receiver.BondedColleague as Player, args[0] as LogicFacade);
                        break;
                    }
            }
        }

        public void Register(IColleague colleague)
        {
            if (!registered.Contains(colleague))
            {
                registered.Add(colleague);
                colleague.Mediator = this;
                if (colleague.BondedColleague != null)
                {
                    colleague.BondedColleague.Mediator = this;
                }
            }
        }
    }
}
