using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject
{
    class PickableFactoryProvider
    {
        public static IAbstractPickableFactory GetFactory(int which)
        {
            switch (which)
            {
                case 0:
                    return new PowerUpFactory();
                case 1:
                    return new PowerDownFactory();
        

                default: return null;
            }
        }
    }
}
