namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int FRESH_WAT_AQ_CAPACITY = 50;

        public FreshwaterAquarium(string name)
            : base(name, FRESH_WAT_AQ_CAPACITY)
        {

        }
    }
}
