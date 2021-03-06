﻿using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type classType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
            return (ISet)Activator.CreateInstance(classType,name);
        }
    }




}
