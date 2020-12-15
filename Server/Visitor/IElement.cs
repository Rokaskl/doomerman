using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Visitor
{
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}
