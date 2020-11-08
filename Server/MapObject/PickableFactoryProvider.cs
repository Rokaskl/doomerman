using Server.MapObject.PowerUps;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Server.MapObject
{
    public class PickableFactoryProvider
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
        public static Pickable GetRandom(Coordinates xy)
        {
            
            switch (new Random().Next(0, 2))
            {
                case 0:
                    {
                        var fc = new PowerDownFactory();
                        return fc.GetRandom(xy);
                    }
                case 1:
                    {
                        var fc = new PowerUpFactory();
                        return fc.GetRandom(xy);
                    }

                default: return null;
            }
        }
    }
}
