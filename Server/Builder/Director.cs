using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server.Builder
{
    class Director
    {
        public void Construct(Builder builder, TcpClient tcp)
        {
            builder.BuildData(tcp);
            builder.BuildMainObject();
        }
    }
}
