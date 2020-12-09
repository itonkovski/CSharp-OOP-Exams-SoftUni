
namespace SantaWorkshop.Models.Dwarfs
{
    using System;
    using System.Collections.Generic;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Utilities.Messages;

    public abstract class Dwarf : IDwarf
    {
        private const int WORK_ENERGY_DECR = 10;

        private string name;
        private int energy;

        private Dwarf()
        {
            this.Instruments = new List<IInstrument>();
        }

        protected Dwarf(string name, int energy)
            :this()
        {
            this.Name = name;
            this.Energy = energy;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                this.energy = value > 0 ? value : 0;
            }
        }

        public ICollection<IInstrument> Instruments { get; }
        
        public virtual void Work()
        {
            this.Energy -= WORK_ENERGY_DECR;
        }

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }

    }
}
