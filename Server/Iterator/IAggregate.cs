using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Iterator
{
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
        public T this[int index] { get; set; }
        IAggregate<T> Copy();
        public IList<T> ToList();
        void Add(T item);
        int Count
        {
            get;
        }
    }
}
