using System;
using System.Collections.Generic;
using System.Text;

namespace Server.CommandPattern
{
    class GeneralCommand : Command
    {
        public List<GeneralCommandEnum> Cmds { get; }
        public GeneralCommand()
        {
            this.Cmds = new List<GeneralCommandEnum>();
        }
        public override void AddSubCommand(int subCommand)
        {
            this.Cmds.Add((GeneralCommandEnum)subCommand);
        }

        public override void Execute()
        {
            this.Receiver.Action(this);
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }

    public enum GeneralCommandEnum
    {
        Handshake
    }
}
