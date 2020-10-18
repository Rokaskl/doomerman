using Server.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.CommandPattern
{
    public class ArenaCommand : Command
    {
        public List<ArenaCommandEnum> Cmds { get; }


        public ArenaCommand()
        {
            this.Cmds = new List<ArenaCommandEnum>();
        }

        public override void Execute()
        {
            //Fire event etc..
            Console.Write(this.Author.User.Id.ToString() + "   " + this.TimeStamp.ToString());
            Cmds.ForEach(x => Console.Write((ArenaCommandEnum)x + " "));
            Console.Write("\n\n");
        }

        public List<ArenaCommandEnum> GetCmds()
        {
            return this.Cmds.Select(x => (ArenaCommandEnum)x).ToList();
        }

        public override void AddSubCommand(int subCommand)
        {
            this.Cmds.Add((ArenaCommandEnum)subCommand);
        }
    }

    public enum ArenaCommandEnum
    {
        MoveUp,
        MoveDown,
        MoveLeft,
        MoveRight,
        DropBomb
    }
}
