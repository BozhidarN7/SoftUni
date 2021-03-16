using _1.LoggerSOLID.Enums;
using LoggerSOLID.Appenders;
using LoggerSOLID.Core;
using LoggerSOLID.Core.Factories;
using LoggerSOLID.Core.IO;
using LoggerSOLID.Layouts;
using LoggerSOLID.Loggers;
using System;
using System.Collections.Generic;

namespace LoggerSOLID
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new AppenderFactory(), new LayoutFactory(), new FileReader());
            engine.Run();
        }
    }
}
