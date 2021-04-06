using System;
namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int INITIAL_CAPACITY = 20;

        public Satchel(int capacity)
            : base(capacity)
        {
        }
    }
}
