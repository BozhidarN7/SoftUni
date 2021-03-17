using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Class under investigation: {classToInvestigate}");

            Type classType = Type.GetType(classToInvestigate);
            Object classInstance = Activator.CreateInstance(classType);

            FieldInfo[] fields = classType
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                .Where(f => fieldsToInvestigate.Contains(f.Name)).ToArray();
            foreach(FieldInfo field in fields)
            {
                result.AppendLine($"{field.Name} = { field.GetValue(classInstance)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
