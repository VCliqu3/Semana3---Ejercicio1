using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Entity : IHasHealth
    {
        public int name;
        public int maxHealth;
        private int health;

        public int strength;
        public int resistance;
        public int agility;

        public Weapon weapon;

        private const int _50PERCENT_EVASION_AGILITY = 5;

        public Entity(int maxHealth, int strength, int resistance, int agility, Weapon weapon)
        {
            this.maxHealth = maxHealth;
            this.strength = strength;
            this.resistance = resistance;
            this.agility = agility;
            this.weapon = weapon;

            health = maxHealth;
        }

        public int GetStrength() => strength;
        public int GetAgility() => agility;

        public int GetHealth() => health;

        public void IncreaseHealth(int quantity)
        {
            health = health + quantity > maxHealth ? maxHealth : health + quantity;
        }
        public bool TakeDamage(int quantity) //True si recibe ataque, false si esquiva
        {
            if (CheckEvasion()) return false; 

            int damageToTake = quantity - resistance < 0 ? 0 : quantity - resistance;
            health = health - damageToTake < 0 ? 0 : health - damageToTake;
            return true;
        }

        public bool CheckEvasion()
        {
            float evasionFloat = 1 - 1 / 1 + ((float)agility / _50PERCENT_EVASION_AGILITY); //Mientras mas alta sea la agilidad, mas cercano a 1 cera evasionFloat

            Random random = new Random();
            int randomNumber = random.Next(0, 101);
            float threshold = (float)randomNumber / 100; //Valor entre 0 y 1;

            if (evasionFloat >= threshold) return true; //Si evasionFloat es mayor a threshold, la entidad esquiva
            return false;
        }
    }
}
