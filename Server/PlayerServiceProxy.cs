using System;
using System.Collections.Generic;
using System.Text;
using Server.FacadePattern;
using System.Threading.Tasks;
namespace Server
{
    class PlayerServiceProxy : IPlayerService
    {
        private PlayerService service;

        public PlayerServiceProxy()
        {
            service = new PlayerService();
            service.init += (obj, events) => { Console.WriteLine(events); };
            service.progress += (obj, events) =>
            {
                var data = ((Progress) events);
                if (data.message == "")
                    LogLogin(obj, events);
                else
                    Console.WriteLine(string.Format("{0} from user {1} (id: {2}) ", data.message, data.UserData.Username, data.UserData.Id));
            };
        }
        public Task ListenPlayer(Player player, LogicFacade logic)
        {

            return Task.Run(() => service.ListenPlayer(player, logic));

        }
        private void LogLogin(object info, Progress eventArgs)
        {
            Console.WriteLine(string.Format("Player {0} (id: {1}) added", eventArgs.UserData.Username, eventArgs.UserData.Id));
        }
    }
}

