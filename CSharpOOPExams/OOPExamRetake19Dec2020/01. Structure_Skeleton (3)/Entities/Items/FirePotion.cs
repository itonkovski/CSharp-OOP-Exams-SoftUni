using System;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int INITIAL_WEIGHT = 5;

        public FirePotion()
            : base(INITIAL_WEIGHT)
        {

        }

        public override void AffectCharacter(Character character)
        {
            
        }
    }
}
