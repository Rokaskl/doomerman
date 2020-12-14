using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPP
{
    public class ConnectMenuState : IState
    {
        public void HandleInputKeyDown(Form1 context, Keys key)
        {
            switch (key)
            {
                case Keys.Space:
                    context.ClickJoin();
                    break;
                case Keys.Escape:
                    context.ClickCancel();
                    break;

            }
        }

        public void HandleInputKeyPress(Form1 context, char key)
        {
        }
    }
}
