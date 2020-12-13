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
                foreach (var terrorist in terrorists)
                {
                    if (!terrorist.IsAlive)
                    {
                        continue;
                    }
                    foreach (var ct in counterTerrorists)
                    {
                        if (!ct.IsAlive)
                        {
                            continue;
                        }
                        ct.TakeDamage(terrorist.Gun.Fire());
                    }
                }

                foreach (var counterTerro in counterTerrorists)
                {
                    if (!counterTerro.IsAlive)
                    {
                        continue;
                    }
                    
                    foreach (var terro in terrorists)
                    {
                        if (!terro.IsAlive)
                        {
                            continue;
                        }
                        terro.TakeDamage(counterTerro.Gun.Fire());
                    }
                }
            }
            string result = string.Empty;

            if (terrorists.Any(x => x.IsAlive))
            {
                result =  "Terrorist win!";
            }
            else
            {
                result =  "Counter Terrorist wins!";
            }

            return result;
        }
    }
}