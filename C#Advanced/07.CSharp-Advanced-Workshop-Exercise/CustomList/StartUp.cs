using System;

namespace CustomList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Insert(1, 5);

            Console.WriteLine("-------------------------------");
            list.Swap(2, 3);
            foreach (int num in list)
            {
                Console.WriteLine(num);
            }
        }
    }
}
