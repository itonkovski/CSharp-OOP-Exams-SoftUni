using System;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Priest : IHealer
    {
        public Priest(string name)
        {

        }

        public void Heal(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
