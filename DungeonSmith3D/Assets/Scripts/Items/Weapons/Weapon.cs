using DiceGame.Scripts.HelperClasses;
using System;

using UnityEngine;

namespace DiceGame.Scripts.Items.Weapons
{
    internal abstract class Weapon : Item
    {
        internal enum Durability
        {
            Unbreakable = 0,
            Sturdy = 1,
            Weathered = 2,
            Fragile = 3,
            Shattered = 4,
            
        }
        protected enum WeaponStyles 
        {
            Fists = 0,
            OneHanded = 1,
            TwoHanded = 2,
            Heavy = 3
        
        }

        /// <summary>
        /// Describe weapon specific attributes
        /// </summary>
        protected override void DescribeItem()
        {
            Console.WriteLine();
            Console.WriteLine($"Weapon - {_style}");
            Console.WriteLine($"Damage: {Die.x}-{Die.y}");
            Console.WriteLine($"Durability: {WeaponDurability}");
            Console.WriteLine();
        }

        protected WeaponStyles _style;
        private Vector2Int _defaultDamage;
        internal Durability WeaponDurability;
        
        internal Weapon(string WeaponName, Durability durability, Vector2Int die) : base(die)
        {
            CommandActions["Rename"] = Rename;
            _defaultDamage = Die;
            Name = WeaponName;
            WeaponDurability = durability;
           
           
        }

        /// <summary>
        /// Attack function, must return a single damage number in the end
        /// </summary>
        /// <param name="roller"></param>
        /// <returns></returns>
        internal virtual int Attack(DieRoller roller)
        {
          int roll = roller.Roll(Die.x,Die.y);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} rolls {roll}");
            Console.ResetColor();
            Use();
            return roll;
        }
        /// <summary>
        /// allow weapon renaming
        /// </summary>
        protected virtual void Rename()
        {
            Console.WriteLine($"Enter a new name for your {Name}:");
            Name = InputHelper.GetStringInput();
        }

        /// <summary>
        /// called after being swung, lowers durability
        /// </summary>
        internal override void Use()
        {


            if (WeaponDurability != Durability.Unbreakable)
            {
                // chance to damage (0 or 1)
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    if (WeaponDurability < Durability.Shattered)
                    {
                        WeaponDurability = (Durability)((int)WeaponDurability + 1);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{Name?.ToUpper()} DAMAGED");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{Name?.ToUpper()} IS SHATTERED");
                        Console.ResetColor();
                        Die = new Vector2Int(2, 4);
                    }
                }
            }

        }

        internal void Repair()
        {
            Die = _defaultDamage;
            Console.WriteLine("Repaired");
            WeaponDurability = Durability.Sturdy;
        }

    }
}
