using System;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Warrior : IAttacker
    {
        public Warrior(string name)
        {

        }

        public void Attack(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
