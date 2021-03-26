using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class Monument : IMonument
{
    public Monument(string name)
    {
        Name = name;
    }
    public string Name { get; private set; }
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        PropertyInfo[] properties = GetType().GetProperties().Where(prop => prop.IsDefined(typeof(ElementAttribute), false)).ToArray();

        string property = Helper.GetProperty(properties[0].Name);
        string type = GetType().Name;
        int index = type.IndexOf("Monument");

        result.AppendLine($"{type.Remove(index)} Monument: {Name}, {property}: {properties[0].GetValue(this)}");

        return result.ToString().TrimEnd();
    }
}

