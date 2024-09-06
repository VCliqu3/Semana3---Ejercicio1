using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public abstract class Weapon : ICanDealDamage
    {
        public string name;
        public int damage;

        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }
        public int GetDamage() => damage;


        public void DealDamage(IHasHealth iHasHealth)
        {
            iHasHealth.TakeDamage(damage);
        }
    }
}
