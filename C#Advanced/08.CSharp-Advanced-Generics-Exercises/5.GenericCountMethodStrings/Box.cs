using System;
using System.Collections.Generic;
using System.Text;

namespace _5.GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public static void Swap(List<Box<T>> boxes, int first, int second)
        {
            Box<T> temp = boxes[first];
            boxes[first] = boxes[second];
            boxes[second] = temp;
        }

        public static int FindEqualElToGiven(List<Box<T>> boxes, T element)
        {
            int count = 0;
            foreach(Box<T> box in boxes)
            {
                if (box.value.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {value}";
        }

    }
}
