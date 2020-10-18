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
        //private bool preventAdd;
        //public List<ArenaCommand> Commands { get; set; }
        private GameArena arena;

        public ArenaLogic(GameArena arena)
        {
            this.arena = arena;
           // this.Commands = new List<ArenaCommand>();
            //Task.Run(Logic);
        }

        //public void AddCommand(ArenaCommand cmd)
        //{
        //    try
        //    {
        //        lock (this)
        //        {
        //            while (true)
        //            {
        //                if(!preventAdd)
        //                {
        //                    //cmd.SetReceiver();
        //                    this.Commands.Add(cmd);
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private async void RemoveService()
        //{
        //    while (true)
        //    {
        //        await Task.Delay(10);
        //        Commands.RemoveAll(x => x.heuristic >= 3 || x.executed);
        //        Commands.ForEach(x => x.heuristic++);
        //    }
        //}

        //private async void Logic()
        //{
        //    while (true)
        //    {
        //        await Task.Delay(10);
        //        int handledCount = 0;
        //        this.preventAdd = true;
        //        Commands.ForEach(x =>
        //        {
        //            if (x == null || x.heuristic >= 3 || x.Executed)
        //                return;

        //            x.Cmds.ForEach(z => Console.WriteLine(z.ToString() + " " + x.Author.User.Id.ToString()));

        //            IMoveStrategy moveStrategy = null;

        //            switch (x.Cmds.FirstOrDefault())
        //            {
        //                case ArenaCommandEnum.MoveUp:
        //                    {
        //                        moveStrategy = new MoveUpStrategy();
        //                        break;
        //                    }
        //                case ArenaCommandEnum.MoveDown:
        //                    {
        //                        moveStrategy = new MoveDownStrategy();
        //                        break;
        //                    }
        //                case ArenaCommandEnum.MoveRight:
        //                    {
        //                        moveStrategy = new MoveRightStrategy();
        //                        break;
        //                    }
        //                case ArenaCommandEnum.MoveLeft:
        //                    {
        //                        moveStrategy = new MoveLeftStrategy();
        //                        break;
        //                    }
        //                case ArenaCommandEnum.DropBomb:
        //                    {
        //                        x.Author.DropBomb();

        //                        break;
        //                    }

        //            }

        //            if (moveStrategy != null)
        //                moveStrategy.Move(x.Author);

        //            if (x.Cmds.Any(c => c == ArenaCommandEnum.DropBomb) && x.Author.CanDropBomb())
        //            {
        //                x.Author.DropBomb();
        //            }
        //            arena.UpdateGrid();
        //            x.Executed = true;
        //            handledCount++;
        //        });

        //        this.Commands = null;
        //        this.Commands = new List<ArenaCommand>();
        //        this.preventAdd = false;
        //        //All commands executed.
        //        if (handledCount > 0)
        //        {
        //            ProcessData();
        //        }
        //    }
        //}

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

            if (moveStrategy != null)
                moveStrategy.Move(x.Author,arena.walls);

            if (x.Cmds.Any(c => c == ArenaCommandEnum.DropBomb) && x.Author.CanDropBomb())
            {
                x.Author.DropBomb();
            }
        }

        public void FinalizeExecute()
        {
            arena.UpdateGrid();
        }
    }

}
