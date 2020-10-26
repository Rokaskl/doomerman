using Server.CommandPattern;
using Server.GameLobby;
using Server.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.FacadePattern
{
    public class LogicFacade
    {
        private ILogicFacade arenaLogic;
        private ILogicFacade generalLogic;
        private ILogicFacade logicBase;

        public LogicFacade(GameArena arena, Lobby lobby)
        {
            this.logicBase = new LogicBase(this);
            this.arenaLogic = new ArenaLogic(arena);
            this.generalLogic = new GeneralLogic(lobby);
        }

        public void AddCommand(Command command)
        {

            if (command is GeneralCommand)
            {
                command.Receiver = (GeneralLogic)generalLogic;
            }
            if (command is ArenaCommand)
            {
                command.Receiver = (ArenaLogic)arenaLogic;
            }
            ((LogicBase)this.logicBase).AddCommand(command);
           
        }

        public void FinalizeExecute()
        {
            App.Inst.Log("Logic facade executed");
            arenaLogic.FinalizeExecute();
            generalLogic.FinalizeExecute();
            logicBase.FinalizeExecute();
        }
    }
}
