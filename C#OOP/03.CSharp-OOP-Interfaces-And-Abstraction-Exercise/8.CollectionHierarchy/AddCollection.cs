using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CollectionHierarchy
{
    public class AddCollection<T> : IAddableCollection<T>
    {
        protected List<T> items;

        public AddCollection()
        {
            items = new List<T>();
        }
        public virtual int Add(T element)
        {
            items.Add(element);
            return items.Count - 1;
        }
    }
}
