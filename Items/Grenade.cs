using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Grenade: Item
    {
        public int damage;

        private const int MAX_DAMAGE = 20;

        public Grenade(string name, int damage) : base(name)
        {
            this.damage = damage;
        }

        public override int GetMaxStat() => MAX_DAMAGE;

        public void ExplodeOnEntity(Entity entity)
        {
            entity.TakeDamage(damage);
        }
    }
}
