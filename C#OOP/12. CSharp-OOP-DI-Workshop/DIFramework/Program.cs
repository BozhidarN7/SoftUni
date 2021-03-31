using DIFramework.Modules;
using System;

namespace DIFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = InjectorSingleton.Instance.Inject<Engine>();
            engine.ReadFromConsole();
        }
    }
}
