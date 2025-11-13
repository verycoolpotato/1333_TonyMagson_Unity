using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;

using UnityEngine;

namespace DiceGame.Scripts.Rooms.TreasureRooms
{
    internal class TreasureRoom : Room
    {
        protected override string RoomDescription()
        {
            return "A dusty old room filled with junk, a small glimmer escapes from beneath one of the piles";
        }

        public override void OnRoomSearched(Player player = null)
        {
            if (_empty)
            {
                Debug.Log("The room is empty");
                return;
            }

           
            Loot(player!);
            _empty = true;
            _revealed = true;
        }

        protected virtual void Loot(Player player)
        {
            player.PlayerInventory.PickupItem(LootTables.GetRandomItem(RoomStats.LootTable));
        }

       
    }
}
