using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1.Items
{
    public class Potion : Item
    {
        public int strength;
        public int agility;
        public int intelligence;

        public Potion(string name, int strength, int agility, int intelligence) : base(name)
        {
            this.strength = strength;
            this.agility = agility;
            this.intelligence = intelligence;
        }
    }
}
