using System;
using System.Collections.Generic;
using System.Text;

namespace Server.ChainOfRespPattern
{
    public class CleanGridHandler<T> : ChainTemplate where T : Arena
    {
        private T context;
        private IHandler successor;
        public CleanGridHandler(T context)
        {
            this.context = context;
        }

        public CleanGridHandler()
        {

        }
        
        public override void HandleRequest()
        {
            this.CleanGrid();
            if (this.successor != null)
            {
                this.successor.HandleRequest();
            }
        }

        public override IHandler SetSuccessor(IHandler successor)
        {
            this.successor = successor;
            return this.successor;
        }

        private void CleanGrid()
        {
            context.grid.Clean();
        }
    }
}
