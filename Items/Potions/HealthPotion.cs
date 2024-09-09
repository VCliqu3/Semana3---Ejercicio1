using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class HealthPotion : Potion, IHasHealth
    {
        public int health;

        private const int MAX_HEALTH = 2;
        private const int MIN_HEALTH = 1;

        public HealthPotion(string name, int health) : base(name)
        {
            this.health = health;
        }

        public override int GetMaxStat() => MAX_HEALTH;

        public override void ApplyPotion(Entity entity)
        {
            entity.IncreaseHealth(health);
        }

        public void SetHealth(int health) => this.health = health;
        public int GetHealth() => health;
        public int GetMaxHealth() => MAX_HEALTH;
        public int GetMinHealth() => MIN_HEALTH;

    }
}
