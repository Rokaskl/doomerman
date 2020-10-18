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
        //public Dictionary<string, bool> 

        public int Score { get; set; }
        public bool Alive { get; set; }


    }
}
