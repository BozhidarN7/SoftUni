using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        private const int initialCapacity = 4;
        private int[] array;

        public CustomStack()
        {
            array = new int[initialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (Count == array.Length)
            {
                Resize();
            }

            array[Count] = element;
            Count++;
        }

        public int Pop()
        {
            Validate();

            int element = array[Count - 1];
            array[Count - 1] = default;
            Count--;
            if (Count == array.Length / 4)
            {
                Shrink();
            }
            return element;
        }
        public int Peek()
        {
            Validate();

            return array[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(array[i]);
            }
        }
        private void Validate()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }


        private void Shrink()
        {
            int[] copy = new int[array.Length / 2];
            Array.Copy(array, copy, Count);
            array = copy;
        }

        private void Resize()
        {
            int[] copy = new int[array.Length * 2];
            Array.Copy(array, copy, Count);
            array = copy;
        }
    }
}
