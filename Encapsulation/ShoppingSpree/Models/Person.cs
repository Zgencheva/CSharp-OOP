using System;
using System.Collections.Generic;
using System.Text;

using ShoppingSpree.Common;

namespace ShoppingSpree
{
    public class Person
    {
        private const string CNT_AFFORD_PRODUCT_MSG = "{0} can't afford {1}";
        private const string PRODUCT_BOUGHT_MSG = "{0} bought {1}";
        
        private string name;
        private decimal money;
        private readonly ICollection<Product> bagOfProducts;

        //private constructor only for initializing the list
        private Person()
        {
            this.bagOfProducts = new List<Product>();
        }
        public Person(string name, decimal money)
            :this()
        {
            this.Name = name;
            this.Money = money;
            
        }
        public string Name 
        { 
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExpMsg);
                }
                this.name = value;
            } 
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NegMoneyExpMsg);
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get 
            {
                return (IReadOnlyCollection<Product>)this.bagOfProducts;
            }
            

        }

        public string BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.bagOfProducts.Add(product);
                return string.Format(PRODUCT_BOUGHT_MSG, this.Name, product.Name);
            }
            else
            {
                return string.Format(CNT_AFFORD_PRODUCT_MSG, this.Name, product.Name);
            }
        }

        
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.name} - ");
            if (bagOfProducts.Count == 0)
            {
                sb.AppendLine("Nothing bought ");
            }
            else
            {
            sb.AppendLine(string.Join(", ", bagOfProducts));

            }
            return sb.ToString().TrimEnd();
        }
    }
} 
