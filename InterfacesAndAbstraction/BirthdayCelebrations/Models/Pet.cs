using System;
using System.Collections.Generic;
using System.Text;

using BirthdayCelebrations.Contracts;

namespace BirthdayCelebrations.Models
{
    public class Pet : IBirthdayable
    {
        public DateTime BirthDate { get;  }

        public string Name { get; set; }

        public Pet(string name, DateTime birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }
    }
}
