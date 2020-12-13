using System;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private IGun gun;
        private int armor;
        private int health;
        private string username;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.username = value;
            }
        }
        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }
        public int Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }
        public bool IsAlive
            => this.Health > 0;

        public IGun Gun
        {
            get
            {
                return this.gun;
            }
            private set
            {
                if (value  == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }

        public void TakeDamage(int points)
        {
            this.Armor -= points;

            if (this.Armor > 0)
            {
                this.Armor -= points;

                if (this.Armor < 0)
                {
                    this.Health -= this.Armor * -1;
                    this.Armor = 0;
                }
            }
            else
            {
                this.Health -= points;
            }
        }
    }
}
