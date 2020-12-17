using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> races;

        public DriverRepository()
        {
            this.races = new List<IDriver>();
        }

        public void Add(IDriver model)
            => this.races.Add(model);

        public IReadOnlyCollection<IDriver> GetAll()
            => this.races.ToArray();

        public IDriver GetByName(string name)
            => this.races.FirstOrDefault(x => x.Name == name);

        public bool Remove(IDriver model)
            => this.races.Remove(model);
    }
}
