using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite2.Models
{
    public class Repair
    {
        public string PartName { get; set; }

        public int HoursWorked { get; set; }

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            //Part Name: Boat Hours Worked: 2
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
