using HAD.Contracts;
using HAD.Core;
using HAD.IO;

namespace HAD
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine(null, null, null);
            engine.Run();
        }
    }
}
