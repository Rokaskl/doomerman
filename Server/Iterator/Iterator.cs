using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Server.Iterator
{
    public class Iterator<T> : IIterator<T> where T : class
    {
        private IAggregate<T> aggregate;
        private int current = 0;

        public T this[int index] => this.aggregate[index];

        public Iterator(IAggregate<T> aggregate)
        {
            this.aggregate = aggregate;
        }

        public T First()
        {
            return this.aggregate[0];
        }

        public T GetCurrentItem()
        {
            return this.aggregate[this.current];
        }

        public bool IsDone()
        {
            return this.current > this.aggregate.Count;
        }

        public T Next()
        {
            return this.aggregate[++this.current];
        }

        public void ForEach(foreachHandler<T> fx)
        {
            T item = this.GetCurrentItem();
            while (item != null)
            {
                fx(item);
                item = this.Next();
            }
        }
    }
}
