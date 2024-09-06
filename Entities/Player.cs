using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Player : Entity, IHasHealth
    {
        public List<Item> items;

        public Player(int maxHealth, int strength, int resistance, int agility, Weapon weapon, Item item) : base(maxHealth, strength, resistance, agility, weapon)
        {
            items = new List<Item>();
        }
    }
}
