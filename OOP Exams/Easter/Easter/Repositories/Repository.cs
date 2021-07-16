using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories.Contracts
{
    public abstract class Repository<T> : IRepository<T>
    {
        private readonly ICollection<T> models;
        protected Repository()
        {
            this.models = new List<T>();
        }
        public IReadOnlyCollection<T> Models => this.models.ToArray();
        

        public void Add(T model)
        {
            models.Add(model);
        }

        public virtual T FindByName(string name)
        {
            return default;
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}
