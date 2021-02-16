using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Food : IFood

    {
        public int Quantity { get; }

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
