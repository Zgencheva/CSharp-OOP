using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite2.Models
{
    public class Mission
    {
        private string state;
        public string CodeName { get; set; }
        public string State 
        {
            get
            {
                return this.state;
            }
            set 
            {
                if (value == "Finished" || value == "inProgress")
                {
                    this.state = value;
                }
                else
                {
                    throw new ArgumentException("Invalid mission");
                }
                
            }

        }

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
