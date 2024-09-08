using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1.Items
{
    public class HealthPotion : Potion
    {
        public int health;

        private const int MAX_HEALTH = 2;

        public HealthPotion(string name, int health) : base(name)
        {
            this.health = health;
        }

        public override int GetMaxStat() => MAX_HEALTH;

        public override void ApplyPotion(Entity entity)
        {
            entity.IncreaseHealth(health);
        }
    }
}
