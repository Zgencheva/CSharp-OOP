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
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishes;
        private int comfort;

        protected Aquarium()
        {
           
            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }
        protected Aquarium(string name)
            :this()
        {
            this.Name = name;
            
        }
        protected Aquarium(string name, int capacity)
            :this(name)
        {
            
            this.Capacity = capacity;
            

        }

        public string Name
        {
            //TODO: names are unique
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //""Aquarium name cannot be null or empty."
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public virtual int Capacity { get; private set; }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fishes;

        public int Comfort
        {
            get
            {
                return this.comfort;
            }
            private set
            {
                if (decorations.Count == 0)
                {
                    this.comfort = 0;
                }
                else
                {
                    this.comfort = decorations.Sum(x => x.Comfort);
                }

            }
        }
        private int ComfortCalculation()
        {
            if (decorations.Count == 0)
            {
                return  0;
            }
            else
            {
                return decorations.Sum(x => x.Comfort);
            }
        }


        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
            
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= 0)
            {
                //"Not enough capacity.";
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }
        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }
        public string GetInfo()
        {
            //toChech if count ==0 returns NONE
            StringBuilder sb = new StringBuilder();
            //"{aquariumName} ({aquariumType}):
            //            Fish: { fishName1}, { fishName2}, { fishName3} (…) / none
            //            Decorations: { decorationsCount}
            //            Comfort: { aquariumComfort}
            //                "
            sb.AppendLine($"{this.Name} ({this.GetType().Name})");
            sb.Append("Fish: ");
            if (fishes.Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                sb.AppendLine(string.Join(", ", fishes));
            }
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {this.ComfortCalculation()}");
            return sb.ToString().TrimEnd();
        }
    }
}
