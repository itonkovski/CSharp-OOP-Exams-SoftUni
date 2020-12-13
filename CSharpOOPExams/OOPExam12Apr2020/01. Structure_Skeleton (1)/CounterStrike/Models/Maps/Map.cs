using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(t => t.GetType() == typeof(Terrorist)).ToList();
            
            var counterTerrorists = players.Where(ct => ct.GetType() == typeof(CounterTerrorist)).ToList();

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terrorists.Where(t => t.IsAlive))
                {
                    foreach (var ct in counterTerrorists.Where(x => x.IsAlive))
                    {
                        ct.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counterTerro in counterTerrorists.Where(ct => ct.IsAlive))
                {
                    
                    foreach (var terro in terrorists.Where(x => x.IsAlive))
                    {
                        terro.TakeDamage(counterTerro.Gun.Fire());
                    }
                }
            }
            string result = string.Empty;

            if (terrorists.Any(x => x.IsAlive))
            {
                return "Terrorist win!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }
    }
}