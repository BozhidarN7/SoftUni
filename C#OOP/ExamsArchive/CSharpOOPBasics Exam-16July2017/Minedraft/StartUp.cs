using System;


class StartUp
{
    static void Main(string[] args)
    {
        IEngine engine = new Engine();
        engine.Run();
    }
}

