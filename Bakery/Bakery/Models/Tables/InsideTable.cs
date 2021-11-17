﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal InitialPricePerPerson = 2.5m;

        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }

        //public override decimal PricePerPerson => InitialPricePerPerson;
        //public override decimal Price => base.NumberOfPeople * this.PricePerPerson;

    }
}
