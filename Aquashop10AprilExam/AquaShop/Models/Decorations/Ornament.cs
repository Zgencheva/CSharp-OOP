using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        public Ornament()
        {
        }

        public override int Comfort => 1;
        public override decimal Price => 5;
    }
}
