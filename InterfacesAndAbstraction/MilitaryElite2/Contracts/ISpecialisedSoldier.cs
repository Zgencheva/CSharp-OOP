using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Enumerations;

namespace MilitaryElite2.Contracts
{
    interface ISpecialisedSoldier : IPrivate
    {
        SoldierCorpEnum soldierCorpEnum { get; }
    }
}
