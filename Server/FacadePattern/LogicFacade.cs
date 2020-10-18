using Server.CommandPattern;
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
        //Reik trecio
        public LogicFacade(GameArena arena)
        {
            this.logicBase = new LogicBase(this);
            this.arenaLogic = new ArenaLogic(arena);
            this.generalLogic = new GeneralLogic();
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
            arenaLogic.FinalizeExecute();
            generalLogic.FinalizeExecute();
        }
    }
}
