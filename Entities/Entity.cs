using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public abstract class Entity : IHealthBeing, IStrengthBeing, IAgilityBeing, IResistanceBeing, IDamageDealer
    {
        public string name;
        public int health;

        public int strength;
        public int resistance;
        public int agility;

        public Weapon weapon;

        private const int _50PERCENT_EVASION_AGILITY = 5;

        public Entity(string name, int health, int strength, int agility, int resistance, Weapon weapon)
        {
            this.name = name;
            this.health = health;
            this.strength = strength;
            this.agility = agility;
            this.resistance = resistance;

            this.weapon = weapon;
        }

        public void SetHealth(int health) => this.health = health;
        public int GetHealth() => health;
        public abstract int GetMaxHealth();
        public void IncreaseHealth(int quantity)
        {
            health = health + quantity > GetMaxHealth() ? GetMaxHealth() : health + quantity;
        }
        public bool TakeDamage(int quantity) //True si recibe ataque, false si esquiva
        {
            if (CheckEvasion()) return false; 

            int damageToTake = quantity - resistance < 0 ? 0 : quantity - resistance;
            health = health - damageToTake < 0 ? 0 : health - damageToTake;
            return true;
        }

        public bool IsAlive() => health > 0;

        public void SetStrength(int strength) => this.strength = strength;
        public int GetStrength() => strength;
        public abstract int GetMaxStrength();

        public void IncreaseStrength(int quantity)
        {
            strength = strength + quantity > GetMaxStrength() ? GetMaxStrength() : strength + quantity;
        }

        public void SetAgility(int agility) => this.agility = agility;

        public int GetAgility() => agility;
        public abstract int GetMaxAgility();
        public void IncreaseAgility(int quantity)
        {
            agility = agility + quantity > GetMaxAgility() ? GetMaxAgility() : agility + quantity;
        }

        public void SetResistance(int resistance) => this.resistance = resistance;

        public int GetResistance() => resistance;
        public abstract int GetMaxResistance();
        public void IncreaseResistance(int quantity)
        {
            resistance = resistance + quantity > GetMaxResistance() ? GetMaxResistance() : resistance + quantity;
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

        public void SetDamage(int damage) => strength = damage;
        public int GetDamage() => strength;
        public int GetMaxDamage() => GetMaxStrength();
        public bool DealDamage(IHealthBeing iHasHealth)
        {
            int damageToDeal;

            if (HasWeapon()) damageToDeal = strength + weapon.damage; //Daño del arma influenciado por la fuerza de la entidad portadora
            else damageToDeal = strength;

            return iHasHealth.TakeDamage(damageToDeal);
        }

        public bool HasWeapon() => weapon != null;
    }
}
