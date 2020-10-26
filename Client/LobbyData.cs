using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace OPP
{
    [Serializable()]
    public class LobbyData
    {
        public Dictionary<string, object> playerData { get; set; }
        public bool Starting { get; set; }
        public DateTime? GameStartsAt { get; set; }
    }
}
