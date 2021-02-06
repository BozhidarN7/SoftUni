using System.Collections.Generic;

namespace BoxOfT
{
    public class BoxOfT<T>
    {
        private Stack<T> stack;

        public BoxOfT()
        {
            stack = new Stack<T>();
        }
        public int Count { get; private set; }

        public void Add(T element)
        {
            stack.Push(element);
            Count++;
        }
        public T Remove()
        {
            Count--;
            return stack.Pop();

        }
    }
}
