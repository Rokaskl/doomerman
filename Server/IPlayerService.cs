using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Server.FacadePattern;
namespace Server
{
    public interface IPlayerService
    {
        Task ListenPlayer(Player player, LogicFacade logic);
    }
}
