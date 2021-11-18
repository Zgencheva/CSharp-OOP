using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decotarations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.decotarations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.Decorations.Sum(x=> x.Comfort); 
            

        public ICollection<IDecoration> Decorations => decotarations;

        public ICollection<IFish> Fish => fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decotarations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count < this.Capacity)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (IFish item in fish)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            string fishString = "";
            if (fish.Count == 0)
            {
                fishString = "none";
            }
            else
            {
                fishString = "";
                //List<IFish> fishToList = fish.ToList();
                for (int i = 0; i < fish.Count; i++)
                {
                    if (i == fish.Count - 1)
                    {
                        fishString += $"{fish[i].Name}";
                    }
                    else
                    {
                        fishString += $"{fish[i].Name}, ";
                    }
                }
            }

            return $"{this.Name} ({this.GetType().Name}):\r\n" +
                "Fish: " + fishString + "\r\n" +
                $"Decorations: {this.Decorations.Count}\r\n" +
         $"Comfort: {this.Comfort}".TrimEnd();
            

        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
