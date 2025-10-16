using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Items.Weapons
{
    internal class Shortsword : Weapon
    {

        
        public Shortsword(string WeaponName, Durability durability, Range DamageRange) : base(WeaponName,durability, DamageRange) 
        {
            ActionPointCost = 1;
            _style = WeaponStyles.OneHanded;
        }
       


        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A common weapon, forged by any blacksmith. Despite its simplicity, it demands respect");
            Console.ResetColor();

            base.DescribeItem();
        }



    }
}
