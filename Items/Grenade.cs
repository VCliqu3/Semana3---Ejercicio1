using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1.Items
{
    public class Grenade: Item
    {
        public int damage;

        public Grenade(string name, int damage) : base(name)
        {
            this.damage = damage;
        }
    }
}
