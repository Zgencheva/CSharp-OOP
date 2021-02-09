using System;
using System.Collections.Generic;
using System.Text;

using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        public string ID { get; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
    }
}
