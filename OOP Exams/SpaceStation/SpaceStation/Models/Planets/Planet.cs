using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private ICollection<string> items;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }
        public ICollection<string> Items => this.items;

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
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public void AddItems(params string[] items)
        {
            this.items = items;
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }

        //public List<string> TakeItemsInList()
        //{
        //    return this.Items.ToList();
        //}
    }
}
