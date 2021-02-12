using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> collection;
        private int index;
        public ListyIterator(params T[] data)
        {
            index = 0;
            this.collection = new List<T>(data);
        }

        public bool Move()
        {
            if (index < collection.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (index + 1 < collection.Count)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {
            if (index >= collection.Count || collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(collection[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
