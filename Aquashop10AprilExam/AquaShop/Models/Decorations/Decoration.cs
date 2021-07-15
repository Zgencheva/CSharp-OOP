using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        protected Decoration()
        {
            
        }

        protected Decoration(int comfort, decimal price)
            :this()
        {
            this.Comfort = comfort;
            this.Price = price;
        }
        
        public virtual int Comfort { get; private set; }

        public virtual decimal Price { get; private set; }
    }
}
