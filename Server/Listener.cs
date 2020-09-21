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
                   
                    break;
                }
            }
        }
    }

}