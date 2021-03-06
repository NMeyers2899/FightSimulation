using System;
using System.Collections.Generic;
using System.Text;

namespace FightSimulation
{ 
    /// <summary>
    /// Makes a new type Monster to make it easier to construct monsters later on.
    /// </summary>
    struct Monster
    {
        public string name;
        public float health;
        public float attack;
        public float defense;
    }

    class Game
    {
        bool gameOver = false;
        Monster currentMonster1;
        Monster currentMonster2;

        int currentMonsterIndex = 0;
        int currentScene = 0;

        Monster Wompus;
        Monster Thwompus;
        Monster WompusWithAGun;
        Monster UnclePhil;
        Monster Warpus;
        Monster GigaWarpus;
        Monster DoctorPhil;
        Monster UltraPhil;
        Monster Wimpus;

        Monster[] monsterList;

        /// <summary>
        /// Calculates the damage between two monsters by subtracting one's attack from the other's defense.
        /// </summary>
        /// <param name="fighterAttack"> The one who is initiating the fight's attack. </param>
        /// <param name="defenderDefense"> The target of the attack's defense. </param>
        /// <returns> The damage that is dealt. </returns>
        float CalculateDamage(float fighterAttack, float defenderDefense)
        {
            // Checks if damage is less than or equal to zero, if it isn't it just sets the damage to zero.
            float damage = fighterAttack - defenderDefense;
            if(damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }

        /// <summary>
        /// Pits two monsters against each other and deals damage to the defender.
        /// </summary>
        /// <param name="attacker"> The aggressor who deals damage. </param>
        /// <param name="defender"> The target, who damage is dealt to. </param>
        /// <returns> Returns the damage taken by the defender. </returns>
        float Fight(ref Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker.attack, defender.defense);
            defender.health -= damageTaken;
            return damageTaken;
        }

        void ResetCurrentMonsters()
        {
            currentMonsterIndex = 0;
            // Sets starting fighters.
            currentMonster1 = monsterList[currentMonsterIndex];
            currentMonsterIndex++;
            currentMonster2 = monsterList[currentMonsterIndex];
        }

        /// <summary>
        /// Prints all the stats associated with the monster that is passed through the function.
        /// </summary>
        /// <param name="monster"> The monster whose stats will be displayed. </param>
        void PrintMonsterStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.name);
            Console.WriteLine("Health: " + monster.health);
            Console.WriteLine("Attack: " + monster.attack);
            Console.WriteLine("Defense: " + monster.defense);
        }

        /// <summary>
        /// Prints out the winner of the fight.
        /// </summary>
        /// <param name="winner"> What will be checked for the winner. </param>
        void DeclareWinner(string winner)
        {
            if (winner == "Draw")
            {
                Console.WriteLine("Draw");
            }
            else
            {
                Console.WriteLine("Winner is " + winner + "!");
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        /// <summary>
        /// Is called at the beginning of the game to initialize important stats.
        /// </summary>
        void Start()
        {
            // Initializes stats of Wompus.
            Wompus.name = "Wompus";
            Wompus.health = 23;
            Wompus.attack = 15;
            Wompus.defense = 5;

            // Initializes stats of Thwompus.
            Thwompus.name = "Thwompus";
            Thwompus.health = 16;
            Thwompus.attack = 15;
            Thwompus.defense = 10;

            // Initializes stats of Wompus With A Gun.
            WompusWithAGun.name = "Wompus With A Gun";
            WompusWithAGun.health = 23;
            WompusWithAGun.attack = 25;
            WompusWithAGun.defense = 5;

            // Initializes stats of Uncle Phil.
            UnclePhil.name = "Uncle Phil";
            UnclePhil.health = 12;
            UnclePhil.attack = 25;
            UnclePhil.defense = 10;

            monsterList = new Monster[] { Wompus, Thwompus, WompusWithAGun, UnclePhil };

            // Sets starting monsters.
            currentMonster1 = monsterList[currentMonsterIndex];
            currentMonsterIndex++;
            currentMonster2 = monsterList[currentMonsterIndex];
        }

        /// <summary>
        /// Updates the current game information.
        /// </summary>
        void Update()
        {
            UpdateCurrentScene();
            Console.Clear();
        }

        /// <summary>
        /// Gives a farewell message to the player.
        /// </summary>
        void End()
        {
            Console.WriteLine("Goodbye!");
        }

        /// <summary>
        /// Changes the scene between events.
        /// </summary>
        void UpdateCurrentScene()
        { 
            switch (currentScene)
            {
                case 0:
                    DisplayStartMenu();
                    break;

                case 1:
                    Battle();
                    UpdateCurrentMonsters();
                    Console.ReadKey(true);
                    Console.Clear();
                    break;

                case 2:
                    DisplayRestartMenu();
                    break;

                default:
                    Console.WriteLine("Invalid Scene Index");
                    break;
            }
        }

        /// <summary>
        /// Gets the user's input on a given topic, giving them two options to choose from.
        /// </summary>
        /// <param name="description"> The description of the choice. </param>
        /// <param name="option1"> The first option. </param>
        /// <param name="option2"> The second option. </param>
        /// <param name="pauseInvalid"> Pauses the game if the choice was invalid. </param>
        /// <returns> The number assigned to the made choice if it was valid. </returns>
        int GetInput(string description, string option1, string option2, bool pauseInvalid = false)
        {
            // The choice given to the user.
            Console.Write(description + "\n1. " + option1 + "\n2. " + option2 + "\n> ");

            // Gets player input.
            string input = Console.ReadLine().ToLower();
            int choice = 0;

            if(input == "1")
            {
                choice = 1;
            }
            else if(input == "2")
            {
                choice = 2;
            }
            else
            {
                Console.WriteLine("Invalid Input");

                if (pauseInvalid)
                {
                    Console.ReadKey(true);
                }
            }

            // Returns the player's choice.
            return choice;
        }

        /// <summary>
        /// Asks the user whether or not they wish to start the game or end the simulation. Giving them the
        /// choice to do either.
        /// </summary>
        void DisplayStartMenu()
        {
            // Gets the users input.
            int choice = GetInput(" Welcome to Monster Fight Simulator!", "Start Simulation", 
                "Quit Application");

            // Starts the battle scene.
            if (choice == 1)
            {
                currentScene = 1;
                Console.Clear();
            }
            // Quits the game.
            else if(choice == 2)
            {
                gameOver = true;
            }
        }

        /// <summary>
        /// Asks the user if they wish to restart the simulation.
        /// </summary>
        void DisplayRestartMenu()
        {
            // Gets the users input.
            int choice = GetInput("Would you like to restart the simulation?", "Restart", "Quit");

            // Resets to the start menu.
            if (choice == 1)
            {
                ResetCurrentMonsters();
                currentScene = 0;
                Console.Clear();
            }
            // Quits the game.
            else if (choice == 2)
            {
                gameOver = true;
            }
        }

        bool TryEndSimulation()
        {
            bool simulationOver = currentMonsterIndex >= monsterList.Length;

            if (simulationOver)
            {
                currentScene = 2;
            }

            return simulationOver;
        }

        /// <summary>
        /// Simulates one turn in the current monster fight.
        /// </summary>
        void Battle()
        {
            PrintMonsterStats(currentMonster1);

            PrintMonsterStats(currentMonster2);

            Console.WriteLine(currentMonster1.name + " and " + currentMonster2.name + " fight!");

            // Monster 1 attacks Monster 2.
            float damage = Fight(ref currentMonster1, ref currentMonster2);
            Console.WriteLine(currentMonster2.name + " takes " + damage + " damage!");

            // Monster 2 attacks Monster 1.
            damage = Fight(ref currentMonster2, ref currentMonster1);
            Console.WriteLine(currentMonster1.name + " takes " + damage + " damage!");
        }

        /// <summary>
        /// Updates the current monsters if one or more is dead, or sends the user to the reset menu if there
        /// are none left.
        /// </summary>
        void UpdateCurrentMonsters()
        {
            // Checks to see if there are any more fighters available. If not, it goes to the restart menu.
            if (currentMonsterIndex >= monsterList.Length)
            {
                currentScene = 2;
            }

            // Checks to see if monster 1 has died. If it has, it replaces monster 1.
            if (currentMonster1.health <= 0)
            {
                
                // Increments the current monster index.
                currentMonsterIndex++;

                if (TryEndSimulation())
                {
                    return;
                }

                currentMonster1 = monsterList[currentMonsterIndex];
            }

            // Checks to see if monster 1 has died. If it has, it replaces monster 1.
            if (currentMonster2.health <= 0)
            {
                // Increments the current monster index.
                currentMonsterIndex++;

                if (TryEndSimulation())
                {
                    return;
                }

                currentMonster2 = monsterList[currentMonsterIndex];
            }
        }

        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Update();
            }

            End();
        }
    }
}
