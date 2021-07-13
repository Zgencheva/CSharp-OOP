using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCompositePattern
{
    public abstract class GiftBase
    {
        protected GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        protected string name { get; set; }
        protected int price { get; set; }
        public abstract int CalculatePrice();
    }
}
