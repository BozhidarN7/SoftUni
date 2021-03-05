using _7.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
    interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }
        public void AddPrivate(IPrivate @private);
    }
}
