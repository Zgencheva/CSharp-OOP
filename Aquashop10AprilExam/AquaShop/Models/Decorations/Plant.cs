using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        public Plant()
        {
        }

        public override decimal Price => 10;
        public override int Comfort => 5;
    }
}
