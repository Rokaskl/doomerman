using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Iterator
{
    public delegate void foreachHandler<T>(T obj);
    public interface IIterator<T>
    {
        T First();
        T Next();
        bool IsDone();
        T GetCurrentItem();

        public void ForEach(foreachHandler<T> fx);
        public T this[int index] { get; }
    }
}
