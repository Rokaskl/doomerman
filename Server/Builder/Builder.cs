using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server.Builder
{
    public abstract class Builder
    {
        public abstract void BuildData(TcpClient tcp);
        public abstract void BuildMainObject();
        public abstract Player GetPlayer();
    }
}
