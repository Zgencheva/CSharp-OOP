using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> models;
        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }
        //public IReadOnlyCollection<IDriver> Models => this.models;

        public void Add(IDriver model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.models.ToList();
        }

        public IDriver GetByName(string name)
        {
            return models.Where(x => x.GetType().Name == name).FirstOrDefault();
        }

        public bool Remove(IDriver model)
        {
            return models.Remove(model);
        }
    }
}
