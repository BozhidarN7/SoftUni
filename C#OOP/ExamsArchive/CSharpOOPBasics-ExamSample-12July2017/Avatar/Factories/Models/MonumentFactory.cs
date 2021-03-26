using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class MonumentFactory : IMonumentFactory
{
    public IMonument CreateMonument(List<string> args)
    {
        string monumentType = args[0];
        string name = args[1];
        int affinity = int.Parse(args[2]);

        Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == monumentType + "Monument");
        return (IMonument)Activator.CreateInstance(type, name, affinity);
    }
}

