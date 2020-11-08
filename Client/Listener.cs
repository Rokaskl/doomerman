using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;

namespace OPP
{
    class Listener
    {
        private bool showGameInvoked = false;
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
                using (StreamReader rd = new StreamReader(stream))
                { 
                //Listening Server
                    while (true)
                    {
                        //byte[] bytes = new byte[client.ReceiveBufferSize];
                        //stream.Read(bytes, 0, client.ReceiveBufferSize);
                        //int num = BitConverter.ToInt32(bytes, 0);
                        //string msg = Encoding.ASCII.GetString(bytes, 3, bytes.Length - 4);
                        //Console.WriteLine(num);
                        if (client.GetStream().CanRead && client.Available >= 2)
                        {
                            string fullMsg = rd.ReadLine();
                            int num = int.Parse(fullMsg[0].ToString());
                            string msg = fullMsg.Remove(0, 1);
                            Resolve(num, msg);
                        }

                        Thread.Sleep(50);
                    }
                }
              
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
                client.Close();
            }
        }

        public void Resolve(int num, string msg)
        {
            switch (num)
            {
                case 0:
                    {
                        //Grid update
                        Console.WriteLine(msg);

                        if (!showGameInvoked)
                        {
                            Invoke(this.form, () => this.form.ShowGame());
                            showGameInvoked = true;
                        }

                        Data data = JsonConvert.DeserializeObject<Data>(msg);
                        ClientManager.Instance.SetGridFromServer(data.Grid,data.DeadPlayers);
                        ClientManager.Instance.isAlive = data.Alive;

                        // Console.WriteLine(data.Grid);
                        break;
                    }
                case 1:
                    {
                        //Handshake successful.
                        var id = JsonConvert.DeserializeObject<int>(msg);
                        
                            if (!ClientManager.Instance.IDIsSet())
                                ClientManager.Instance.SetPlayerID(id);
                        
                        Invoke(this.form, () => this.form.HandshakeSuccessful = true);
                        break;
                    }
                case 2:
                    {
                        //Lobby operations
                        LobbyData lobbyData = JsonConvert.DeserializeObject<LobbyData>(msg);
                        //Dictionary<string, object> lobbyData = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg);
                        Invoke(this.form, () => this.form.UpdateLobby(lobbyData));
                        break;
                    }
            }
        }

        private void Invoke(Control ctrl, Action action)
        {
            ctrl.Invoke((Delegate)action);
        }
        
        
        
    }
}
    
