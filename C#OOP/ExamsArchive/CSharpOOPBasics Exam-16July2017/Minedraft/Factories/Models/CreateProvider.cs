using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Minedraft.Factories.Models
{
    public class CreateProvider : ICreateProvider
    {
        KeyValuePair<Provider, string> ICreateProvider.CreateProvider(List<string> args)
        {
            string providerType = args[0];
            string id = args[1];
            double energyOutput = double.Parse(args[2]);
            try
            {
                if (providerType == "Solar")
                {
                    KeyValuePair<Provider, string> pair = new KeyValuePair<Provider, string>(new SolarProvider(
                        id, energyOutput), null);
                    return pair;
                }
                else if (providerType == "Pressure")
                {
                    KeyValuePair<Provider, string> pair = new KeyValuePair<Provider, string>(new PressureProvider(
                       id, energyOutput), null);
                    return pair;
                }
                else
                {
                    return new KeyValuePair<Provider, string>(null, "Type");
                }
            }
            catch (ArgumentException ex)
            {
                return new KeyValuePair<Provider, string>(null, ex.Message);
            }
        }
    }
}
