namespace AquaShop.Models.Fish
{
    using System;

    public class SaltwaterFish : Fish
    {
        private const int SALT_WATER_FISH_SIZE = 5;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = SALT_WATER_FISH_SIZE; 
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
