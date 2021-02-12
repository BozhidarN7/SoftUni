using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _6.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public override int GetHashCode()
        {
            int nameHash = Name.GetHashCode();
            int ageHash = Age.GetHashCode();

            return nameHash + ageHash;
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                return Age.CompareTo(other.Age);
            }
            return result;
        }
    }
}
