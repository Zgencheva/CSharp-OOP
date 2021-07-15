using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        //private IReadOnlyCollection<IRace> Models => this.models;

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.models.ToList();
        }

        public IRace GetByName(string name)
        {
            return models.Where(x => x.GetType().Name == name).FirstOrDefault();
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}
