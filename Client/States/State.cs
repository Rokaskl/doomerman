using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPP
{
    public interface IState
    {
        void HandleInputKeyDown(Form1 context, Keys key);
        void HandleInputKeyPress(Form1 context, char key);
    }
}
