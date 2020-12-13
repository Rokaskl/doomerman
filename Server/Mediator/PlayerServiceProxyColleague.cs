using System;
using System.Collections.Generic;
using System.Text;
using Server.FacadePattern;
using Server.Iterator;

namespace Server.Mediator
{
    public class PlayerServiceProxyColleague : IColleague
    {
        private PlayerServiceProxy service = new PlayerServiceProxy();
        private IMediator mediator;
        public IMediator Mediator
        {
            get => this.mediator;
            set
            {
                this.mediator = value;
            }
        }
        private IColleague colleague;
        public IColleague BondedColleague
        {
            get => this.colleague;
            set
            {
                this.colleague = value;
                if (this.colleague != null && this.colleague.BondedColleague == null)
                {
                    this.colleague.BondedColleague = this;
                }
            }
        }
        public PlayerServiceProxyColleague()
        {
        }
        public void Listen(Player player, LogicFacade calculator)
        {
            this.service.ListenPlayer(player, calculator);
        }
    }
}
