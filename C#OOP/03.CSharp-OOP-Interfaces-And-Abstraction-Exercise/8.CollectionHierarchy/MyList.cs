using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CollectionHierarchy
{
    public class MyList<T> : AddRemoveCollection<T>, IMyListable<T>
    {
        public int Count => items.Count;

        public override T Remove()
        {
            T item = items[0];
            items.RemoveAt(0);
            return item;
        }
    }
}
