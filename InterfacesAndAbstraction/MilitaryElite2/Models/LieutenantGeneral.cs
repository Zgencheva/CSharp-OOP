using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MilitaryElite2.Contracts;

namespace MilitaryElite2.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<ISoldier>();
        }

        public ICollection<ISoldier> Privates { get; set; }

        public void AddPriveteToList(List<ISoldier> allSoldiers, int privateID)
        {
            this.Privates.Add(allSoldiers.Where(x => x.Id == privateID && x is Private).FirstOrDefault());

        }

        public override string ToString()
        {
            //Name: <firstName> <lastName> Id: <id> Salary: <salary>
            //Privates:
            // < private1 ToString() >

            // < private2 ToString() >
            // …
            // < privateN ToString() >
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine("Privates:");
            if (this.Privates.Count != 0)
            {
                foreach (var item in this.Privates)
                {
                    sb.AppendLine("  " + item.ToString());
                }
            }

            return sb.ToString().TrimEnd();

        }

    }
}
