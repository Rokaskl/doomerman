using Server.CommandPattern;
using Server.FacadePattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logic
{
    public class LogicBase
    {
        private bool preventAdd;
        private LogicFacade logicFacade;
        public List<Command> Commands { get; set; }

        public LogicBase(LogicFacade logicFacade)
        {
            this.logicFacade = logicFacade;
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
                        if (!preventAdd)
                        {
                            //cmd.SetReceiver();
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

        //private async void RemoveService()
        //{
        //    while (true)
        //    {
        //        await Task.Delay(10);
        //        Commands.RemoveAll(x => x.heuristic >= 3 || x.executed);
        //        Commands.ForEach(x => x.heuristic++);
        //    }
        //}

        private async void Logic()
        {
            while (true)
            {
                await Task.Delay(10);
                int handledCount = 0;
                this.preventAdd = true;
                Commands?.ForEach(x =>
                {
                    if (x == null || x.Heuristic >= 3 || x.Executed)
                        return;

                    // x.Cmds.ForEach(z => Console.WriteLine(z.ToString() + " " + x.Author.User.Id.ToString()));

                    x.Receiver.Action(x); 
                    x.Executed = true;
                    handledCount++;
                });
                this.Commands = null;
                this.Commands = new List<Command>();
                this.preventAdd = false;
                //All commands executed.
                if (handledCount > 0)
                {
                    this.logicFacade.FinalizeExecute();
                }
            }
        }
    }
}
