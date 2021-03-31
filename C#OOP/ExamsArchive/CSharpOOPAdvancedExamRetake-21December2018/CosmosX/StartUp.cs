using CosmosX.Core;
using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Reactors;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.IO;
using CosmosX.IO.Contracts;
using System;
using System.Reflection;

namespace CosmosX
{
    public class StartUp
    {
        public static void Main()
        {
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();
            //IManager reactorManager = new ReactorManager();

            //ICommandParser commandParser = new CommandParser(reactorManager);
            //IEngine engine = new Engine(reader, writer, commandParser);
            //engine.Run();

            IReactor reactor = new ReactorFactory().CreateReactor("Test", 5, new ModuleContainer(4), 56);
            Console.WriteLine(reactor.GetType().Name);
        }
    }
}
