﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.CommandPattern
{
    public class GeneralCommand : Command
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
            switch (Cmds.FirstOrDefault())
            {
                case GeneralCommandEnum.Handshake:
                    {
                        break;
                    }
                case GeneralCommandEnum.JoinLobby:
                    {
                        //Cant undo.
                        break;
                    }
                case GeneralCommandEnum.LeaveLobby:
                    {
                        //Cant undo.
                        break;
                    }
                case GeneralCommandEnum.Ready:
                    {
                        Author.PlayerLobby.PlayerNotReady(Author);
                        break;
                    }
                case GeneralCommandEnum.NotReady:
                    {
                        //Cant undo.
                        break;
                    }

            }
        }
    }

    public enum GeneralCommandEnum
    {
        Handshake,
        JoinLobby,
        LeaveLobby,
        Ready,
        NotReady
    }
}
