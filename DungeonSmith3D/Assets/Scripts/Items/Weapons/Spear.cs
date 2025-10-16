using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Items.Weapons
{
    internal class Spear : Weapon
    {

        
        public Spear(string WeaponName, Durability durability, Range DamageRange) : base(WeaponName,durability, DamageRange) 
        {
            ActionPointCost = 2;
            _style = WeaponStyles.TwoHanded;
            
        }
       


        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Long and Sharp, great for keeping foes at bay");
            Console.ResetColor();

            base.DescribeItem();
        }



    }
}
