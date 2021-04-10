namespace AquaShop
{
    using System;
    using System.Linq;
    using System.Reflection;
    using AquaShop.Core;
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Repositories.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();

        }
    }
}
