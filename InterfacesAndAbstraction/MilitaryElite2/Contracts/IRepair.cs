using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite2.Contracts
{
    public interface IRepair
    {
        public string PartName { get; }

        public int HoursWorked { get; }
    }
}
