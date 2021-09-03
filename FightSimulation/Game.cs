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
        int currentMonsterIndex = 1;

        Monster Wompus;
        Monster Thwompus;
        Monster WompusWithAGun;
        Monster UnclePhil;

        /// <summary>
        /// Calculates the damage between two monsters by subtracting one's attack from the other's defense.
        /// </summary>
        /// <param name="fighterAttack"> The one who is initiating the fight's attack. </param>
        /// <param name="defenderDefense"> The target of the attack's defense. </param>
        /// <returns></returns>
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

        float Fight(ref Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker.attack, defender.defense);
            defender.health -= damageTaken;
            return damageTaken;
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
            Wompus.health = 20;
            Wompus.attack = 15;
            Wompus.defense = 5;

            // Initializes stats of Thwompus.
            Thwompus.name = "Thwompus";
            Thwompus.health = 15;
            Thwompus.attack = 15;
            Thwompus.defense = 10;

            // Initializes stats of Wompus With A Gun.
            WompusWithAGun.name = "Wompus With A Gun";
            WompusWithAGun.health = 20;
            WompusWithAGun.attack = 30;
            WompusWithAGun.defense = 5;

            // Initializes stats of Uncle Phil.
            UnclePhil.name = "Uncle Phil";
            UnclePhil.health = 1;
            UnclePhil.attack = 25;
            UnclePhil.defense = 0;

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
            Battle();
            UpdateCurrentMonsters();
            Console.ReadKey(true);
            Console.Clear();
        }

        /// <summary>
        /// Sets up the next monster for a fight.
        /// </summary>
        /// <param name="monsterIndex"> The identifier for the monster. </param>
        /// <returns></returns>
        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.health = 1;
            monster.defense = 0;
            monster.attack = 0;

            if (monsterIndex == 1)
            {
                monster = UnclePhil;
            }
            else if (monsterIndex == 2)
            {
                monster = WompusWithAGun;
            }
            else if (monsterIndex == 3)
            {
                monster = Wompus;
            }
            else if (monsterIndex == 4)
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
        /// Updates the current monsters if one or more is dead, or ends the game if there are none left.
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

            // Checks to see if there are any more fighters available. If not, it ends the game.
            if (currentMonster2.name == "None" || currentMonster1.name == "None" && currentMonsterIndex >= 4)
            {
                Console.WriteLine("Simulation Over");
                gameOver = true;
            }
        }

        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Update();
            }
        }
    }
}
