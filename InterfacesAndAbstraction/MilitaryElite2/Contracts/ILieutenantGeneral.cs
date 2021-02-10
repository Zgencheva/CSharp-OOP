using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite2.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public List<ISoldier> Privates { get; }
    }
}
