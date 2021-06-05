using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LimitedMemory
{
    public class LimitedMemoryCollection<K, V> : ILimitedMemoryCollection<K, V>
    {
        public LimitedMemoryCollection(int capacity)
        {
            
        } 

        public IEnumerator<Pair<K, V>> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public void Set(K key, V value)
        {
            throw new System.NotImplementedException();
        }

        public V Get(K key)
        {
            throw new System.NotImplementedException();
        }
    }
}
