using System;
using System.Collections.Generic;
using System.Text;

namespace InternalDemo
{
    public class ShavingFoam : Product
    {
        public bool CanBuy(int money)
        {
            return money > base.Price;
        }
    }
}
