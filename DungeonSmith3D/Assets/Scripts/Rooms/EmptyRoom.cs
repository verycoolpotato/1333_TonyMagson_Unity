using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Rooms
{
    internal class EmptyRoom:Room
    {
        protected override string RoomDescription()
        {
            _revealed = true;
            return "A dimly lit, mostly empty room";

        }
        public override void OnRoomSearched(Player player = null)
        {
            if(_empty)
            {
                Console.WriteLine("The room is empty");
                return;
            }
            Item item = LootTables.GetRandomItem(LootTables.CommonDrop);
            if (item != null)
            {
                player!.PlayerInventory.PickupItem(item, true);
                Console.WriteLine("You manage to scrounge up a small reward");
            }
            else
            {
                Console.WriteLine("You searched but found nothing");
            }

                
            _empty = true;
            
        }

        

        public override string RoomIcon()
        {
            if (!_revealed)
                return "[?]".PadRight(3);
            return "[ ]".PadRight(3);
        }



    }
}
