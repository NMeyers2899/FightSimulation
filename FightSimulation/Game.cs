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
            currentMonster1 = GetMonster(currentMonsterIndex);
            currentMonsterIndex++;
            currentMonster2 = GetMonster(currentMonsterIndex);
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
            Wompus.health = 23.5f;
            Wompus.attack = 15;
            Wompus.defense = 5;

            // Initializes stats of Thwompus.
            Thwompus.name = "Thwompus";
            Thwompus.health = 16;
            Thwompus.attack = 15.7f;
            Thwompus.defense = 10.3f;

            // Initializes stats of Wompus With A Gun.
            WompusWithAGun.name = "Wompus With A Gun";
            WompusWithAGun.health = 23.5f;
            WompusWithAGun.attack = 25;
            WompusWithAGun.defense = 5;

            // Initializes stats of Uncle Phil.
            UnclePhil.name = "Uncle Phil";
            UnclePhil.health = 12.3f;
            UnclePhil.attack = 25.4f;
            UnclePhil.defense = 10;

            // Sets starting monsters.
            currentMonster1 = GetMonster(currentMonsterIndex);
            currentMonsterIndex++;
            currentMonster2 = GetMonster(currentMonsterIndex);
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

        /// <summary>
        /// Sets up the next monster for a fight.
        /// </summary>
        /// <param name="monsterIndex"> The identifier for the monster. </param>
        /// <returns> Returns the monster that will be a new fighter. </returns>
        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.health = 1;
            monster.defense = 0;
            monster.attack = 0;

            if (monsterIndex == 0)
            {
                monster = UnclePhil;
            }
            else if (monsterIndex == 1)
            {
                monster = WompusWithAGun;
            }
            else if (monsterIndex == 2)
            {
                monster = Wompus;
            }
            else if (monsterIndex == 3)
            {
                monster = Thwompus;
            }

            return monster;
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
            // Checks to see if monster 1 has died. If it has, it replaces monster 1.
           if(currentMonster1.health <= 0)
            {
                // Increments the current monster index.
                currentMonsterIndex++;
                currentMonster1 = GetMonster(currentMonsterIndex);
            }

            // Checks to see if monster 2 has died. If it has, it replaces monster 2.
            if (currentMonster2.health <= 0)
            {
                // Increments the current monster index.
                currentMonsterIndex++;
                currentMonster2 = GetMonster(currentMonsterIndex);
            }

            // Checks to see if there are any more fighters available. If not, it goes to the restart menu.
            if (currentMonster2.name == "None" || currentMonster1.name == "None" && currentMonsterIndex >= 3)
            {
                currentScene = 2;
            }
        }

        void PrintList()
        {
            int[] array = new int[5];
            int num = 0;
            bool validInputRecieved = false;
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter five numbers. No decimals.");
                while (!validInputRecieved)
                {
                    string choice = Console.ReadLine();
                    if (int.TryParse(choice, out num))
                    {
                        int.TryParse(choice, out num);
                        validInputRecieved = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                array[i] = num;
                validInputRecieved = false;
            }

            int largest = array[1];
            int smallest = array[1];

            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] < smallest)
                {
                    smallest = array[i];
                }
                else if(array[i] > largest)
                {
                    largest = array[i];
                }

            }

            Console.WriteLine("The largest number was " + largest + ". \nAnd the smallest number was " 
                + smallest);
        }

        public void Run()
        {
            PrintList();

            //Start();

            //while (!gameOver)
            //{
              //  Update();
            //}

            //End();
        }
    }
}
