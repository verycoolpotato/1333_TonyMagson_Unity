using System;

using UnityEngine;

namespace DiceGame.Scripts.Creatures
{
    public class Enemy : Creature
    {
      
        
        public WeaponStats EnemyWeapon;
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

            

            int calculateDamage = UnityEngine.Random.Range(EnemyWeapon.ItemRollRange.x, EnemyWeapon.ItemRollRange.y);

           int damage = calculateDamage + (int)weight;
           
         
            return damage;
        }


    }
}
