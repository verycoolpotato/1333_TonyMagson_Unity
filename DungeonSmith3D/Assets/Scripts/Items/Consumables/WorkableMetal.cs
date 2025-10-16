
using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Rooms;
using System.Linq;
using System;
using System.Collections.Generic;
namespace DiceGame.Scripts.Items.Consumables
{
    internal class WorkableMetal : Consumable
    {
        
        public WorkableMetal (RarityTiers rarity) : base(rarity, new Range(1,1)) 
        {
           
            Name = $"{rarity.ToString()} WorkableMetal"; 
        }
       
        private DieRoller _roller = new DieRoller();

       

        protected override void DescribeItem()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A piece of malleable metal, could be used at a forge to create new weapons");
            Console.ResetColor();
            Console.WriteLine();
            base.DescribeItem();
        }

        /// <summary>
        /// Forge menu
        /// </summary>
        internal override void Use()
        {
            if(Player.CurrentRoom is ForgeRoom)
            {
                Inventory inventory = GameManager.Instance!.GamePlayer.inventory;

                Console.WriteLine();
                Console.WriteLine($"Would you like to forge {Name} into a weapon?");
                Console.WriteLine("[1] Forge");
                Console.WriteLine("[2] Do Not");
                while (true)
                {
                    int inputConfirm = InputHelper.GetIntInput();
                    switch (inputConfirm)
                    {
                        case 1:
                            break;
                        case 2:
                            return;
                        default:
                            continue;

                    }
                    break;
                }
                foreach (Item item in inventory.GetInventory())
                {
                    if (item == null)
                        break; 

                   
                    if (item == inventory.GetInventory().Last())
                    {
                        Console.WriteLine("Not enough space to forge, get rid of something");
                        return;
                    }
                }
                Console.WriteLine("What kind of weapon will you forge?");
                Console.WriteLine("[1] One-Handed");
                Console.WriteLine("[2] Two-Handed");
                Console.WriteLine("[3] Heavy");
                while (true)
                {
                    
                    int inputType = InputHelper.GetIntInput();
                    Item forgedItem = null;
                    Console.WriteLine("Forging a weapon...");
                   
                    switch (inputType)
                    {

                        case 1:
                           
                            forgedItem = LootTables.GetRandomItem(LootTables.CommonForgeOneHanded);
                            Console.WriteLine($"Made the {forgedItem.Name}");
                            inventory.PickupItem(forgedItem,false);
                            break;
                        case 2:
                            
                            forgedItem = LootTables.GetRandomItem(LootTables.CommonForgeTwoHanded);
                            Console.WriteLine($"Made the {forgedItem.Name}");
                            inventory.PickupItem(forgedItem, false);
                            break;
                        case 3:
                            
                            forgedItem = LootTables.GetRandomItem(LootTables.CommonForgeHeavy);
                            Console.WriteLine($"Made the {forgedItem.Name}");
                            inventory.PickupItem(forgedItem, false);

                            break;

                        default:
                            continue;
                    }
                    RemoveItem();
                    return;
                }

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("This is useless without a forge");
            }
            
            
        }
    }
}
