using System;
using System.Collections.Generic;
using System.Text;

namespace Server.GameLobby
{
    [Serializable]
    public class LobbyData
    {
        public Dictionary<string, object> playerData { get; }
        public bool Starting { get; set; }
        public DateTime? GameStartsAt { get; set; }

        public LobbyData()
        {
            this.playerData = new Dictionary<string, object>();
        }
    }
}
