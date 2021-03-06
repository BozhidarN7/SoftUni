using System;

namespace _8.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IAddableCollection<string> addCollection = new AddCollection<string>();
            IAddRemovableCollection<string> addRemoveColletion = new AddRemoveCollection<string>();
            IAddRemovableCollection<string> myList = new MyList<string>();

            string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            AddElements(elements, addCollection);
            AddElements(elements, addRemoveColletion);
            AddElements(elements, myList);

            int itemsToRemoe = int.Parse(Console.ReadLine());
            RemoveElements(addRemoveColletion, itemsToRemoe);
            RemoveElements(myList, itemsToRemoe);
        }

        private static void RemoveElements(IAddRemovableCollection<string> collection, int itemsToRemoe)
        {
            for (int i = 0; i< itemsToRemoe; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }

        private static void AddElements(string[] elements, IAddableCollection<string> collection)
        {
            foreach(string element in elements)
            {
                int index = collection.Add(element);
                Console.Write(index + " ");
            }
            Console.WriteLine();
        }
    }
}
