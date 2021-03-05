using _7.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<IPrivate>();
        }
        public IReadOnlyCollection<IPrivate> Privates => privates.AsReadOnly();

        public void AddPrivate(IPrivate @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Privates:");
            foreach(IPrivate @private in privates)
            {
                result.AppendLine($"  {@private}");
            }
            return result.ToString().Trim();
        }
    }
}
