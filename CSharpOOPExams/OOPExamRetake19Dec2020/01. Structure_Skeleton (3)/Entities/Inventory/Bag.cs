using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DEFAULT_CAPACITY = 100;

        private int load;
        private List<Item> items;
        private int capacity;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;

            this.items = new List<Item>();
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = DEFAULT_CAPACITY;
            }
        }

        public int Load
        {
            get
            {
                return this.load;
            }
        }

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.load + item.Weight > Bag.DEFAULT_CAPACITY)
            {
                throw new InvalidOperationException($"Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = new HealthPotion();

            return item;
        }
    }
}
