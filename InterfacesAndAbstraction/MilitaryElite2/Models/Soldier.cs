﻿using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Contracts;

namespace MilitaryElite2.Models
{
    public class Soldier : ISoldier
    {
        public int Id { get; }

        public string FirstName { get;  }

        public string LastName { get; }

        public Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
