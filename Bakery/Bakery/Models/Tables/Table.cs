using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private decimal price;
        //private decimal totalBill;
        private ICollection<IBakedFood> foodOrders;
        private ICollection<IDrink> drinkOrders;
        private TableType type;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        
        public int TableNumber { get; private set; }

        public int Capacity {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price {
            get
            {
                return this.PricePerPerson * this.NumberOfPeople; 
            }
           
        
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0; //kogato minavame prez poleto, ne pravi proverkata
        }

        public decimal GetBill()
        {
            decimal finalBill = 0;
            foreach (var food in foodOrders)
            {
                finalBill += food.Price;
            }
            foreach (var drink in drinkOrders)
            {
                finalBill += drink.Price;
            }
            finalBill += this.Price;
            return finalBill;
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {this.TableNumber}\r\n" 
                + $"Type: {this.GetType().Name}\r\n" 
                + $"Capacity: {this.Capacity}\r\n"
                + $"Price per Person: {this.PricePerPerson:F2}";
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Table: {this.TableNumber}");
            //sb.AppendLine($"Type: {this.GetType().Name}");
            //sb.AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            //return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
           
                this.drinkOrders.Add(drink);
            
            
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidNumberOfPeople);
            }
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
