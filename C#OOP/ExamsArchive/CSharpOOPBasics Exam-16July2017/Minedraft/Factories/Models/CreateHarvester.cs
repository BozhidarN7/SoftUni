using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class CreateHarvester : ICreateHarvester
{
    KeyValuePair<Harvester, string> ICreateHarvester.CreateHarvester(List<string> args)
    {
        string harvesterType = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]); ;

        Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name.StartsWith(harvesterType));
        if (type == null)
        {
            return new KeyValuePair<Harvester, string>(null, "Type");
        }

        try
        {
            if (harvesterType == "Sonic")
            {
                int sonicFactor = int.Parse(args[4]);
                //KeyValuePair<Harvester, string> pair = new KeyValuePair<Harvester, string>((SonicHarvester)Activator
                //    .CreateInstance(type, id, oreOutput, energyRequirement, sonicFactor), null);
                KeyValuePair<Harvester, string> pair = new KeyValuePair<Harvester, string>(new SonicHarvester(
                    id, oreOutput, energyRequirement,sonicFactor), null);
                return pair;
            }
            else
            {
                //KeyValuePair<Harvester, string> pair = new KeyValuePair<Harvester, string>((Harvester)Activator
                //    .CreateInstance(type, id, oreOutput, energyRequirement), null);
                KeyValuePair<Harvester, string> pair = new KeyValuePair<Harvester, string>(new HammerHarvester(
                   id, oreOutput, energyRequirement), null);
                return pair;
            }
        }
        catch (ArgumentException ex)
        {
            return new KeyValuePair<Harvester, string>(null, ex.Message);
        }
    }
}

