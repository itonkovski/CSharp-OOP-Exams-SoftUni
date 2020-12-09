namespace SantaWorkshop.Models.Presents
{
    using System;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Utilities.Messages;

    public class Present : IPresent
    {
        private const int CRAFT_ENERGY_DECR = 10;

        private string name;
        private int energyRequierd;

        public Present(string name, int energyRequierd)
        {
            this.Name = name;
            this.EnergyRequired = energyRequierd;
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
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this.energyRequierd;
            }
            private set
            {
                this.energyRequierd = value > 0 ? value : 0;
            }
        }

        public void GetCrafted()
        {
            this.energyRequierd -= CRAFT_ENERGY_DECR;
        }

        public bool IsDone()
        {
            return this.energyRequierd == 0;
        }
    }
}
