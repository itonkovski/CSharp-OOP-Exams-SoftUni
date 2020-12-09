
namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories.Contracts;

    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models =>
            (IReadOnlyCollection<IPresent>)this.Models;

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public bool Remove(IPresent model)
        {
            return this.models.Remove(model);
        }

        public IPresent FindByName(string name)
        {
            return this.models
                .FirstOrDefault(p => p.Name == name);     
        }

    }
}
