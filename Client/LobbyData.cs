using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace OPP
{
    [Serializable()]
    class LobbyData
    {
        public int Id { get; set; }

        public int Score { get; set; }
        public bool Alive { get; set; }


    }
}
