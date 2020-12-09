namespace SantaWorkshop.Models.Instruments
{
    using SantaWorkshop.Models.Instruments.Contracts;

    public class Instrument : IInstrument
    {
        private const int USE_POWER_DECR = 10;

        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                this.power = value > 0 ? value : 0;
            }
        }

        public void Use()
        {
            this.Power -= USE_POWER_DECR;
            //TO DO: maybe power, check later
        }

        public bool IsBroken()
        {
            return this.Power == 0;
        }

    }
}
