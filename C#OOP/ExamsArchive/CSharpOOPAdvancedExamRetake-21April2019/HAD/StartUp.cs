using HAD.Core;
using HAD.IO;
using System.Collections.Generic;

namespace HAD
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new CommandProcessor(new HeroManager()));
            engine.Run();

        }
    }
}
