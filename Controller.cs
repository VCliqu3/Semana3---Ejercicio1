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
        private List<Stage> stageList = new List<Stage>();

        private Stage currentStage;

        private bool gameEnded = false;

        public void Execute()
        {
            Console.WriteLine("Ahora te encuentras como Dungeon Master");

            CreateEnemiesLogic();
            CreateStagesLogic();
            CreatePlayerLogic();

            SeeStagesLogic();

            Console.WriteLine("\nAhora te encuentras como Jugador");

            GoToNextStage();

            while (!gameEnded)
            {
                PlayerTurnLogic();

                if (CheckStageCompleated(currentStage))
                {
                    if (CurrentStageIsLastStage())
                    {
                        Console.WriteLine("\nHas completado el juego!");
                        gameEnded = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nHas completado el Stage {currentStage.number}");
                        GoToNextStage();
                    }
                }
                else
                {
                    EnemyTurnLogic();

                    if (CheckPlayerDefeated())
                    {
                        Console.WriteLine("\nHas sido derrotado!");
                        gameEnded = true;
                    }
                }
            }
        }

        #region CreateEnemies
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
        #endregion

        #region SetStatPoints
        public void SetHealthPoints(IHasHealth iHasHealth) => iHasHealth.SetHealth(InsertStatPoints("Vida", iHasHealth.GetMaxHealth(),iHasHealth.GetMinHealth()));
        public void SetStrengthPoints(IHasStrength iHasStrength) => iHasStrength.SetStrength(InsertStatPoints("Fuerza", iHasStrength.GetMaxStrength(), iHasStrength.GetMinStrength()));
        public void SetAgilityPoints(IHasAgility iHasAgility) => iHasAgility.SetAgility(InsertStatPoints("Agilidad", iHasAgility.GetMaxAgility(),iHasAgility.GetMinAgility()));
        public void SetResistancePoints(IHasResistance iHasResistance) => iHasResistance.SetResistance(InsertStatPoints("Resistencia", iHasResistance.GetMaxResistance(), iHasResistance.GetMinResistance()));
        public void SetDamagePoints(IHasDamage iHasDamage) => iHasDamage.SetDamage(InsertStatPoints("Daño", iHasDamage.GetMaxDamage(), iHasDamage.GetMinDamage())); 
        public int InsertStatPoints(string statName, int maxStatPoints, int minStatPoints)
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
                    else if (desiredPoints < minStatPoints)
                    {
                        Console.WriteLine($"Ingresa como mínimo una cantidad de {minStatPoints}:");
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
        #endregion

        #region CreateWeapon
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

        #endregion

        #region CreateItem
        public void SetItem(Enemy enemy)
        {
            Console.WriteLine("\nSelecciona el item que portará");
            Console.WriteLine("1.- Explosivo");
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
                    item = CreateExplosive();
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

        public Explosive CreateExplosive()
        {
            Console.WriteLine("\nInserta el nombre del explosivo");
            string explosiveName = Console.ReadLine();

            Explosive explosive = new Explosive(explosiveName, 0);

            SetDamagePoints(explosive);

            return explosive;
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
        #endregion

        #region CreateStages
        public void CreateStagesLogic()
        {
            Console.WriteLine("\nCreación de stages:");

            bool creatingStages = true;
            int stageNumber = 1;
            while (creatingStages)
            {
                CreateSingleStageLogic(stageNumber);

                Console.WriteLine("\nDeseas crear otro stage?");
                bool answer = ChooseYNOption();

                if (!answer) creatingStages = false;
                else stageNumber++;
            }
        }

        public void CreateSingleStageLogic(int stageNumber)
        {
            Console.WriteLine($"\nStage {stageNumber}:");

            Stage stage = new Stage(stageNumber, new List<Enemy>());
            AddEnemiesToStage(stage);
            stageList.Add(stage);

        }

        public void AddEnemiesToStage(Stage stage)
        {
            bool addingEnemies = true;

            while (addingEnemies)
            {
                AddSingleEnemyToStage(stage);

                Console.WriteLine("\nDeseas agregar otro enemigo?");
                bool answer = ChooseYNOption();

                if (!answer) addingEnemies = false;
            }
        }

        public void AddSingleEnemyToStage(Stage stage)
        {
            Console.WriteLine($"\nSelecciona un enemigo a agregar al Stage {stage.number}:");

            int enemyNumber = 1;

            foreach (Enemy enemy in enemiesList)
            {
                Console.WriteLine($"{enemyNumber}.- {enemy.name}");
                enemyNumber++;
            }

            int enemyOption = ChooseNumberOption(enemiesList.Count);
            Enemy enemyToAdd = CloneEnemy(enemiesList[enemyOption - 1]);

            stage.enemies.Add(enemyToAdd);
        }
        public Enemy CloneEnemy(Enemy enemy)
        {
            return new Enemy(enemy.name, enemy.health, enemy.strength, enemy.agility, enemy.resistance, enemy.weapon, enemy.item);
        }
        #endregion

        #region SeeStages&Enemies
        public void SeeStagesLogic()
        {
            Console.WriteLine("\nSe tienen los siguientes stages:");

            int stageIndex = 0;

            foreach (Stage stage in stageList)
            {
                stageIndex++;
                Console.WriteLine($"\nStage {stageIndex}:");

                SeeEnemiesInStageLogic(stage);
            }
        }

        public void SeeEnemiesInStageLogic(Stage stage)
        {
            int enemyIndex = 0;

            foreach (Enemy enemy in stage.enemies)
            {
                enemyIndex++;
                Console.WriteLine($"{enemyIndex}.- {enemy.name}");
            }
        }
        #endregion

        #region CreatePlayer
        public void CreatePlayerLogic()
        {
            Console.WriteLine("\nCreación de jugador:");

            Console.WriteLine("\nInserta el nombre del jugador");
            string playerName = Console.ReadLine();

            Player newPlayer = new Player(playerName, 0, 0, 0, 0, null);

            SetHealthPoints(newPlayer);
            SetStrengthPoints(newPlayer);
            SetAgilityPoints(newPlayer);
            SetResistancePoints(newPlayer);
            SetWeapon(newPlayer);

            player = newPlayer;
        }
        #endregion

        public void PlayerTurnLogic()
        {
            Console.WriteLine("\nSelecciona la accion a realizar");
            Console.WriteLine("1.- Atacar");
            Console.WriteLine("2.- Usar un item");

            int actionOption = ChooseNumberOption(2);

            switch (actionOption)
            {
                case 1:
                default:
                    PlayerAttackLogic();
                    break;
                case 2:
                    PlayerUseItemLogic();
                    break;
            }
        }

        public void PlayerAttackLogic()
        {
            Console.WriteLine("\nSelecciona un enemigo a atacar");

            Enemy selectedEnemy = SelectEnemyFromCurrentStage();

            if (!selectedEnemy.IsAlive())
            {
                Console.WriteLine($"\nEl enemigo {selectedEnemy.name} ya está muerto, selecciona otro enemigo");
                PlayerAttackLogic();
            }
            else
            {
                int previousEnemyHealth = selectedEnemy.health;
                bool hasDealtDamage = player.DealDamage(selectedEnemy);

                if (!hasDealtDamage)
                {
                    Console.WriteLine($"\nEl enemigo {selectedEnemy.name} ha esquivado el ataque");
                    return;
                }

                int currentEnemyHealth = selectedEnemy.health;

                int damageDealt = previousEnemyHealth - currentEnemyHealth;

                if (damageDealt <= 0)
                {
                    Console.WriteLine($"\nEl enemigo {selectedEnemy.name} mitiga todo el daño del ataque mediante su resistencia");
                }

                Console.WriteLine($"\nEl enemigo {selectedEnemy.name} recibe {damageDealt} puntos de daño");
                if (!selectedEnemy.IsAlive()) Console.WriteLine($"El enemigo {selectedEnemy.name} ha muerto!");
                if (selectedEnemy.HasItem()) AddItemToPlayer(selectedEnemy.item);
            }
        }

        public void PlayerUseItemLogic()
        {
            if (!player.HasItems())
            {
                Console.WriteLine($"\nEl jugador no cuenta con items a usar");
                PlayerTurnLogic();
                return;
            }

            Console.WriteLine("\nSelecciona un item a usar:");

            int itemIndex = 0;

            foreach (Item item in player.items)
            {
                itemIndex++;
                Console.WriteLine($"{itemIndex}.- {item.name}");
            }

            int itemOption = ChooseNumberOption(player.items.Count);
            Item selectedItem = player.items[itemOption - 1];

            if(selectedItem is Explosive)
            {
                UseExplosive(selectedItem as Explosive);
            }
            if(selectedItem is Potion)
            {
                UsePotion(selectedItem as Potion);
            }
        }

        public void UseExplosive(Explosive explosive)
        {
            Console.WriteLine("\nSelecciona un enemigo a explotar");

            Enemy selectedEnemy = SelectEnemyFromCurrentStage();

            if (!selectedEnemy.IsAlive())
            {
                Console.WriteLine($"\nEl enemigo {selectedEnemy.name} ya está muerto, selecciona otro enemigo");
                UseExplosive(explosive);
            }
            else
            {
                int previousEnemyHealth = selectedEnemy.health;
                bool hasDealtDamage = explosive.DealDamage(selectedEnemy);

                if (!hasDealtDamage)
                {
                    Console.WriteLine($"\nEl enemigo {selectedEnemy.name} ha esquivado el explosivo");
                    return;
                }

                int currentEnemyHealth = selectedEnemy.health;

                int damageDealt = previousEnemyHealth - currentEnemyHealth;

                if (damageDealt <= 0)
                {
                    Console.WriteLine($"\nEl enemigo {selectedEnemy.name} mitiga todo el daño del explosivo mediante su resistencia");
                }
                else
                {
                    Console.WriteLine($"\nEl enemigo {selectedEnemy.name} recibe {damageDealt} puntos de daño");

                    if (!selectedEnemy.IsAlive())
                    {
                        Console.WriteLine($"El enemigo {selectedEnemy.name} ha muerto!");
                        if (selectedEnemy.HasItem()) AddItemToPlayer(selectedEnemy.item);
                    }
                }
                
                player.items.Remove(explosive);
            }
        }

        public void UsePotion(Potion potion)
        {
            if(potion is HealthPotion)
            {
                UseHealthPotion(potion as HealthPotion);
            }

            if (potion is StrengthPotion)
            {
                UseStrengthPotion(potion as StrengthPotion);
            }

            if (potion is AgilityPotion)
            {
                UseAgilityPotion(potion as AgilityPotion);
            }

            if (potion is ResistancePotion)
            {
                UseResistancePotion(potion as ResistancePotion);
            }
        }

        public void UseHealthPotion(HealthPotion healthPotion)
        {
            if(player.health == player.GetMaxHealth())
            {
                Console.WriteLine($"\nEl jugador ya tiene la vida maxima ({player.GetMaxHealth()}");
                return;
            }

            int previousHealth = player.health;
            healthPotion.ApplyPotion(player);
            int currentHealth = player.health;

            int healthAdded = currentHealth - previousHealth;

            Console.WriteLine($"\nLa pocion {healthPotion.name} restauró {healthAdded} puntos de vida");
            player.items.Remove(healthPotion);
        }

        public void UseStrengthPotion(StrengthPotion strengthPotion)
        {
            if (player.strength == player.GetMaxStrength())
            {
                Console.WriteLine($"\nEl jugador ya tiene la fuerza maxima ({player.GetMaxStrength()}");
                return;
            }

            int previousStrength = player.strength;
            strengthPotion.ApplyPotion(player);
            int currentStrength = player.strength;

            int strengthAdded = currentStrength - previousStrength;

            Console.WriteLine($"\nLa pocion {strengthPotion.name} aumentó {strengthAdded} puntos de fuerza");
            player.items.Remove(strengthPotion);
        }

        public void UseAgilityPotion(AgilityPotion agilityPotion)
        {
            if (player.agility == player.GetMaxAgility())
            {
                Console.WriteLine($"\nEl jugador ya tiene la agilidad maxima ({player.GetMaxAgility()}");
                return;
            }

            int previousAgility = player.agility;
            agilityPotion.ApplyPotion(player);
            int currentAgility = player.agility;

            int agilityAdded = currentAgility - previousAgility;

            Console.WriteLine($"\nLa pocion {agilityPotion.name} aumentó {agilityAdded} puntos de agilidad");
            player.items.Remove(agilityPotion);
        }

        public void UseResistancePotion(ResistancePotion resistancePotion)
        {
            if (player.resistance == player.GetMaxResistance())
            {
                Console.WriteLine($"\nEl jugador ya tiene la resistencia maxima ({player.GetMaxResistance()}");
                return;
            }

            int previousResistance = player.resistance;
            resistancePotion.ApplyPotion(player);
            int currentResistance = player.resistance;

            int agilityAdded = currentResistance - previousResistance;

            Console.WriteLine($"\nLa pocion {resistancePotion.name} aumentó {agilityAdded} puntos de resistencia");
            player.items.Remove(resistancePotion);
        }

        public void EnemyTurnLogic()
        {
            Enemy attackerEnemy = ChooseRandomAliveEnemyFromList(currentStage.enemies);

            if(attackerEnemy == null)
            {
                Console.WriteLine("Todos los enemigos del stage estan muertos!");
                return;
            }
            else
            {
                Console.WriteLine($"\nEl enemigo {attackerEnemy.name} ataca al jugador");

                int previousPlayerHealth = player.health;
                bool hasDealtDamage = attackerEnemy.DealDamage(player);

                if (!hasDealtDamage)
                {
                    Console.WriteLine($"\nEl jugador ha esquivado el ataque");
                    return;
                }

                int currentPlayerHealth = player.health;

                int damageDealt = previousPlayerHealth - currentPlayerHealth;

                if(damageDealt <= 0)
                {
                    Console.WriteLine($"\nEl jugador mitiga todo el daño del ataque mediante su resistencia");
                }

                Console.WriteLine($"\nEl jugador recibe {damageDealt} puntos de daño");
                Console.WriteLine($"El jugador ahora tiene {currentPlayerHealth} puntos de vida.");
            }
        }

        public Enemy SelectEnemyFromCurrentStage()
        {
            int enemyIndex = 0;

            foreach (Enemy enemy in currentStage.enemies)
            {
                enemyIndex++;
                if (enemy.IsAlive()) Console.WriteLine($"{enemyIndex}.- {enemy.name} - {enemy.health} puntos de vida");
                else Console.WriteLine($"{enemyIndex}.- {enemy.name} - Muerto");
            }

            int selectedEnemyIndex = ChooseNumberOption(enemyIndex);

            Enemy selectedEnemy = currentStage.enemies[selectedEnemyIndex - 1];

            return selectedEnemy;
        }

        public Enemy ChooseRandomAliveEnemyFromList(List<Enemy> enemies)
        {
            List<Enemy> aliveEnemies = new List<Enemy>();

            foreach(Enemy enemy in enemies)
            {
                if (enemy.IsAlive()) aliveEnemies.Add(enemy);
            }

            if (aliveEnemies.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(aliveEnemies.Count);

            return aliveEnemies[randomIndex];
        }

        public void GoToNextStage()
        {
            Stage nextStage;

            if (currentStage != null)
            {
                int nextStageIndex = GetCurrentStageIndexInList() + 1;
                nextStage = stageList[nextStageIndex];
            }
            else
            {
                nextStage = stageList[0];
            }

            Console.WriteLine($"\nComienza el Stage {nextStage.number}");
            currentStage = nextStage;

            Console.WriteLine($"\nLos enemigos son:");
            SeeEnemiesInStageLogic(currentStage);
        }
        public bool CurrentStageIsLastStage() => currentStage == stageList[^1];

        public bool CheckStageCompleated(Stage stage)
        {
            foreach(Enemy enemy in stage.enemies)
            {
                if (enemy.IsAlive()) return false;
            }

            return true;
        }

        public int GetCurrentStageIndexInList()
        {
            for (int i =0; i<stageList.Count; i++)
            {
                if (currentStage == stageList[i]) return i;
            }

            return 0;
        }
        public bool CheckPlayerDefeated() => !player.IsAlive();

        public void AddItemToPlayer(Item item)
        {
            Console.WriteLine($"\nHas adquirido {item.name}");
            player.items.Add(item);
        }

        #region OptionHandlers
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
        #endregion
    }
}

