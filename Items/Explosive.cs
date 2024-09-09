using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Explosive: Item, IDamageDealer
    {
        public int damage;

        private const int MAX_DAMAGE = 20;
        private const int MIN_DAMAGE = 1;

        public Explosive(string name, int damage) : base(name)
        {
            this.damage = damage;
        }

        public override int GetMaxStat() => MAX_DAMAGE;

        public void SetDamage(int damage) => this.damage = damage;
        public int GetDamage() => damage;
        public int GetMaxDamage() => MAX_DAMAGE;
        public int GetMinDamage() => MIN_DAMAGE;


        public bool DealDamage(IHealthBeing iHasHealth)
        {
            return iHasHealth.TakeDamage(damage); //Daño de granada NO influenciada por la fuerza de la entidad portadora
        }
    }
}
