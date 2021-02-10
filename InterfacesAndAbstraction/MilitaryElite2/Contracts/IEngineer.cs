using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Models;

namespace MilitaryElite2.Contracts
{
    public interface IEngineer
    {
        public List<Repair> Repairs { get; set; }
    }
}
