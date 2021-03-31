using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
