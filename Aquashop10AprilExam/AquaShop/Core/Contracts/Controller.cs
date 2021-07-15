using System;
using AquaShop.Repositories.Contracts;
using AquaShop.Repositories;
using System.Collections.Generic;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using System.Linq;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums;
        private DecorationRepository decorations;
        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            //TODO: all names should be unique
            IAquarium currentAquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                currentAquarium = new FreshwaterAquarium(aquariumName);
                
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                currentAquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(currentAquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration currentDecoration = null;
            if (decorationType == "Plant")
            {
                currentDecoration = new Plant();
            }
            else if (decorationType == "Ornament")
            {
                currentDecoration = new Ornament();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            decorations.Add(currentDecoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration currentDecoration = decorations.FindByType(decorationType);
            if (currentDecoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            else
            {
                //TODO: What if there is no such Aquarium name
                IAquarium currentAquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
                currentAquarium.AddDecoration(currentDecoration);
                decorations.Remove(currentDecoration);
                return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
                //if (aquariums.Any(x=> x.Name == aquariumName))
                //{
                    
                //}
                //else
                //{
                //    return null;
                //}
                

            }
        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish currentFish = null;
            if (fishType == "FreshwaterFish")
            {
                IAquarium currentAquarium = aquariums.Where(x=> x.Name == aquariumName).FirstOrDefault();
                currentFish = new FreshwaterFish(fishName, fishSpecies, price);
                if (currentAquarium.GetType().Name != "FreshwaterAquarium")
                {
                    return "Water not suitable.";
                }
                else
                {
                    currentAquarium.AddFish(currentFish);
                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                IAquarium currentAquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
                currentFish = new SaltwaterFish(fishName, fishSpecies, price);
                if (currentAquarium.GetType().Name != "SaltwaterAquarium")
                {
                    return "Water not suitable.";
                }
                else
                {
                    currentAquarium.AddFish(currentFish);
                    return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium currentAquarium = aquariums.Where(x=> x.Name == aquariumName).FirstOrDefault();
            currentAquarium.Feed();
            return string.Format(OutputMessages.FishFed, currentAquarium.Fish.Count());
        }
        public string CalculateValue(string aquariumName)
        {
            IAquarium currentAquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            decimal value = currentAquarium.Fish.Sum(x => x.Price) + currentAquarium.Decorations.Sum(y=>y.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aq in aquariums)
            {
                sb.AppendLine(aq.GetInfo().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
