using System;

using UnityEngine;

namespace DiceGame.Scripts.Creatures
{
    internal class Enemy : Creature
    {
        public Enemy(int health, string name, Vector2Int Damage) : base(health,name) 
        {
            _baseDamage = Damage;
           
        
        }
        
        private Vector2Int _baseDamage;
        internal Vector2Int ModifiedDamage;
        private enum AttackWeight
        {
            Light =1,
            Medium = 3,
            Heavy = 5,
        }

        /// <summary>
        /// states the type of attack coming and returns the damage
        /// </summary>
        /// <returns></returns>
        internal int NextAttack()
        {
            // Pick a random attack weight
            AttackWeight[] values = (AttackWeight[])Enum.GetValues(typeof(AttackWeight));
            AttackWeight weight = values[UnityEngine.Random.Range(0, values.Length)];

            // Modify damage based on weight
            ModifiedDamage = new Vector2Int(
                _baseDamage.x + (int)weight,
                _baseDamage.y + (int)weight
            );

            // Roll for damage using Unity's Random.Range (inclusive-exclusive for ints)
            int damage = UnityEngine.Random.Range(ModifiedDamage.x, ModifiedDamage.y + 1);

            // Output to console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} prepares a {weight} Attack ({ModifiedDamage.x}-{ModifiedDamage.y})");
            Console.ResetColor();

            return damage;
        }


    }
}
