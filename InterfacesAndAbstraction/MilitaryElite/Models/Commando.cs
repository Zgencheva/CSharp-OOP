using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite.Contracts;

namespace MilitaryElite.Models
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
            sb.AppendLine(string.Join(Environment.NewLine, this.Missions));

            return sb.ToString().TrimEnd();
        }
    }
}
