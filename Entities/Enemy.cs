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

        private const int ENEMY_MIN_HEALTH = 1;
        private const int ENEMY_MIN_STRENGTH = 0;
        private const int ENEMY_MIN_AGILITY = 0;
        private const int ENEMY_MIN_RESISTANCE = 0;

        public Enemy(string name, int maxHealth, int strength, int agility, int resistance, Weapon weapon, Item item) : base(name, maxHealth, strength, agility, resistance, weapon)
        {
            this.item = item;
        }

        public override int GetMaxHealth() => ENEMY_MAX_HEALTH;
        public override int GetMinHealth() => ENEMY_MIN_HEALTH;

        public override int GetMaxStrength() => ENEMY_MAX_STRENGTH;
        public override int GetMinStrength() => ENEMY_MIN_STRENGTH;

        public override int GetMaxAgility() => ENEMY_MAX_AGILITY;
        public override int GetMinAgility() => ENEMY_MIN_AGILITY;

        public override int GetMaxResistance() => ENEMY_MAX_RESISTANCE;
        public override int GetMinResistance() => ENEMY_MIN_RESISTANCE;

        public bool HasItem() => item != null;
    }
}
