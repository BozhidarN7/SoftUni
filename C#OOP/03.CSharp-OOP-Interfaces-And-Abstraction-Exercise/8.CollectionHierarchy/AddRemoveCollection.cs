using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CollectionHierarchy
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemovableCollection<T>
    {
        public virtual T Remove()
        {
            T item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return item;
        }
        public override int Add(T element)
        {
            items.Insert(0, element);
            return 0;
        }
    }
}
