using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNum) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNum;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            //Name: <firstName> <lastName> Id: <id>
            //Code Number: < codeNumber >

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
