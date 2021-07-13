using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    {
        public Laptop(int id, string manufacturer, string model, decimal price) 
            : base(id, manufacturer, model, price)
        {
        }

        public override double OverallPerformance => base.OverallPerformance + 10;
    }
}
