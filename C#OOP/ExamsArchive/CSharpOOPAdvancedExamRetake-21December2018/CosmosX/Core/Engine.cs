using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System.Linq;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
        }

        public void Run()
        {
            while (true)
            {
                string[] tokens = reader.ReadLine().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

                string result = commandParser.Parse(tokens.ToList());
                writer.WriteLine(result);
                if (tokens[0] == "Exit")
                {
                    break;
                }
            }
        }
    }
}