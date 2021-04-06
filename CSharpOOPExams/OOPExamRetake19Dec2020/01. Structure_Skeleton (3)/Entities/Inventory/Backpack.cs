using System;
namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int INITIAL_CAPACITY = 100;

        public Backpack(int capacity)
            : base(INITIAL_CAPACITY)
        {
        }
    }
}
