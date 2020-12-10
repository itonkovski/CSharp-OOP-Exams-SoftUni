namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Repositories.Contracts;

    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;

        //Ctor for initializing collection
        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models =>
            (IReadOnlyCollection<IDwarf>)this.models;
        //might be this.Models, check later

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }

        public IDwarf FindByName(string name)
        {
            return this.models
                .FirstOrDefault(dw => dw.Name == name);
        }

    }
}
