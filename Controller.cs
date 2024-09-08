using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana3___Ejercicio1
{
    public class Controller
    {

        private Player player;
        private List<Enemy> enemiesList = new List<Enemy>();


        public void Execute()
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                Console.WriteLine("Ahora te encuentras como Dungeon Master");

                CreateEnemiesLogic();
                gameEnded = true;
            }
        }
              
        public void CreateEnemiesLogic()
        {
            Console.WriteLine("\nCreación de enemigos:");

            bool creatingEnemies = true;

            while (creatingEnemies)
            {
                CreateSingleEnemyLogic();

                Console.WriteLine("\nDeseas crear otro enemigo?");
                bool answer = ChooseYNOption();

                if (!answer) creatingEnemies = false;

            }
        }

        public void CreateSingleEnemyLogic()
        {
            Console.WriteLine("\nInserta el nombre del nuevo enemigo");
            string enemyName = Console.ReadLine();

            Enemy enemy = new Enemy(enemyName,0, 0, 0, 0, null, null);

            SetHealthPoints(enemy);
            SetStrengthPoints(enemy);
            SetAgilityPoints(enemy);
            SetResistancePoints(enemy);
            SetWeapon(enemy);
            SetItem(enemy);

            enemiesList.Add(enemy);
        }

        public void SetHealthPoints(IHasHealth iHasHealth) => iHasHealth.SetHealth(InsertStatPoints("Vida", iHasHealth.GetMaxHealth()));
        public void SetStrengthPoints(IHasStrength iHasStrength) => iHasStrength.SetStrength(InsertStatPoints("Fuerza", iHasStrength.GetMaxStrength()));
        public void SetAgilityPoints(IHasAgility iHasAgility) => iHasAgility.SetAgility(InsertStatPoints("Agilidad", iHasAgility.GetMaxAgility()));
        public void SetResistancePoints(IHasResistance iHasResistance) => iHasResistance.SetResistance(InsertStatPoints("Resistencia", iHasResistance.GetMaxResistance()));
        public void SetDamagePoints(IHasDamage iHasDamage) => iHasDamage.SetDamage(InsertStatPoints("Daño", iHasDamage.GetMaxDamage())); 

        public int InsertStatPoints(string statName, int maxStatPoints)
        {
            bool validPoints = false;
            int insertedPoints = 0;

            Console.WriteLine($"\nSelecciona sus puntos de {statName} (Max. {maxStatPoints})");

            while (!validPoints)
            {
                try
                {
                    int desiredPoints = int.Parse(Console.ReadLine());

                    if (desiredPoints > maxStatPoints)
                    {
                        Console.WriteLine($"Sólo puedes ingresar un máximo de {maxStatPoints} puntos, ingresa una cantidad menor:");
                    }
                    else
                    {
                        insertedPoints = desiredPoints;
                        validPoints = true;
                    }
                }
                catch
                {
                    Console.WriteLine($"Debes insertar un número, ingresa uno:");
                }
            }

            return insertedPoints;
        }

        public void SetWeapon(Entity entity)
        {
            Console.WriteLine("\nSelecciona el tipo de arma que portará");
            Console.WriteLine("1.- Espada");
            Console.WriteLine("2.- Arco");

            int weaponOption = ChooseNumberOption(2);

            Weapon weapon;

            switch (weaponOption)
            {
                case 1:
                default:
                    weapon = CreateSword();
                    break;
                case 2:
                    weapon = CreateBow();
                    break;
            }

            entity.weapon = weapon;
            weapon.SetHolder(entity);
                    
        }

        public Sword CreateSword()
        {
            Console.WriteLine("\nInserta el nombre de la espada");
            string swordName = Console.ReadLine();

            Sword sword = new Sword(swordName, 0);

            SetDamagePoints(sword);

            return sword;
        }

        public Bow CreateBow()
        {
            Console.WriteLine("\nInserta el nombre del arco");
            string bowName = Console.ReadLine();

            Bow bow = new Bow(bowName, 0);

            SetDamagePoints(bow);

            return bow;
        }

        public void SetItem(Enemy enemy)
        {
            Console.WriteLine("\nSelecciona el item que portará");
            Console.WriteLine("1.- Granada");
            Console.WriteLine("2.- Pocion de Vida");
            Console.WriteLine("3.- Pocion de Fuerza");
            Console.WriteLine("4.- Pocion de Agilidad");
            Console.WriteLine("5.- Pocion de Resistencia");
            Console.WriteLine("6.- Ninguno");

            int itemOption = ChooseNumberOption(6);

            Item item;

            switch (itemOption)
            {
                case 1:
                    item = CreateGrenade();
                    break;
                case 2:
                    item = CreateHealthPotion();
                    break;
                case 3:
                    item = CreateStrengthPotion();
                    break;
                case 4:
                    item = CreateAgilityPotion();
                    break;
                case 5:
                    item = CreateResistancePotion();
                    break;
                case 6:
                default:
                    item = null;
                    break;
            }

            enemy.item = item;
        }

        public Grenade CreateGrenade()
        {
            Console.WriteLine("\nInserta el nombre de la granada");
            string grenadeName = Console.ReadLine();

            Grenade grenade = new Grenade(grenadeName, 0);

            SetDamagePoints(grenade);

            return grenade;
        }

        public HealthPotion CreateHealthPotion()
        {
            Console.WriteLine("\nInserta el nombre de la Poción de Vida");
            string potionName = Console.ReadLine();

            HealthPotion healthPotion = new HealthPotion(potionName, 0);

            SetHealthPoints(healthPotion);

            return healthPotion;
        }

        public StrengthPotion CreateStrengthPotion()
        {
            Console.WriteLine("\nInserta el nombre de la Poción de Fuerza");
            string potionName = Console.ReadLine();

            StrengthPotion strengthPotion = new StrengthPotion(potionName, 0);

            SetStrengthPoints(strengthPotion);

            return strengthPotion;
        }

        public AgilityPotion CreateAgilityPotion()
        {
            Console.WriteLine("\nInserta el nombre de la Poción de Agilidad");
            string potionName = Console.ReadLine();

            AgilityPotion agilityPotion = new AgilityPotion(potionName, 0);

            SetAgilityPoints(agilityPotion);

            return agilityPotion;
        }

        public ResistancePotion CreateResistancePotion()
        {
            Console.WriteLine("\nInserta el nombre de la Poción de Resistencia");
            string potionName = Console.ReadLine();

            ResistancePotion resistancePotion = new ResistancePotion(potionName, 0);

            SetResistancePoints(resistancePotion);

            return resistancePotion;
        }

        private int ChooseNumberOption(int maxOptionNumber)
        {
            bool validOption = false;
            int option = 0;

            while (!validOption)
            {
                try
                {
                    int desiredOption = int.Parse(Console.ReadLine());

                    if (desiredOption > 0 && desiredOption <= maxOptionNumber)
                    {
                        validOption = true;
                        option = desiredOption;
                    }
                    else
                    {
                        Console.WriteLine($"Selecciona una opcion válida:");
                    }
                }
                catch
                {
                    Console.WriteLine($"Selecciona una opcion válida:");
                }
            }

            return option;
        }

        private bool ChooseYNOption()
        {
            Console.WriteLine("(Y/N):");

            bool desiredOption = false;
            bool validYN = false;

            while (!validYN)
            {
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "Y":
                    case "y":
                        validYN = true;
                        desiredOption = true;
                        break;
                    case "N":
                    case "n":
                        validYN = true;
                        desiredOption = false;
                        break;
                    default:
                        Console.WriteLine("\nEscoge una opción válida:");
                        break;
                }
            }

            return desiredOption;
        }
    }
}

