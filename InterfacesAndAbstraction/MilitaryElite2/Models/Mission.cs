using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Contracts;
using MilitaryElite2.Enumerations;

namespace MilitaryElite2.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEn)
        {
            this.CodeName = codeName;
            this.missionStateEnum = missionStateEn;
        }
        
        public MissionStateEnum missionStateEnum { get; }

        public string CodeName { get; set; }

        public void CompleteMission(string missionName)
        {
           
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.missionStateEnum.ToString()}";
        }

        
    }
}
