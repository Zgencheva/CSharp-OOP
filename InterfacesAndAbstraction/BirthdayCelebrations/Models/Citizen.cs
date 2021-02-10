using System;
using System.Collections.Generic;
using System.Text;

using BirthdayCelebrations.Contracts;

namespace BirthdayCelebrations.Models
{
    public class Citizen : IBirthdayable, IBuyer
    {
        public DateTime BirthDate { get; }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public int Food { get; set; }

        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            this.BirthDate = birthdate;
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
