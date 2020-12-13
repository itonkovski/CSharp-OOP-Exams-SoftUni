using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public IReadOnlyCollection<IPlayer> Models
            => players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
            => this.players.FirstOrDefault(x => x.Username == name);

        public bool Remove(IPlayer model)
            => players.Remove(model);
        
    }
}
