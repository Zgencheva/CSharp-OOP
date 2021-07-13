using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCompositePattern
{
    public class LeafClass : GiftBase
    {
        public LeafClass(string name, int price) 
            : base(name, price)
        {
        }

        public override int CalculatePrice()
        {
            return this.price;
        }
    }
}
