namespace TheTankGame
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IBattleOperator battleOperator = new TankBattleOperator();
            IManager manager = new TankManager(battleOperator);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

            IEngine engine = new Engine(
                reader,
                writer,
                commandInterpreter);

            engine.Run();
        }
    }
}
