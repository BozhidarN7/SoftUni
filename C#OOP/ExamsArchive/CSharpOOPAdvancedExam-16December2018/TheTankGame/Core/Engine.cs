namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO.Contracts;
    using TheTankGame.IO;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            while (true)
            {
                List<string> args = reader.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
                string result = commandInterpreter.ProcessInput(args);
                writer.WriteLine(result);
                if (args.Count == 0)
                {
                    break;
                }
            }
            //Console.WriteLine(((ConsoleWriter)writer).result.ToString().TrimEnd());
        }
    }
}