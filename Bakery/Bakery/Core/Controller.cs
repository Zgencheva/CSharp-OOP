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
        private ICollection<IBakedFood> foods;
        private IDrink drink;
        private IBakedFood food;
        private ITable table;
        private decimal totalIncome;

        public Controller()
        {
            this.tables = new List<ITable>();
            this.drinks = new List<IDrink>();
            this.foods = new List<IBakedFood>();
            totalIncome = 0;

        }
        public string AddDrink(string type, string name, int portion, string brand)
        {

            if (type == "Tea")
            {
                this.drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                this.drink = new Water(name, portion, brand);

            }

            if (this.drink != null)
            {
                drinks.Add(this.drink);
                return $"{string.Format(Utilities.Messages.OutputMessages.DrinkAdded, this.drink.Name, this.drink.Brand)}";
            }
            else
            {
                return null;
            }


            //return $"Added {this.drink.Name} ({this.drink.Brand}) to the drink menu";


        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                this.food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                this.food = new Cake(name, price);

            }
            foods.Add(this.food);

            //return $"Added {this.drink.Name} ({this.drink.Brand}) to the drink menu";
            return $"{string.Format(Utilities.Messages.OutputMessages.FoodAdded, this.food.Name, this.food.GetType().Name)}";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                this.table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                this.table = new OutsideTable(tableNumber, capacity);
            }

            if (this.table == null)
            {
                return null;
            }
            tables.Add(this.table);

            return $"{string.Format(Utilities.Messages.OutputMessages.TableAdded, tableNumber)}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            List<ITable> freeTables = new List<ITable>();
            foreach (var table in tables)
            {
                if (table.IsReserved == false)
                {
                    freeTables.Add(table);
                }
            }

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
            
            ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            if (table != null)
            {
                var totalTableSum = table.GetBill();

                this.totalIncome += totalTableSum;

                table.Clear();

                var sb = new StringBuilder();
                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {totalTableSum:f2}");

                return sb.ToString().TrimEnd();
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

            IDrink drink = drinks.Where(x => x.Name == drinkName).Where(y => y.Brand == drinkBrand).FirstOrDefault();
            if (drink == null)
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.NonExistentDrink, drinkName, drinkBrand)}";
            }

            table.OrderDrink(drink);
            return $"{string.Format(Utilities.Messages.OutputMessages.DrinkOrderSuccessfull, tableNumber, drinkName, drinkBrand)}";


        }

        public string OrderFood(int tableNumber, string foodName)
        {
            
           ITable table = tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            if (table == null)
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.WrongTableNumber, tableNumber)}";
            }

            IBakedFood food = foods.Where(x => x.Name == foodName).FirstOrDefault();
            if (food == null)
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.NonExistentFood, foodName)}";
            }

            table.OrderFood(food);
            return $"{string.Format(Utilities.Messages.OutputMessages.FoodOrderSuccessful, tableNumber, foodName)}";


        }

        public string ReserveTable(int numberOfPeople)

        {
            ITable table = tables.Where(x => x.Capacity >= numberOfPeople && x.IsReserved == false).FirstOrDefault();
            if (table == null)
            {
                return $"{string.Format(Utilities.Messages.OutputMessages.ReservationNotPossible, numberOfPeople)}";
            }

            table.Reserve(numberOfPeople);
            return $"{string.Format(Utilities.Messages.OutputMessages.TableReserved, table.TableNumber, numberOfPeople)}";

        }
    }
}
