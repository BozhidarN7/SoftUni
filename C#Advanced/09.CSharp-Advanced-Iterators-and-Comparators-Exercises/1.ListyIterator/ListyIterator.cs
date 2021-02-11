using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
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
            if ( index >= collection.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(collection[index]);
        }
    }
}
