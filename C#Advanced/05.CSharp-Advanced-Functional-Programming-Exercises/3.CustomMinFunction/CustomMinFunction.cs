using System;
using System.Linq;

namespace _3.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> findMinNumber = arr =>
           {
               int min = int.MaxValue;
               for (int i = 0; i < arr.Length; i++)
               {
                   if (min > arr[i])
                   {
                       min = arr[i];
                   }
               }
               return min;
           };
            Console.WriteLine(findMinNumber(Console.ReadLine().Split().Select(int.Parse).ToArray()));
        }


    }
}
