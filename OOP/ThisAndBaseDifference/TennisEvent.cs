using System;
using System.Collections.Generic;
using System.Text;

namespace ThisAndBaseDifference
{
    public class TennisEvent : Event
    {
        public string Name { get; set; }
        public DateTime Duration { get; set; }

        public void Print()
        {
            this.Duration = DateTime.Now;
            base.Duration = 5;
        }
    }  
}
