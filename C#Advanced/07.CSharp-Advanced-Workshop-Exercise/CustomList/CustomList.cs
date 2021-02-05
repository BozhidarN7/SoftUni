using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    public class CustomList : IEnumerable
    {
        private const int initialCapacity = 2;
        private int[] array;

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return array[index];
            }
            set
            {
                ValidateIndex(index);
                array[index] = value;
            }
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);

            int number = array[index];
            array[index] = default;
            Shift(index);
            Count--;

            if (Count == array.Length / 4)
            {
                Shrink();
            }

            return number;
        }
        public void Insert(int index, int number)
        {
            if (index > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
            if (Count == array.Length)
            {
                Resize();
            }
            ShiftRight(index);
            array[index] = number;
            Count++;
        }

        public void Swap(int firstIndex, int secondIndes)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndes);

            int firstNum = array[firstIndex];
            array[firstIndex] = array[secondIndes];
            array[secondIndes] = firstNum;
        }

        public bool Contains(int number)
        {
            for (int i = 0; i < Count;i++)
            {
                if (array[i] == number)
                {
                    return true;
                }
            }
            return false;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count ; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[array.Length / 2];
            Array.Copy(array, copy, Count);
            array = copy;
        }
        private void Shift(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[Count - 1] = default;
        }

        private void ValidateIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
        }

        public CustomList()
        {
            array = new int[initialCapacity];
        }
        public void Add(int number)
        {
            if (Count == initialCapacity)
            {
                Resize();
            }

            array[Count] = number;
            Count++;
        }

        private void Resize()
        {
            int[] copy = new int[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            array = copy;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }
    }
}
