using System;
using System.Collections.Generic;
using System.Text;

namespace GiftCompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private ICollection<GiftBase> _gift = new List<GiftBase>();
        public CompositeGift(string name, int price) 
            : base(name, price)
        {
        }

        public void Add(GiftBase gift)
        {
            _gift.Add(gift);
        }
        public void Remoce(GiftBase gift)
        {
            _gift.Remove(gift);
        }
        public override int CalculatePrice()
        {
            int totalPrice = 0;
            foreach (var item in _gift)
            {
                totalPrice += item.CalculatePrice();
            }

            return totalPrice;
        }

        
    }
}
