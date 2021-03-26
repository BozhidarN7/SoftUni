using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class Bender : IBender
{
    public Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }
    public string Name { get; private set; }
    public int Power { get; private set; }
    public virtual double BenderPower { get; private set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        PropertyInfo[] properties = GetType().GetProperties().Where(prop => prop.IsDefined(typeof(ElementAttribute), false)).ToArray();

        string property = Helper.GetProperty(properties[0].Name);
        string type = GetType().Name;
        int index = type.IndexOf("Bender");

        result.AppendLine($"{type.Remove(index)} Bender: {Name}, Power: {Power}, {property}: {properties[0].GetValue(this):f2}");
        return result.ToString().TrimEnd();
    }
}

