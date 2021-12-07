using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();

        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar currentCar;
            if (type == "SuperCar")
            {
                currentCar = new SuperCar(make,model,VIN,horsePower);
               
            }
            else if (type == "TunedCar")
            {
                currentCar = new TunedCar(make, model, VIN, horsePower);
                
            }
            else
            {
                throw new ArgumentException("Invalid car type!");
            }
            cars.Add(currentCar);
            return $"Successfully added car {make} {model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer currentRaces = null;
            ICar currentCar = cars.FindBy(carVIN);
            if (currentCar == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }
            if (type == "ProfessionalRacer")
            {
                currentRaces = new ProfessionalRacer(username, currentCar);
                racers.Add(currentRaces);
                return $"Successfully added racer {username}.";
            }
            else if (type == "StreetRacer")
            {
                currentRaces = new StreetRacer(username, currentCar);
                racers.Add(currentRaces);
                return $"Successfully added racer {username}.";
            }
            else
            {
                throw new ArgumentException("Invalid racer type!");
            }
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);
            if (racerOne is null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }
            if (racerTwo is null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            List<IRacer> OrderRacers = racers.Models.ToList();
            foreach (IRacer racer in OrderRacers.OrderByDescending(x=> x.DrivingExperience).ThenBy(y=> y.Username))
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
