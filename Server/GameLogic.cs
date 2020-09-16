using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class GameLogic
    {
        public List<Command> Commands;
        //public List<SpecialEffect> SpecialEffects;//For delayed special effects, ex.: bombs.

        public GameLogic()
        {
            this.Commands = new List<Command>();
            //this.SpecialEffects = new List<SpecialEffects>();
            Task.Run(RemoveService);
            Task.Run(Logic);
        }

        public void Load(Command cmd)
        {
            this.Commands.Add(cmd);
        }

        private async void RemoveService()
        {
            while (true)
            {
                await Task.Delay(10);
                Commands.RemoveAll(x => x.heuristic >= 3);
            }
        }

        private async void Logic()
        {
            while (true)
            {
                await Task.Delay(10);
                Commands.ForEach(x =>
                {
                    if (x.heuristic >= 3)
                        return;

                    if(x.Cmds.Any(c => c == CommandEnum.MoveUp) && x.Author.CanMove(CommandEnum.MoveUp))
                    {
                        x.Author.MoveUp();
                    }
                    else
                    {
                        if (x.Cmds.Any(c => c == CommandEnum.MoveUp) && x.Author.CanMove(CommandEnum.MoveDown))
                        {
                            x.Author.MoveDown();
                        }
                        else
                        {
                            if (x.Cmds.Any(c => c == CommandEnum.MoveRight) && x.Author.CanMove(CommandEnum.MoveRight))
                            {
                                x.Author.MoveRight();
                            }
                            else
                            {
                                if (x.Cmds.Any(c => c == CommandEnum.MoveLeft) && x.Author.CanMove(CommandEnum.MoveLeft))
                                {
                                    x.Author.MoveLeft();
                                }
                            }
                        }
                    }

                    if(x.Cmds.Any(c => c == CommandEnum.DropBomb) && x.Author.CanDropBomb())
                    {
                        x.Author.DropBomb();
                        //this.SpecialEffects.Add(new Spe...);
                    }
                });
                //All commands executed.
                ProcessData();
            }
        }

        private void ProcessData()
        {
            //int object identifier - int object id - int x coord - int y coord;
            //Sudaro byte array informacijos ir siuncia i clientside kiekvienam zaidejui.

        }
    }
}
