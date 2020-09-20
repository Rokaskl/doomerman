using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Listener
{
    TcpListener server = null;
    GameArena Arena = new GameArena(0);//Test
    public Listener(string ip, int port)
    {
        
        IPAddress localAddr = IPAddress.Parse(ip);
        server = new TcpListener(localAddr, port);
        server.Start();
        StartBoth();
        Console.Read();
    }

    public async void StartBoth()
    {
         Task.Run(StartListener);//Connect players
       //  Task.Run(StartSender);
       // StartSender2();
        Console.Read();
    }
    
    public async void StartSender2()
    {
        await Task.Delay(2000);
        byte[] buffer;

        //if (!string.IsNullOrWhiteSpace(text_data))
        //{
        //buffer = BitConverter.GetBytes(int.Parse("0")).Concat(BitConverter.GetBytes(1))//.Concat(BitConverter.GetBytes(.GetBytes(new int[] {0, 1, 2, 3 }));//.Concat(Encoding.UTF8.GetBytes("01234")).ToArray();
        //}
        //else
        //{
        //buffer = BitConverter.GetBytes(int.Parse(message_number)).ToArray();
        //}
        buffer = (new List<int> { 0, 2, 1}).SelectMany(x => BitConverter.GetBytes(x)).ToArray();
        TcpClient cl = new TcpClient("localhost", 13000);

        while (true)
        {
            await Task.Delay(78);
            try
            {
                if (cl.GetStream().CanWrite)
                {
                    cl.GetStream().Write(buffer, 0, buffer.Length);
                    //break;
                }
            }
            catch (Exception exception)
            {
                break;
            }
        }
    }
    //public void StartListener()
    //{
    //    try
    //    {
    //        while (true)
    //        {
    //            Console.WriteLine("Waiting for a connection...");
    //            TcpClient client = server.AcceptTcpClient();
    //            Console.WriteLine("Connected!");
    //            Thread t = new Thread(new ParameterizedThreadStart(HandleDeivce));
    //            t.Start(client);
    //        }
    //    }
    //    catch (SocketException e)
    //    {
    //        Console.WriteLine("SocketException: {0}", e);
    //        server.Stop();
    //    }
    //}

    public async void StartListener()
    {
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();

            while (true)
            {
                await Task.Delay(2);
                if (client.GetStream().CanRead && client.Available >= 8)
                {
                    byte[] buffer = new byte[client.Available];
                    client.GetStream().Read(buffer, 0, client.Available);
                    int userId = BitConverter.ToInt32(buffer, 4);
                    Server.User user = App.Inst.UserRepo.Users.FirstOrDefault(x => x.Id == userId);//Reikia suziureti id
                    if (user != null)
                    {
                        user.Client = client;
                    }
                    else
                    {
                        user = App.Inst.UserRepo.AddUser(new User(userId));
                        user.Client = client;
                    }
                    Console.WriteLine("Client " + user.Id.ToString() + "connected.");
                    Arena.AddPlayer(new Player(user));
                    //else jei userio nera.
                    //if(buffer.Length > 8)
                    //{
                    //    var cmd = new Command { Author = user, TimeStamp = DateTime.UtcNow };
                    //    int index = 1;
                    //    while (buffer.Length >= (index + 1) * 4 + 4)
                    //    {
                    //        cmd.Cmds.Add((CommandEnum)BitConverter.ToInt32(buffer, (index + 1) * 4));
                    //        index++;
                    //    }
                    //    cmd.Execute();
                    //}
                    break;
                }
            }
        }
    }

    
    //public void HandleDeivce(Object obj)
    //{
    //    TcpClient client = (TcpClient)obj;
    //    var stream = client.GetStream();
    //    string imei = String.Empty;
    //    string data = null;
    //    Byte[] bytes = new Byte[256];
    //    int i;

    //    try
    //    {
    //        int count = 0;

    //        while (true)
    //        {
    //            string str = "Hey Device! " + count.ToString() ;
    //            Byte[] reply = System.Text.Encoding.ASCII.GetBytes(str);
    //            stream.Write(reply, 0, reply.Length);
    //            count++;
    //            Thread.Sleep(200);

    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        Console.WriteLine("Exception: {0}", e.ToString());
    //        client.Close();
    //    }
    //}
}