using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Contracts;

namespace MilitaryElite2.Models
{
    public class Commando : SpecialSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corp) : base(id, firstName, lastName, salary, corp)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; set; }

        public void AddMission(Mission currentMission)
        {
            this.Missions.Add(currentMission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corp}");
            sb.AppendLine("Missions:");
            if (this.Missions.Count != 0)
            {
                foreach (var item in this.Missions)
                {
                    sb.AppendLine("  " + item.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
