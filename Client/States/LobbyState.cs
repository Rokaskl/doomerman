using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPP
{
    public class LobbyState : IState
    {
        public void HandleInputKeyDown(Form1 context, Keys key)
        {
            switch (key)
            {
                case Keys.Space:
                    context.ClickReady();
                    break;
            }
        }

        public void HandleInputKeyPress(Form1 context, char key)
        {
            
        }
    }
}
