using System;

namespace _1.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            ISingletonContainer db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulatoin("Plovdiv"));
        }
    }
}
