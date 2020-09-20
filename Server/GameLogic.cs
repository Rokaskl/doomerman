﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class GameLogic
    {
        private bool preventAdd;
        private List<Command> commands;
        public List<Command> Commands
        {
            get
            {

               return this.commands;
            }
            set
            {
                this.commands = value;
            }
        }
        private GameArena arena;
        //public List<SpecialEffect> SpecialEffects;//For delayed special effects, ex.: bombs.

        public GameLogic(GameArena arena)
        {
            this.arena = arena;
            this.Commands = new List<Command>();
            //this.SpecialEffects = new List<SpecialEffects>();
            //Task.Run(RemoveService);
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
                //Padaroma listo kopija, nes enumas crashina, jei modifikuojamas saltinis.
                this.preventAdd = true;
                Commands.ForEach(x =>
                {
                    if (x == null || x.heuristic >= 3 || x.executed)
                        return;

                    if(x.Cmds.Any(c => c == CommandEnum.MoveUp) && x.Author.CanMove(CommandEnum.MoveUp))
                    {
                        x.Author.MoveUp();
                    }
                    else
                    {
                        if (x.Cmds.Any(c => c == CommandEnum.MoveDown) && x.Author.CanMove(CommandEnum.MoveDown))
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