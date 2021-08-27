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

        float CalculateDamage(Monster attacker, Monster defender)
        {
            return attacker.attack - defender.defense;
        }

        float Fight(ref Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker, defender);
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

        public void Run()
        {
            // Initializes stats of Monster 1.
            Monster monster1;
            monster1.name = "Wompus";
            monster1.health = 20f;
            monster1.attack = 10f;
            monster1.defense = 5f;

            // Initializes stats of Monster 2.
            Monster monster2;
            monster2.name = "Flompus";
            monster2.health = 15f;
            monster2.attack = 15f;
            monster2.defense = 10f;

            PrintMonsterStats(monster1);

            PrintMonsterStats(monster2);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("The monsters fight!");
            float damage = Fight(ref monster1, ref monster2);
            Console.WriteLine(monster2.name + " takes " + damage + " damage!");
            damage = Fight(ref monster2, ref monster1);
            Console.WriteLine(monster1.name + " takes " + damage + " damage!");

            Console.ReadKey();
            Console.Clear();

            PrintMonsterStats(monster1);

            PrintMonsterStats(monster2);
        }
    }
}
