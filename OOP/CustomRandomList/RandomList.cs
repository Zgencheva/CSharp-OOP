using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {

        public Random Rand { get; set; }

        public RandomList()
        {
            this.Rand = new Random();
        }

        public string RandomString()
        {
            int index = Rand.Next(0, this.Count);
            string output = this[index];
            this.RemoveAt(index);
            return output;
        }
    }
}
