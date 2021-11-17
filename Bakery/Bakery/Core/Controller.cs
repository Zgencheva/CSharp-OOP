using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<ITable> tables;
        private ICollection<IDrink> drinks;
        private ICollection<IBakedFood> bakedFoods;
        //private IDrink drink;
        //private IBakedFood food;
        //private ITable table;
        private decimal totalIncome;

        public Controller()
        {
            this.tables = new List<ITable>();
            this.drinks = new List<IDrink>();
            this.bakedFoods = new List<IBakedFood>();
            totalIncome = 0;

        }
        public string AddDrink(string type, string name, int portion, string brand)
        {

            if (type == "Tea")
            {
                drinks.Add(new Tea(name, portion, brand));
                //this.drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drinks.Add(new Water(name, portion, brand));
                //this.drink = new Water(name, portion, brand);

            }
                //drinks.Add(this.drink);
                return $"{string.Format(Utilities.Messages.OutputMessages.DrinkAdded,name,brand)}";
            
            //return $"Added {this.drink.Name} ({this.drink.Brand}) to the drink menu";

        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                this.bakedFoods.Add(new Bread(name, price));
                //this.food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                this.bakedFoods.Add(new Cake(name, price));
                //this.food = new Cake(name, price);

            }
           //bakedFoods.Add(this.food);

            //return $"Added {this.drink.Name} ({this.drink.Brand}) to the drink menu";
            return $"{string.Format(Utilities.Messages.OutputMessages.FoodAdded, name, type)}";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                tables.Add(new InsideTable(tableNumber, capacity));
            }
            else if (type == "OutsideTable")
            {
                tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return $"{string.Format(Utilities.Messages.OutputMessages.TableAdded, tableNumber)}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            List<ITable> freeTables = tables.Where(table => table.IsReserved == false).ToList();
            
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {

            return $"{string.Format(Utilities.Messages.OutputMessages.TotalIncome, this.totalIncome)}";
        }

        public string LeaveTable(int tableNumber)
        {
            
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table != null)
            {
                var totalTableSum = table.GetBill();

                //this.totalIncome += totalTableSum;
                totalIncome += totalTableSum;
                table.Clear();

                var sb = new StringBuilder();
                return $"Table: {tableNumber}\r\n" +
                $"Bill: {totalTableSum:f2}";

                
            }
            else
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.WrongTableNumber, tableNumber)}";
            }

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            
           ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            if (table == null)
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.WrongTableNumber, tableNumber)}";
            }
            else
            {
                IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
                if (drink == null)
                {
                    return $"{string.Format(Utilities.Messages.OutputMessages.NonExistentDrink, drinkName, drinkBrand)}";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"{string.Format(Utilities.Messages.OutputMessages.DrinkOrderSuccessfull, tableNumber, drinkName, drinkBrand)}";
                }

                
            }
           


        }

        public string OrderFood(int tableNumber, string foodName)
        {
            
           ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.WrongTableNumber, tableNumber)}";
            }
            else
            {
                IBakedFood food = bakedFoods.Where(x => x.Name == foodName).FirstOrDefault();
                if (food == null)
                {
                    return $"{string.Format(Utilities.Messages.OutputMessages.NonExistentFood, foodName)}";
                }
                else
                {
                    table.OrderFood(food);
                    return $"{string.Format(Utilities.Messages.OutputMessages.FoodOrderSuccessful, tableNumber, foodName)}";
                }

            }      

        }

        public string ReserveTable(int numberOfPeople)

        {
            ITable table = tables.Where(x => x.IsReserved == false && x.Capacity >= numberOfPeople).FirstOrDefault();
            if (table == null)
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.ReservationNotPossible, numberOfPeople)}";
            }

            table.Reserve(numberOfPeople);
            return $"{string.Format(Utilities.Messages.OutputMessages.TableReserved, table.TableNumber, numberOfPeople)}";

        }
    }
}
