using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public class Lobby
    {

        private Form1 form;
        private bool isReady;
        public Lobby(Form1 form)
        {
            this.form = form;
        }

        public void UpdateLobby(LobbyData lobbyData)
        {
            lobbyData.playerData.AsEnumerable().ToList().ForEach(x => this.form.showPlayerLobby(int.Parse(x.Key), true, (bool)x.Value, "Igor" + int.Parse(x.Key)));
        }

        public void ToggleReady()
        {
            if (this.isReady)
            {
                this.form.SendSignal(3, CommandTypeEnum.General);
            }
            else
            {
                this.form.SendSignal(2, CommandTypeEnum.General);
            }
            this.isReady = !this.isReady;
        }
    }
}
