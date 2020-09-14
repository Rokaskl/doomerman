using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class Player : Entity, IDie
    {
        int health = 3;
        int score;

        public void Die()
        {
            // Got bombed
        }
    }
}
