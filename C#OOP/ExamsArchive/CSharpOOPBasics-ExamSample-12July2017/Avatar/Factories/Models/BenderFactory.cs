using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class BenderFactory : IBenderFactory
{
    public IBender CreateBender(List<string> args)
    {
        string benerType = args[0];
        string name = args[1];
        int power = int.Parse(args[2]);
        double secondaryParameter = double.Parse(args[3]);

        Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == benerType + "Bender");
        return (IBender)Activator.CreateInstance(type, name, power, secondaryParameter);

    }
}

