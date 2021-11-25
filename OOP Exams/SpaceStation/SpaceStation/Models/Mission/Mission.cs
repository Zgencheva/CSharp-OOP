using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        private int deathAstronauts = 0;
        public int DeadAstronauts => this.deathAstronauts;
         
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> planetItems = planet.Items.ToList();
            foreach (IAstronaut astronaut in astronauts)
            {
                //if (astronaut.Oxygen <= 0)
                //{
                //    continue;
                //}
                for (int i = 0; i < planetItems.Count; i++)
                {
                    astronaut.Bag.AddItem(planetItems[i]);
                    astronaut.Breath();
                    planetItems.Remove(planetItems[i]);
                    i--;
                    if (astronaut.Oxygen == 0)
                    {
                        deathAstronauts++;
                        break;
                    }
                }
                
                
            }
        }

        public int TakeDeathAstronauts()
        {
            return this.DeadAstronauts;
        }
    }
}
