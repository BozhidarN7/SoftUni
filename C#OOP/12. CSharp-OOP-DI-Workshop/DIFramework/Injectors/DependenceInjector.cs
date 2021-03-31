using DIFramework.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework.Injectors
{
    public class DependenceInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
