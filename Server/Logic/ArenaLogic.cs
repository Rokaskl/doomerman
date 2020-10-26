using Server.CommandPattern;
using Server.FacadePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logic
{
    public class ArenaLogic : IReceiver, ILogicFacade
    {
        private GameArena arena;

        public ArenaLogic(GameArena arena)
        {
            this.arena = arena;
        }

        private void ProcessData()
        {
            //int object identifier - int object id - int x coord - int y coord;
            //Sudaro byte array informacijos ir siuncia i clientside kiekvienam zaidejui.
            var list = this.arena.Players.Select(x => (new DataUnit() { XY = new Coordinates(x.xy.X, x.xy.Y), Id = x.User.Id })).ToList();
            Console.WriteLine("Komandu listas");
            list.ForEach(x => Console.WriteLine(x.ToString()));
        }

        public void Action(Command command)
        {
            var x = command as ArenaCommand;

            switch (x.Cmds.FirstOrDefault())
            {
                case ArenaCommandEnum.MoveUp:
                    {
                        x.Author.moveStrategy.MoveUp(x.Author, arena.grid.GetGrid());
                        break;
                    }
                case ArenaCommandEnum.MoveDown:
                    {
                        x.Author.moveStrategy.MoveDown(x.Author, arena.grid.GetGrid());
                        break;
                    }
                case ArenaCommandEnum.MoveRight:
                    {
                        x.Author.moveStrategy.MoveRight(x.Author, arena.grid.GetGrid());
                        break;
                    }
                case ArenaCommandEnum.MoveLeft:
                    {
                        x.Author.moveStrategy.MoveLeft(x.Author, arena.grid.GetGrid());
                        break;
                    }
                case ArenaCommandEnum.DropBomb:
                    {
                        x.Author.DropBomb();

                        break;
                    }

            }


            if (x.Cmds.Any(c => c == ArenaCommandEnum.DropBomb) && x.Author.CanDropBomb())
            {
                x.Author.DropBomb();
            }

        }

        public void FinalizeExecute()
        {
            if (this.arena.isStarted)
            {
                this.ProcessData();
                arena.UpdateRequired = true;
            }
        }
    }

}
