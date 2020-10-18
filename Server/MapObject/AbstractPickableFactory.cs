using System;
using System.Collections.Generic;
using System.Text;

namespace Server.MapObject
{
    interface AbstractPickableFactory
    {
        Pickable Build(int which, Coordinates xy);
    }
}