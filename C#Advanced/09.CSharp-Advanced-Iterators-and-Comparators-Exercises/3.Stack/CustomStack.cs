using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3.Stack
{
    public class CustomStack : IEnumerable<int>
    {
        private readonly List<int> elements;

        public CustomStack()
        {
            this.elements = new List<int>();
        }

        public void Push(List<int> items)
        {
            foreach (int item in items)
            {
                elements.Add(item);
            }
        }

        public void Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            elements.RemoveAt(elements.Count - 1);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
