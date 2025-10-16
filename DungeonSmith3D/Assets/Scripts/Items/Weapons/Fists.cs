using DiceGame.Scripts.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceGame.Scripts.Items.Weapons.Weapon;

namespace DiceGame.Scripts.Items.Weapons
{
    internal class Fists : Weapon
    {

       
        public Fists() : base("Guard",0, new Range(1, 4)) 
        {
            ActionPointCost = 1;
            CommandActions.Clear();
            _style = WeaponStyles.Fists;
        }

        protected override void DefaultCommands()
        {
            //Override all commands
        }


        internal override int Attack(DieRoller roller)
        {

            int blockAmount = roller.Roll(Die.Start.Value,Die.End.Value);

            Console.WriteLine($"You brace for impact, rolled a {blockAmount}");
            Console.WriteLine();
            return blockAmount;
        }

        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deal minimal damage while maintaining a defensive stance, reduces damage taken when used");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine($"Damage: {Die.Start.Value}-{Die.End.Value}");
           
            Console.WriteLine();
        }



    }
}
