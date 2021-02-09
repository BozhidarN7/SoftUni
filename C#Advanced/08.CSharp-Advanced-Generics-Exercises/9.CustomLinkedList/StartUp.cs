using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            for (int i = 0; i < 5; i++)
            {
                list.AddLast(i + 1);
            }
            list.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());
            int[] arr = list.ToArray();
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
