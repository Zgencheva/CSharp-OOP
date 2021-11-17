using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.5m;

        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }

       // public override decimal PricePerPerson => InitialPricePerPerson;
       // public override decimal Price => base.NumberOfPeople * this.PricePerPerson;
    }
}
