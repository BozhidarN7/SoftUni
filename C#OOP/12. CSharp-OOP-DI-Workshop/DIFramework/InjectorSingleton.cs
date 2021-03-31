using DIFramework.Injectors;
using DIFramework.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIFramework
{
    public class InjectorSingleton
    {
        private static Injector instance;
        public static Injector Instance
        {
            get
            {
                if (instance == null)
                {
                    ConfigureModule configureModule = new ConfigureModule();
                    instance = DependenceInjector.CreateInjector(configureModule);
                }
                return instance;
            }
        }
    }
}
