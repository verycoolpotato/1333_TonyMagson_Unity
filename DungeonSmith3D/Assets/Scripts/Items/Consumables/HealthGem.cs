using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Items.Consumables
{
    internal class HealthGem : Consumable
    {
        
        public HealthGem (RarityTiers rarity, Range healing) : base(rarity, healing) 
        {
            _heal = healing;
            Name = $"{rarity.ToString()} Health Gem";
            ActionPointCost = 1;
        }
       
        private DieRoller _roller = new DieRoller();

        private Range _heal;

        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A gemstone with healing properties");
            Console.ResetColor();
            Console.WriteLine($"{_heal.Start.Value}-{_heal.End.Value} Healing");
            Console.WriteLine();
            base.DescribeItem();
        }

        internal override void Use()
        {
            Console.WriteLine();
            Console.WriteLine("You crush the health gem, your wounds begin to heal");
            GameManager.Instance!.GamePlayer.Health += _roller.Roll(Die.Start.Value,Die.End.Value);
            RemoveItem();
        }
    }
}
