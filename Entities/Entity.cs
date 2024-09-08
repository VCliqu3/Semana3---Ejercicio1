using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public abstract class Entity : IHasHealth
    {
        public int name;
        private int health;

        public int strength;
        public int resistance;
        public int agility;

        public Weapon weapon;

        private const int _50PERCENT_EVASION_AGILITY = 5;

        public Entity(int health, int strength, int agility, int resistance, Weapon weapon)
        {
            this.health = health;
            this.strength = strength;
            this.agility = agility;
            this.resistance = resistance;

            this.weapon = weapon;
        }

        public bool IsAlive() => health > 0;

        public abstract int GetMaxHealth();
        public abstract int GetMaxStrength();
        public abstract int GetMaxAgility();
        public abstract int GetMaxResistance();

        public int GetHealth() => health;
        public int GetStrength() => strength;
        public int GetAgility() => agility;
        public int GetResistance() => resistance;

        public void IncreaseHealth(int quantity)
        {
            health = health + quantity > GetMaxHealth() ? GetMaxHealth() : health + quantity;
        }

        public void IncreaseStrength(int quantity)
        {
            strength = strength + quantity > GetMaxStrength() ? GetMaxStrength() : strength + quantity;
        }

        public void IncreaseAgility(int quantity)
        {
            agility = agility + quantity > GetMaxAgility() ? GetMaxAgility() : agility + quantity;
        }
        public void IncreaseResistance(int quantity)
        {
            resistance = resistance + quantity > GetMaxResistance() ? GetMaxResistance() : resistance + quantity;
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
