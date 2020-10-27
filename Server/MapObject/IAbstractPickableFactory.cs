using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject
{
    public interface IAbstractPickableFactory
    {
        Pickable Build(int which, Coordinates xy);
        Pickable GetRandom(Coordinates xy);
    }
}