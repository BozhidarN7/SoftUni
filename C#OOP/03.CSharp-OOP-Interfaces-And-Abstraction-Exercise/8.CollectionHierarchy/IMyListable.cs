using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CollectionHierarchy
{
    interface IMyListable<T> :IAddRemovableCollection<T>
    {
        public int Count { get; }
    }
}
