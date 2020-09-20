using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPP
{
    public sealed class ClientManager
    {
        private static ClientManager instance = null;
        private static readonly object padlock = new object();

        private int currentPlayerID = -1;   // ID representing the Player (0-3)
        private int score;                  // NOT IMPLEMENTED

        ClientManager()
        {
        }

        public static ClientManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ClientManager();
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// Returns the Player's ID (if it's set)
        /// </summary>
        /// <returns>currentPlayerID</returns>
        public int GetPlayerID()
        {
            if (IDIsSet())
            {
                return currentPlayerID;
            }

            throw new System.Exception("Trying to get Player's ID before setting it");
        }

        /// <summary>
        /// Sets the Player's ID
        /// </summary>
        /// <param name="id"></param>
        public void SetPlayerID(int id)
        {
            if (id >= 0 && id <= 3)
            {
                currentPlayerID = id;
                return;
            }

            throw new System.Exception(string.Concat("Trying to set Player's ID to an invalid value: ", id, ". Please considering using a number in range [0, 3]"));
        }

        /// <summary>
        /// Check's if the Player's ID is set
        /// </summary>
        /// <returns></returns>
        public bool IDIsSet()
        {
            if (currentPlayerID < 0)
                return false;
            else return true;
        }
    }
}

