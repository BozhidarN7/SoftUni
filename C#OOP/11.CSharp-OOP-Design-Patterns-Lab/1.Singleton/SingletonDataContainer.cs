using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _1.Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();
        private static SingletonDataContainer instance = new SingletonDataContainer();
        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            string[] elements = File.ReadAllLines("../../../capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }
        public int GetPopulatoin(string name)
        {
            return _capitals[name];
        }

        public static SingletonDataContainer Instance => instance;
    }
}
