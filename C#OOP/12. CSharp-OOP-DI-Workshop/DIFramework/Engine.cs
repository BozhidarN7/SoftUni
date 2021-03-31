using DIFramework.Attributes;
using DIFramework.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework
{
    public class Engine
    {
        private readonly IReader reader;

        [Inject]
        public Engine(IReader reader)
        {
            this.reader = reader;
        }

        public void ReadFromConsole()
        {
            string input = reader.ReadLine();
            Console.WriteLine(input);
        }
    }
}
