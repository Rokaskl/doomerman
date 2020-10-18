using Server.CommandPattern;
using Server.FacadePattern;
using Server.GameLobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Logic
{
    class GeneralLogic : IReceiver, ILogicFacade
    {
        private Lobby lobby;
        public GeneralLogic(Lobby lobby)
        {
            this.lobby = lobby;
        }
        public void Action(Command command)
        {
            var x = command as GeneralCommand;

            switch (x.Cmds.FirstOrDefault())
            {
                case GeneralCommandEnum.Handshake:
                    {
                        break;
                    }
                case GeneralCommandEnum.JoinLobby:
                    {
                        this.lobby.AddPlayer(x.Author);
                        break;
                    }
                case GeneralCommandEnum.LeaveLobby:
                    {
                        this.lobby.RemovePlayer(x.Author);
                        break;
                    }
                case GeneralCommandEnum.Ready:
                    {
                        this.lobby.PlayerReady(x);
                        break;
                    }
                case GeneralCommandEnum.NotReady:
                    {
                        var readyCommand = this.lobby.GetReadyCommand(x.Author);
                        if(readyCommand != null)
                        {
                            readyCommand.Undo();
                        }
                        break;
                    }

            }
        }

        public void FinalizeExecute()
        {
            this.lobby.SendInfo();
        }
    }
}
