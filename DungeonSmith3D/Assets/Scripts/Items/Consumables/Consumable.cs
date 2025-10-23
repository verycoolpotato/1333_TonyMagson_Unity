using System;
using System.Collections.Generic;
using UnityEngine;

namespace DiceGame.Scripts.Items.Consumables
{
    internal abstract class Consumable : Item
    {
        
        public Consumable(RarityTiers rarity, Vector2Int die) : base (die)
        {
          Rarity = rarity;
         

            CommandActions["Use"] = Use;

        }


        internal enum RarityTiers
        {
            Common = 0,
            Uncommon = 1,
            Rare = 2,
            Unique = 3
        }

        internal RarityTiers Rarity;

        protected override void DescribeItem()
        {
            Console.WriteLine($"Rarity: {Rarity}");
        }


    }
}
