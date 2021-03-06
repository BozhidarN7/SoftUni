using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CollectionHierarchy
{
    public interface IAddableCollection<T>
    {
        public int Add(T element);
    }
}
