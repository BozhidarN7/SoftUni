using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CollectionHierarchy
{
    public interface IAddRemovableCollection<T> : IAddableCollection<T>
    {
        public T Remove();
    }
}
