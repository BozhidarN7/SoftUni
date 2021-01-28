using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> printer = str => Console.WriteLine(str);
            Console.ReadLine().Split().ToList().ForEach(x => printer(x));
        }
    }
}
