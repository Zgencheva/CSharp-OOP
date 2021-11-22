using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                IAquarium currentAq = new FreshwaterAquarium(aquariumName);
                aquariums.Add(currentAq);
                return $"Successfully added {aquariumType}.";
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                IAquarium currentAq = new SaltwaterAquarium(aquariumName);
                aquariums.Add(currentAq);
                return $"Successfully added {aquariumType}.";
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                IDecoration currentDecoration = new Ornament();
                decorations.Add(currentDecoration);
                return $"Successfully added {decorationType}.";
            }
            else if (decorationType == "Plant")
            {
                IDecoration currentDecoration = new Plant();
                decorations.Add(currentDecoration);
                return $"Successfully added {decorationType}.";
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
        }
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium currentAq = aquariums.FirstOrDefault(x=> x.Name == aquariumName);
            IDecoration currentDecoration = decorations.FindByType(decorationType);
            if (currentDecoration is null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
            //if (currentAq is null)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.aq);
            //}
            currentAq.AddDecoration(currentDecoration);
            decorations.Remove(currentDecoration);
            return $"Successfully added {decorationType} to {aquariumName}.";

        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish currentFish = default;
            IAquarium currentAquarium = aquariums.FirstOrDefault(x=> x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                currentFish = new FreshwaterFish(fishName, fishSpecies, price);
                if (currentAquarium.GetType().Name == "FreshwaterAquarium")
                {
                    currentAquarium.AddFish(currentFish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                else
                {
                    return "Water not suitable.";
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                currentFish = new SaltwaterFish(fishName, fishSpecies, price);
                if (currentAquarium.GetType().Name == "SaltwaterAquarium")
                {
                    currentAquarium.AddFish(currentFish);
                    return $"Successfully added {fishType} to {aquariumName}.";
                }
                else
                {
                    return "Water not suitable.";
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
        }
        public string FeedFish(string aquariumName)
        {
            IAquarium currentAq = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            int fishCount = currentAq.Fish.Count();
            if (fishCount != 0)
            {
                currentAq.Feed();
            }
            
            return $"Fish fed: {fishCount}";
        }
        public string CalculateValue(string aquariumName)
        {
            decimal value = 0;
            foreach (Aquarium aquarium in aquariums)
            {

                value += aquarium.Fish.Sum(x => x.Price);
              
            }
            foreach (IDecoration decoration in decorations.Models)
            {
                value += decoration.Price;
            }
            return $"The value of Aquarium {aquariumName} is {value}.";
        }

        

       

        public string Report()
        {
            string result = "";
            if (aquariums.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < aquariums.Count; i++)
            {
                if (i == aquariums.Count -1)
                {
                    result += aquariums[i].GetInfo();
                }
                else
                {
                    result += aquariums[i].GetInfo() + "\r\n";
                }
            }
            return result.TrimEnd() ;
        }
    }
}
