using DiceGame.Scripts.CoreSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DiceGame.Scripts.Items.Weapons
{
    internal class RedMetalSword : Weapon
    {
        public RedMetalSword(string WeaponName, Durability durability, Vector2Int DamageRange) : base(WeaponName,durability, DamageRange) 
        {
            ActionPointCost = 2;
            _style = WeaponStyles.TwoHanded;
            
        }
       
        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A long sword crafted from Red Metal. Heals its user when its durability decreases");
            Console.ResetColor();

            base.DescribeItem();
        }

        internal override void Use()
        {
            if (WeaponDurability != Durability.Unbreakable)
            {
                // chance to damage (0,1,2) -> 1 in 3 chance
                if (UnityEngine.Random.Range(0, 3) == 0)
                {
                    if (WeaponDurability < Durability.Shattered)
                    {
                        WeaponDurability = (Durability)((int)WeaponDurability + 1);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{Name?.ToUpper()} DAMAGED");
                        Console.WriteLine($"THE RED METAL HEALS ITS WIELDER");
                        GameManager.Instance!.GamePlayer.Health += 3;
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    else
                    {
                        Die = new Vector2Int(0, 2);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{Name?.ToUpper()} IS SHATTERED");
                        Console.ResetColor();
                    }
                }
            }

        }

    }
}
