using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanetsCount = 0;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut current = null;
            if (type == "Biologist")
            {
                current = new Biologist(astronautName);
              
            }
            else if (type == "Geodesist")
            {
                current = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                current = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astronauts.Add(current);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet current = new Planet(planetName);
            current.AddItems(items);
            planets.Add(current);
           return $"Successfully added Planet: {planetName}!";
        }
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut toReite = astronauts.FindByName(astronautName);
            if (toReite is null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            else
            {
                astronauts.Remove(toReite);
                return $"Astronaut {astronautName} was retired!";
            }
        }
        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = astronauts.Models.Where(x=> x.Oxygen > 60).ToList();
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            IMission currentMission = new Mission();
            IPlanet currentPlanet = planets.Models.FirstOrDefault(x=> x.Name == planetName);
            currentMission.Explore(currentPlanet, suitableAstronauts);
            exploredPlanetsCount++;
            int deadAstronauts = currentMission.TakeDeathAstronauts();
            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";

        }

        public string Report()
        {
            List<IAstronaut> astronautsList = astronauts.Models.ToList();
            string astonautResult = null;
            for (int i = 0; i < astronautsList.Count; i++)
            {
                if (i == astronautsList.Count - 1)
                {
                    astonautResult += astronautsList[i].ToString().TrimEnd();
                }
                else
                {
                    astonautResult += astronautsList[i].ToString();
                }
            }
            return $"{exploredPlanetsCount} planets were explored!\r\n" +
                "Astronauts info:\r\n" +
                astonautResult.TrimEnd();
            



        }

        
    }
}
