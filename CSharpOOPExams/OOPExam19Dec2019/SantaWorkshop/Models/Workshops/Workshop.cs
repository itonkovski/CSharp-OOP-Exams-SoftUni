namespace SantaWorkshop.Models.Workshops
{
    using System.Linq;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Models.Workshops.Contracts;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            // by this loop we iterate through instruments
            while (dwarf.Energy > 0 &&
                dwarf.Instruments.Any())
            {
                IInstrument currInstrument = dwarf
                    .Instruments.First();
                // by this loop we are crafting the present
                while (!present.IsDone()
                    && dwarf.Energy > 0
                    && !currInstrument.IsBroken())
                {
                    //decrease dwarf energy
                    dwarf.Work();
                    //decrease present's required energy
                    present.GetCrafted();
                    //decrease instrument´s health
                    currInstrument.Use();
                }

                //The instrument is broken and needs to be removed
                if (currInstrument.IsBroken())
                {
                    dwarf.Instruments.Remove(currInstrument);
                }

                //Present is crafted so we don´t need to craft anymore
                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
