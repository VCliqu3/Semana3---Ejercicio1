using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Player : Entity, IHasHealth
    {
        public List<Item> items;

        private const int PLAYER_MAX_HEALTH = 50;
        private const int PLAYER_MAX_STRENGTH = 10;
        private const int PLAYER_MAX_AGILITY = 10;
        private const int PLAYER_MAX_RESISTANCE = 10;

        public Player(int maxHealth, int strength, int resistance, int agility, Weapon weapon, Item item) : base(maxHealth, strength, resistance, agility, weapon)
        {
            items = new List<Item>();
        }

        public override int GetMaxHealth() => PLAYER_MAX_HEALTH;
        public override int GetMaxStrength() => PLAYER_MAX_STRENGTH;
        public override int GetMaxAgility() => PLAYER_MAX_AGILITY;
        public override int GetMaxResistance() => PLAYER_MAX_RESISTANCE;
    }
}
