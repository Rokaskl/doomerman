using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class GameLogic
    {
        private bool preventAdd;
        public List<Command> Commands { get; set; }
        private GameArena arena;

        public GameLogic(GameArena arena)
        {
            this.arena = arena;
            this.Commands = new List<Command>();
            Task.Run(Logic);
        }

        public void AddCommand(Command cmd)
        {
            try
            {
                lock (this)
                {
                    while (true)
                    {
                        if(!preventAdd)
                        {
                            this.Commands.Add(cmd);
                            break;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private async void RemoveService()
        {
            while (true)
            {
                await Task.Delay(10);
                Commands.RemoveAll(x => x.heuristic >= 3 || x.executed);
                Commands.ForEach(x => x.heuristic++);
            }
        }

        private async void Logic()
        {
            while (true)
            {
                await Task.Delay(10);
                int handledCount = 0;
                this.preventAdd = true;
                Commands.ForEach(x =>
                {
                    if (x == null || x.heuristic >= 3 || x.executed)
                        return;

                    x.Cmds.ForEach(z => Console.WriteLine(z.ToString() + " " + x.Author.User.Id.ToString()));

                    IMoveStrategy moveStrategy = null;

                    switch (x.Cmds.FirstOrDefault())
                    {
                        case CommandEnum.MoveUp:
                            {
                                moveStrategy = new MoveUpStrategy();
                                break;
                            }
                        case CommandEnum.MoveDown:
                            {
                                moveStrategy = new MoveDownStrategy();
                                break;
                            }
                        case CommandEnum.MoveRight:
                            {
                                moveStrategy = new MoveRightStrategy();
                                break;
                            }
                        case CommandEnum.MoveLeft:
                            {
                                moveStrategy = new MoveLeftStrategy();
                                break;
                            }
                        case CommandEnum.DropBomb:
                            {
                                    x.Author.DropBomb();
                                
                                break;
                            }

                    }

                    if(moveStrategy != null)
                        moveStrategy.Move(x.Author);
                
                    if(x.Cmds.Any(c => c == CommandEnum.DropBomb) && x.Author.CanDropBomb())
                    {
                        x.Author.DropBomb();
                    }
                    arena.UpdateGrid();
                    x.executed = true;
                    handledCount++;
                });
                this.Commands = null;
                this.Commands = new List<Command>();
                this.preventAdd = false;
                //All commands executed.
                if (handledCount > 0)
                {
                    ProcessData();
                }
            }
        }

        private void ProcessData()
        {
            //int object identifier - int object id - int x coord - int y coord;
            //Sudaro byte array informacijos ir siuncia i clientside kiekvienam zaidejui.
            var list = this.arena.Players.Select(x => (new DataUnit() { XY = new Coordinates(x.xy.X, x.xy.Y), Id = x.User.Id })).ToList();
            Console.WriteLine("Komandu listas");
            list.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }

}
