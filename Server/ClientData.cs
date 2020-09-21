using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Server
{
    [Serializable()]
    class ClientData
    {
        public int Id { get; set; }
        public List<int>[,] Grid { get; set; }
        public int Score { get; set; }
        public bool Alive { get; set; }
    }
    
}
