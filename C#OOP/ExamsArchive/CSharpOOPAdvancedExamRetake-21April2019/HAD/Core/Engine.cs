using System;
using System.Collections.Generic;
using System.Linq;
using HAD.Contracts;

namespace HAD.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
        }

        public void Run()
        {
            while (true)
            {
                List<string> arguments = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                string output = this.commandProcessor.Process(arguments);
                this.writer.WriteLine(output);

                if (arguments[0] == "Quit")
                {
                    break;
                }

            }
        }
    }
}