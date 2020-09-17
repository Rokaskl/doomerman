using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Command
    {
        public Player Author;
        public List<CommandEnum> Cmds;
        public DateTime TimeStamp;
        public int heuristic = 0;
        public bool executed = false;

        public Command()
        {
            this.Cmds = new List<CommandEnum>();
        }

        public void Execute()
        {
            //Fire event etc..
            Console.Write(this.Author.User.Id.ToString() + "   " + this.TimeStamp.ToString());
            Cmds.ForEach(x => Console.Write((CommandEnum)x + " "));
            Console.Write("\n\n");
        }
    }

    public enum CommandEnum
    {
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        DropBomb
    }
}
