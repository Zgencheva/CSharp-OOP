using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Contracts;
using MilitaryElite2.Enumerations;

namespace MilitaryElite2.Models
{
    public class SpecialSoldier : Private, ISpecialisedSoldier
    {
        private string corp;
        public SpecialSoldier(int id, string firstName, string lastName, decimal salary, string corp, SoldierCorpEnum soldierCorpEnum)
            : base(id, firstName, lastName, salary)
        {
            this.soldierCorpEnum = soldierCorpEnum;
        }
        public SoldierCorpEnum soldierCorpEnum { get; }
        //public string Corp 
        //{ 
        //    get 
        //    {
        //        return this.corp;
        //    } set
        //    {
        //        if (value == "Airforces" || value == "Marines")
        //        {
        //            this.corp = value;
        //        }

        //        else
        //        {
        //            throw new ArgumentException("No such corp");
        //        }
        //    }
        //}


    }
}
