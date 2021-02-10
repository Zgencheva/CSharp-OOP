using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Models;

namespace MilitaryElite.Contracts
{
    public interface ICommando
    {
        public List<Mission> Missions { get;}
    }
}
