namespace PlayersAndMonsters
{
    using Core.Contracts;
    using PlayersAndMonsters.Core.Models;
    using PlayersAndMonsters.IO.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //IManagerController managerController = new ManagerController();
            //managerController.AddPlayer("Advanced", "BozhidarN");
            //managerController.AddPlayer("Beginner", "Ivan");
            //managerController.AddCard("Trap", "Blaster");
            //managerController.AddCard("Magic", "Pulsfire");
            //managerController.AddPlayerCard("BozhidarN", "Blaster");
            //managerController.AddPlayerCard("Ivan", "Pulsfire");
            //Console.WriteLine(managerController.Fight("BozhidarN", "Ivan"));
            //Console.WriteLine(managerController.Report());

            IEngine engine = new Engine(new ConsoleReader(),new ConsoleWriter());
            engine.Run();
        }
    }
}