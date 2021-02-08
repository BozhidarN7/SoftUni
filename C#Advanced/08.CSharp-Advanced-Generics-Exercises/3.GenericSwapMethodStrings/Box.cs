using System;
using System.Collections.Generic;
using System.Text;

namespace _3.GenericSwapMethodStrings
{
    public class Box<T>
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

        public override string ToString()
        {
            return $"{typeof(T)}: {value}";
        }
    }
}
