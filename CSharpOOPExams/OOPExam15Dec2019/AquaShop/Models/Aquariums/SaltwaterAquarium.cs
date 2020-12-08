namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int SALT_WATER_AQ_CAPACITY = 25;

        public SaltwaterAquarium(string name)
            : base(name, SALT_WATER_AQ_CAPACITY)
        {

        }
    }
}
