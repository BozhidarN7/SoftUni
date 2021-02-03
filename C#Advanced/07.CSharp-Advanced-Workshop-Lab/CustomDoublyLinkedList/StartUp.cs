using System;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomLinkedList linkedList = new CustomLinkedList();

            for (int i = 0; i < 5; i++)
            {
                linkedList.AddLast(new Node(i + 1));
            }
            linkedList.ForEachFromTail(node => Console.WriteLine(node.Value));

            Node node = linkedList.RemoveTail();
            Console.WriteLine(node.Value);
            linkedList.ForEachFromHead((node) => Console.WriteLine(node.Value));
            //node = linkedList.RemoveTail();
            int[] array = linkedList.ToArray();
            Console.WriteLine(string.Join(" ", array));

        }
    }
}
