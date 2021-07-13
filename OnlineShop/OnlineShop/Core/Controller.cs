using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Common.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//using System.ComponentModel;
using OnlineShop.Models.Products.Components;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;


        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            IComputer currentComp = null;
            if (computerType == "DesktopComputer")
            {
                currentComp = new DesktopComputer(id, manufacturer, model, price);
                computers.Add(currentComp);
                return string.Format(SuccessMessages.AddedComputer, currentComp.Id);
                //return $"Computer with id {id} added successfully.";
            }
            else if (computerType == "Laptop")
            {
                currentComp = new Laptop(id, manufacturer, model, price);

                computers.Add(currentComp);
                return string.Format(SuccessMessages.AddedComputer, currentComp.Id);
            }
            else
            {
                //public const string InvalidComputerType = "Computer type is invalid.";
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer currentComputer = computers.Where(x => x.Id == computerId).FirstOrDefault();
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            IComponent currentComponent = null;
            if (componentType == "Motherboard")
            {
                currentComponent = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "CentralProcessingUnit")
            {
                currentComponent = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "PowerSupply")
            {
                currentComponent = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                currentComponent = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == "SolidStateDrive")
            {
                currentComponent = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                currentComponent = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            currentComputer.AddComponent(currentComponent);
            components.Add(currentComponent);
            return string.Format(SuccessMessages.AddedComponent, currentComponent.GetType().Name, currentComponent.Id, currentComputer.Id);


        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer currentComputer = computers.Where(x => x.Id == computerId).FirstOrDefault();
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IPeripheral currentPeripheral = null;
            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            if (peripheralType == "Headset")
            {
                currentPeripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);

            }
            else if (peripheralType == "Keyboard")
            {
                currentPeripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);

            }
            else if (peripheralType == "Monitor")
            {
                currentPeripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);

            }
            else if (peripheralType == "Mouse")
            {
                currentPeripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);

            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            currentComputer.AddPeripheral(currentPeripheral);
            peripherals.Add(currentPeripheral);
            //public const string AddedComponent = "Component {0} with id {1} added successfully in computer with id {2}.";
            return string.Format(SuccessMessages.AddedPeripheral, currentPeripheral.GetType().Name, currentPeripheral.Id, currentComputer.Id);

        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComponent currentComponent = null;
            IComputer currentComputer = computers.Where(x => x.Id == computerId).FirstOrDefault();
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            currentComponent = currentComputer.RemoveComponent(componentType);
            //public const string RemovedComponent = "Successfully removed {0} with id {1}.";
            return string.Format(SuccessMessages.RemovedComponent, currentComponent.GetType().Name, currentComponent.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IPeripheral currentPeripheral = null;
            IComputer currentComp = computers.Where(x => x.Id == computerId).FirstOrDefault();
            if (currentComp == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            currentPeripheral = currentComp.RemovePeripheral(peripheralType);
            return string.Format(SuccessMessages.RemovedPeripheral, currentPeripheral.GetType().Name, currentPeripheral.Id);
        }
        public string BuyBest(decimal budget)
        {
            var topCompter = computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(y => y.OverallPerformance)
                .FirstOrDefault();
            if (topCompter == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(topCompter);
            return topCompter.ToString();


        }

        public string BuyComputer(int id)
        {
            IComputer bought = computers.FirstOrDefault(x => x.Id == id);
            if (bought == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            computers.Remove(bought);
            return bought.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers.Where(x => x.Id == id).FirstOrDefault();
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            return computer.ToString().TrimEnd();
        }


    }
}
