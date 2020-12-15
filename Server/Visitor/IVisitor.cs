using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Visitor
{
    public interface IVisitor
    {
        void Visit(IElement element);
    }
}
