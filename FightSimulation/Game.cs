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
        /// Pits the monsters against one another, whoever survives is deemed the winner.
        /// </summary>
        /// <param name="monster1"> The first monster. </param>
        /// <param name="monster2"> The second monster. </param>
        /// <returns> Returns which one is the winner, if neither survives it is a draw. </returns>
        string StartBattle(ref Monster monster1, ref Monster monster2)
        {
            string matchResult = "No Contest";
            while(monster1.health > 0 && monster2.health > 0)
            {
                PrintMonsterStats(monster1);

                PrintMonsterStats(monster2);

                Console.WriteLine("The monsters fight!");
                float damage = Fight(ref monster1, ref monster2);
                Console.WriteLine(monster2.name + " takes " + damage + " damage!");
                damage = Fight(ref monster2, ref monster1);
                Console.WriteLine(monster1.name + " takes " + damage + " damage!");

                Console.ReadKey(true);
                Console.Clear();
            }

            if(monster1.health <= 0 && monster2.health <= 0)
            {
                matchResult = "Draw";
            }
            else if(monster1.health <= 0)
            {
                matchResult = monster2.name;
            }
            else if(monster2.health <= 0)
            {
                matchResult = monster1.name;
            }

            return matchResult;
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

        void Update()
        {
            Battle();
        }

        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.health = 1;
            monster.defense = 1;
            monster.attack = 1;

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

        void Battle()
        {
            PrintMonsterStats(currentMonster1);

            PrintMonsterStats(currentMonster2);

            Console.WriteLine("The monsters fight!");
            float damage = Fight(ref currentMonster1, ref currentMonster2);
            Console.WriteLine(currentMonster2.name + " takes " + damage + " damage!");
            damage = Fight(ref currentMonster2, ref currentMonster1);
            Console.WriteLine(currentMonster1.name + " takes " + damage + " damage!");
        }

        void UpdateCurrentMonsters()
        {
           
        }

        public void Run()
        {
            string winner = "";

            // Initializes stats of Wompus.
            Wompus.name = "Wompus";
            Wompus.health = 20f;
            Wompus.attack = 15f;
            Wompus.defense = 5f;

            // Initializes stats of Thwompus.
            Thwompus.name = "Thwompus";
            Thwompus.health = 15f;
            Thwompus.attack = 15f;
            Thwompus.defense = 10f;

            // Initializes stats of Wompus With A Gun.
            WompusWithAGun.name = "Wompus With A Gun";
            WompusWithAGun.health = 20f;
            WompusWithAGun.attack = 25f;
            WompusWithAGun.defense = 5f;

            // Initializes stats of Uncle Phil.
            UnclePhil.name = "Uncle Phil";
            UnclePhil.health = 1f;
            UnclePhil.attack = 25f;
            UnclePhil.defense = 0f;

            while (!gameOver)
            {

            }
        }
    }
}
