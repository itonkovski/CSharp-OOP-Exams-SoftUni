namespace AquaShop.Models.Fish
{
    using System;

    public class FreshwaterFish : Fish
    {
        private const int FRESH_WATER_FISH_SIZE = 3;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = FRESH_WATER_FISH_SIZE;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
