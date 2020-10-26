using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Server.constants
{
    public static class Constants
    {
        public static Random random = new Random();


        public const int UpdateInterval = 25;
        public const int MaxBombLimit = 5;
        public const int MaxBombRadius = 5;


        public const int StartBombRadius = 2;
        public const int StartBombTimeMs= 4000; 
        public const int StartBombLimit = 3;


        public static int next(int a, int b)
        {
            return random.Next(a,b);
        }

    }
}
