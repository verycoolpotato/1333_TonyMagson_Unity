using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using System;
using UnityEngine;


namespace DiceGame.Scripts.Items.Consumables
{
    internal class HealthGem : Consumable
    {
        
       
       
        private DieRoller _roller = new DieRoller();

       

      

        internal override void Use()
        {
            Console.WriteLine();
            Console.WriteLine("You crush the health gem, your wounds begin to heal");
            GameManager.Instance!.GamePlayer.Health += _roller.Roll(Die.x,Die.y);
            RemoveItem();
        }
    }
}
