using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
       
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
      

        protected Computer(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();

        }


        public override double OverallPerformance  //=> base.OverallPerformance + this.Components.Average(x=> x.OverallPerformance);
        {
            get
            {
                double result = 0;
                if (this.Components.Count == 0)
                {
                    result = base.OverallPerformance;
                }
                else
                {
                    result = base.OverallPerformance + this.Components.Average(x=> x.OverallPerformance);
                }
                return result;
            }
            
        }

           
        
        public override decimal Price => base.Price + this.Components.Sum(x => x.Price) + this.Peripherals.Sum(y=> y.Price);

        public void AddComponent(IComponent component)
        {
            if (Components.Contains(component))
            {
                //public const string ExistingComponent = "Component {0} already exists in {1} with Id {2}.";
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            else
            {
                components.Add(component);
               
                //public const string AddedComponent = "Component {0} with id {1} added successfully in computer with id {2}.";
                //Console.WriteLine(string.Format(SuccessMessages.AddedComponent, component.GetType(), component.Id, this.Id));
            }
        }


        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Contains(peripheral))
            {
                // public const string ExistingPeripheral = "Peripheral {0} already exists in {1} with Id {2}.";
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            else
            {
                peripherals.Add(peripheral);
                //public const string AddedPeripheral = "Peripheral {0} with id {1} added successfully in computer with id {2}.";
                //Console.WriteLine(string.Format(Common.Constants.SuccessMessages.AddedComponent, peripheral.GetType(), peripheral.Id, this.Id));
            }
        }

        public IComponent RemoveComponent(string componentType)
        {

            IComponent removedComp = null;
            removedComp = components.Where(x => x.GetType().Name == componentType).FirstOrDefault();
            if (removedComp == null)
            {
                //"Component {0} does not exist in {1} with Id {2}.";
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }
            else
            {
                components.Remove(removedComp);
                //"Successfully removed {0} with id {1}.";
                //Console.WriteLine(string.Format(Common.Constants.SuccessMessages.RemovedComponent, removedComp.GetType(), removedComp.Id));
            }
            return removedComp;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral removedPeripheral = null;
            removedPeripheral = peripherals.Where(x => x.GetType().Name == peripheralType).FirstOrDefault();
            if (removedPeripheral == null)
            {
                //"Peripheral {0} does not exist in {1} with Id {2}.";
                throw new ArgumentException(string.Format(Common.Constants.ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }
            else
            {
                peripherals.Remove(removedPeripheral);
                //"Successfully removed {0} with id {1}.";
                //Console.WriteLine(string.Format(Common.Constants.SuccessMessages.RemovedComponent, removedPeripheral.GetType(), removedPeripheral.Id));
            }
            return removedPeripheral;
        }
        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString().TrimEnd());
            sb.AppendLine($" Components ({Components.Count}):".TrimEnd());
            if (Components.Count !=0)
            {
                sb.Append("  ");
                sb.AppendLine(string.Join("\n  ", this.Components).TrimEnd());
                //sb.AppendLine($"{string.Join("\n  ", this.Components)});
            }
            if (Peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance (0.00):".TrimEnd());
            }
            else
            {
                sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(x => x.OverallPerformance):f2}):");
                sb.Append("  ");
                sb.AppendLine(string.Join("\n  ", this.Peripherals).TrimEnd());
            }
        // $"{string.Join("\n  ", Peripherals)}";

            return sb.ToString().TrimEnd().TrimEnd();
        }
    }
}
