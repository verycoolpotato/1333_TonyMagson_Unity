using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Creatures
{
    internal class Enemy : Creature
    {
        public Enemy(int health, string name, Range Damage) : base(health,name) 
        {
            _baseDamage = Damage;
            _random = new Random();
        
        }
        private Random _random;
        private Range _baseDamage;
        internal Range ModifiedDamage;
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

            AttackWeight[] values = (AttackWeight[])Enum.GetValues(typeof(AttackWeight));
            AttackWeight weight = values[_random.Next(values.Length)];

            ModifiedDamage = new Range(_baseDamage.Start.Value + (int)weight, _baseDamage.End.Value + (int)weight);

            int damage = _random.Next(ModifiedDamage.Start.Value,ModifiedDamage.End.Value);

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Name} prepares a {weight} Attack ({ModifiedDamage.Start.Value}-{ModifiedDamage.End.Value})");
            Console.ResetColor();
            

            return damage;

        }

    }
}
