using System;
using System.Threading;
class Program
{
    
    static void Main(string[] args)
    {
        Int32 port = 13000;
        Thread t = new Thread(delegate ()
        {
            Listener myserver = new Listener("127.0.0.1", port);
        });
        t.Start();

        Console.WriteLine("Server Started...!");
    }
}