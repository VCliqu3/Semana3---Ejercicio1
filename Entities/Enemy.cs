using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Enemy: Entity
    {
        public Item item;

        private const int ENEMY_MAX_HEALTH = 20;
        private const int ENEMY_MAX_STRENGTH = 5;
        private const int ENEMY_MAX_AGILITY = 5;
        private const int ENEMY_MAX_RESISTANCE = 5;

        public Enemy(int maxHealth, int strength, int resistance, int agility, Weapon weapon, Item item) : base(maxHealth, strength, resistance, agility, weapon)
        {
            this.item = item;
        }

        public override int GetMaxHealth() => ENEMY_MAX_HEALTH;
        public override int GetMaxStrength() => ENEMY_MAX_STRENGTH;
        public override int GetMaxAgility() => ENEMY_MAX_AGILITY;
        public override int GetMaxResistance() => ENEMY_MAX_RESISTANCE;
    }
}
