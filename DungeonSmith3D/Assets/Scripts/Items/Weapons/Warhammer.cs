using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DiceGame.Scripts.Items.Weapons
{
    internal class Warhammer : Weapon
    {
        public Warhammer(string WeaponName, Durability durability, Vector2Int DamageRange) : base(WeaponName,durability, DamageRange) 
        {
            ActionPointCost = 3;
            _style = WeaponStyles.Heavy;
            
        }
       
        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A hulking hammer, ideal for caving skulls");
            Console.ResetColor();

            base.DescribeItem();
        }



    }
}
