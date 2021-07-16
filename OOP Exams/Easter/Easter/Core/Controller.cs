using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;
        private Workshop worshop;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.worshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny currentBunny = null;
            if (bunnyType == "HappyBunny")
            {
                currentBunny = new HappyBunny(bunnyName);
                bunnies.Add(currentBunny);
            }
            else if (bunnyType == "SleepyBunny")
            {
                currentBunny = new SleepyBunny(bunnyName);
                bunnies.Add(currentBunny);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            return $"{String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName)}";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny currentBunny = bunnies.FindByName(bunnyName);
            if (currentBunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }
            IDye currentDye = new Dye(power);
            currentBunny.AddDye(currentDye);
            return $"{String.Format(OutputMessages.DyeAdded, power, bunnyName)}";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg currentEgg = new Egg(eggName, energyRequired);
            eggs.Add(currentEgg);
            return $"{String.Format(OutputMessages.EggAdded, eggName)}";
        }

        public string ColorEgg(string eggName)
        {
            IEgg eggToColor = eggs.FindByName(eggName);
            List<IBunny> orderderBunnies = bunnies.Models.OrderByDescending(x=> x.Energy).Where(y=>y.Energy >=50).ToList();
            if (orderderBunnies.Count() == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            for (int i = 0; i < orderderBunnies.Count(); i++)
            {
                IBunny currentBunny = orderderBunnies[i];
                worshop.Color(eggToColor, currentBunny);
                if (eggToColor.IsDone())
                {
                    break;
                }
                if (currentBunny.Energy <=0)
                {
                    orderderBunnies.Remove(currentBunny);
                    bunnies.Remove(currentBunny);
                    i--;
                }
                
            }
            if (eggToColor.IsDone())
            {
                return String.Format(OutputMessages.EggIsDone, eggName);
            }
            else
            {
                    //return OutputMessages.EggIsNotDone
                return String.Format(OutputMessages.EggIsNotDone, eggName);

            }


        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int count = eggs.Models.Count(c=> c.IsDone());
            sb.AppendLine($"{count} eggs are done!");
            List<IBunny> allBunnies = bunnies.Models.ToList();
            foreach (var bun in allBunnies)
            {
                sb.AppendLine(bun.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
