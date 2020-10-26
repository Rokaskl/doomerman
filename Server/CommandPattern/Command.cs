using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;

namespace Server.CommandPattern
{
    public abstract class Command
    {
        
        public Player Author { get; set; }
        public IReceiver Receiver { get; set; }

        public DateTime TimeStamp { get; set; }

        public bool Executed = false;
        public int Heuristic { get; set; } = 0;

        public Command()
        {
            
        }

        public abstract void AddSubCommand(int subCommand);
        public virtual void Execute() 
        {
            App.Inst.Log("Command executed.");
        }
        public virtual void Undo()
        {
            App.Inst.Log("Command undo executed.");
        }
    }
}
