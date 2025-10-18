using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Rooms.TreasureRooms
{
    internal class TreasureRoom : Room
    {
        
        protected override string RoomDescription()
        {
            return "A dusty old room filled with junk, a small glimmer escapes from beneath one of the piles";
        }



        public override void OnRoomSearched(Player? player = null)
        {
            if (_empty)
            {
                Console.WriteLine("The room is empty");
                return;
            }
            Console.WriteLine();
            Loot(player!);
            _empty = true;
            _revealed = true;
        }

        protected virtual void Loot(Player player)
        {
            player!.inventory.PickupItem(LootTables.GetRandomItem(LootTables.CommonTreasure), true);
        }

        public override string RoomIcon()
        {
            if (!_revealed)
                return "[?]".PadRight(3);

            return "[T]".PadRight(3);
        }
    }
}
