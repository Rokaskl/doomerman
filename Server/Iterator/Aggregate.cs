using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Iterator
{
    public class Aggregate<T> : IAggregate<T> where T : class
    {
        private ArrayList items = new ArrayList();
        public int Count => this.items.Count;

        public Aggregate(){}
        public Aggregate(ArrayList items)
        {
            this.items = items;
        }

        public IIterator<T> CreateIterator()
        {
            return new Iterator<T>(this);
        }

        public IAggregate<T> Copy()
        {
            return new Aggregate<T>(this.items);
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public IList<T> ToList()
        {
            return this.items.Cast<T>().ToList();
        }

        public T this[int index]
        {
            get
            {
                if (index < this.Count)
                {
                    return (T) items[index];
                }
                else
                {
                    return null;
                }
                
            }
            set
            {
                items.Insert(index, value);
            }
        }
    }
}
