using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace OPP
{
    class Listener
    {
        private Form1 form;
        public Listener(TcpClient client, Form1 form)
        {
            this.form = form;
            Task.Run(() => Start(client));
        }

        private void Start(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();

                //Listening Server
                while (true)
                {
                    byte[] bytes = new byte[client.ReceiveBufferSize];
                    stream.Read(bytes, 0, client.ReceiveBufferSize);
                    int num = BitConverter.ToInt32(bytes, 0);
                    string msg = Encoding.ASCII.GetString(bytes, 3, bytes.Length - 4);
                    Resolve(num, msg);
                }
                // Before closing client
                // stream.Close();
                // client.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        public void Resolve(int num, string msg)
        {
            switch (num)
            {
                case 0:
                    {
                        //Grid update
                        Data data = JsonConvert.DeserializeObject<Data>(msg);

                        if (!ClientManager.Instance.IDIsSet())
                            ClientManager.Instance.SetPlayerID(data.Id);

                        ClientManager.Instance.SetGridFromServer(data.Grid);

                        Console.WriteLine(data.Grid);
                        break;
                    }
                case 1:
                    {
                        //Lobby operations
                        //LobbyData lobbyData = JsonConvert.DeserializeObject<LobbyData>(msg);
                        Dictionary<string, object> lobbyData = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg);
                        this.form.Invoke(ToDelegate(() => this.form.UpdateLobby(null)));
                        break;
                    }
            }
        }

        private Delegate ToDelegate(Action action)
        {
            return (Delegate)action;
        }
        
        
    }
}
    
