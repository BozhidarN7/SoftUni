using _7.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }
        public int CodeNumber { get; private set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Code Number: {CodeNumber}");
            return result.ToString().Trim();
        }
    }
}
