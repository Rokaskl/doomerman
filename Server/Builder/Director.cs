using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server.Builder
{
    public class Director
    {
        public void Construct(Builder builder, TcpClient tcp)
        {
            builder.BuildData(tcp);
            builder.BuildMainObject();
            App.Inst.Log("builder building...");
        }
    }
}
