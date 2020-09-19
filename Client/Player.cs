using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    class Player : IDie
    {
        private int ID;

        public bool isReady = false;

        public void Die()
        {
            // Got bombed
        }

        public void UpdatePlayerInfo(int _ID)
        {
            ID = _ID;
        }

        public int GetID()
        {
            return ID;
        }
    }
}
