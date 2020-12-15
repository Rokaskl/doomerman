using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPP
{
    public class GameState : IState
    {
        public void HandleInputKeyDown(Form1 context, Keys key)
        {
            switch (key)
            {
                case Keys.Space:
                    context.SendSignal(4, CommandTypeEnum.Arena);
                    break;
            }
        }

        public void HandleInputKeyPress(Form1 context, char key)
        {
            switch (key)
            {
                case 'a':
                case 'A':
                    context.SendSignal(2, CommandTypeEnum.Arena);
                    break;
                case 'w':
                case 'W':
                    context.SendSignal(0, CommandTypeEnum.Arena);
                    break;
                case 's':
                case 'S':
                    context.SendSignal(1, CommandTypeEnum.Arena);
                    break;
                case 'd':
                case 'D':
                    context.SendSignal(3, CommandTypeEnum.Arena);
                    break;
            }
        }
    }
}
