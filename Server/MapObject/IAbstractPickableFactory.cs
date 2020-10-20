using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject
{
    interface IAbstractPickableFactory
    {
        Pickable Build(int which, Coordinates xy);
    }
}