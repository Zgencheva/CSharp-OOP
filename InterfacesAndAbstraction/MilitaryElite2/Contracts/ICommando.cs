using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Models;

namespace MilitaryElite2.Contracts
{
    public interface ICommando
    {
        public List<Mission> Missions { get;}
    }
}
