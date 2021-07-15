using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;
        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        //public IReadOnlyCollection<ICar> Models => this.models;

        public void Add(ICar model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.models.ToList();
        }

        public ICar GetByName(string name)
        {
            return models.Where(x => x.GetType().Name == name).FirstOrDefault();
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }
    }
}
