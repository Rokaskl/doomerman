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
            IMoveStrategy moveStrategy = null;

            switch (x.Cmds.FirstOrDefault())
            {
                case ArenaCommandEnum.MoveUp:
                    {
                        moveStrategy = new MoveUpStrategy();
                        break;
                    }
                case ArenaCommandEnum.MoveDown:
                    {
                        moveStrategy = new MoveDownStrategy();
                        break;
                    }
                case ArenaCommandEnum.MoveRight:
                    {
                        moveStrategy = new MoveRightStrategy();
                        break;
                    }
                case ArenaCommandEnum.MoveLeft:
                    {
                        moveStrategy = new MoveLeftStrategy();
                        break;
                    }
                case ArenaCommandEnum.DropBomb:
                    {

                        x.Author.DropBomb();

                        break;
                    }

            }

            if (moveStrategy != null)  moveStrategy.Move(x.Author,arena.walls);

            //if (x.Cmds.Any(c => c == ArenaCommandEnum.DropBomb) && x.Author.CanDropBomb())
            //{
            //    x.Author.DropBomb();
            //}
        }

        public void FinalizeExecute()
        {
            if (this.arena.isStarted)
            {
                this.ProcessData();
                arena.UpdateGrid();
            }
        }
    }

}
