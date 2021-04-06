using System;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int INITIAL_WEIGHT = 5;

        public HealthPotion()
            : base(INITIAL_WEIGHT)
        {

        }

        public override void AffectCharacter(Character character)
        {
            
        }
    }
}
