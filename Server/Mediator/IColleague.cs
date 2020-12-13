using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mediator
{
    public interface IColleague
    {
        public IMediator Mediator
        {
            get;
            set;
        }
        public IColleague BondedColleague
        {
            get;
            set;
        }
    }
}
