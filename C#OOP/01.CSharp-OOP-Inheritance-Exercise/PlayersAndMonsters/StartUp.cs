namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Knight knight = new Knight("zombi200", 20);
            System.Console.WriteLine(knight.GetType().Name);
        }
    }
}