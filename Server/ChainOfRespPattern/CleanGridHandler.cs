using System;
using System.Collections.Generic;
using System.Text;

namespace Server.ChainOfRespPattern
{
    public class CleanGridHandler<T> : IHandler where T : Arena
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
        
        public void HandleRequest()
        {
            this.CleanGrid();
            if (this.successor != null)
            {
                this.successor.HandleRequest();
            }
        }

        public IHandler SetSuccessor(IHandler successor)
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
