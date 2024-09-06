using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Player : IHasHealth
    {
        public int maxHealth;
        public int health;

        public int strength;
        public int agility;
        public int intelligence;

        public List<Item> items;
        public List<Weapon> weapons;

        public Player(int maxHealth, int strength, int agility, int intelligence)
        {
            this.maxHealth = maxHealth;
            this.strength = strength;
            this.agility = agility;
            this.intelligence = intelligence;

            health = maxHealth;
            items = new List<Item>();
            weapons = new List<Weapon>();
        }

        public int GetHealth() => health;


        public void IncreaseHealth(int quantity)
        {
            health = health + quantity > maxHealth ? maxHealth : health + quantity;
        }

        public void TakeDamage(int quantity)
        {
            health = health - quantity < 0 ? 0 : health - quantity;
        }
    }
}
