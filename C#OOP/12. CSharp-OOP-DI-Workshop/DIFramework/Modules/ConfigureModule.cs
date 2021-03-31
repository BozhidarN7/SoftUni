using DIFramework.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.Modules
{
    public class ConfigureModule : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
        }
    }
}
