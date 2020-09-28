using Server;
using System;
using System.Threading;
class Program
{
    
    static void Main(string[] args)
    {
        //---Set Server Options---------
        AppOptions options = new AppOptions();
        options.ArenaId =0;
        options.GridSize = 13;
        options.Port = 13000;    
        options.Ip = "127.0.0.1";
        //----------------------------


        App.CreateInst(options);
        App.Inst.CreateListener();
        
    }
}