using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public abstract class Weapon : IHasDamage
    {
        public string name;
        public int damage;

        public Entity holder;

        private const int MAX_DAMAGE = 10;
        private const int MIN_DAMAGE = 1;

        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
            holder = null;
        }

        public void SetHolder(Entity holder) => this.holder = holder;
        public void EmptyHolder() => holder = null;

        public void SetDamage(int damage) => this.damage = damage;
        public int GetDamage() => damage;
        public int GetMaxDamage() => MAX_DAMAGE;
        public int GetMinDamage() => MIN_DAMAGE;
    }
}
