using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;

using UnityEngine;

namespace DiceGame.Scripts.Rooms.TreasureRooms
{
    internal class TreasureRoom : Room
    {
       

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
            player.PlayerInventory.PickupItem(RoomStats.LootTable.TableArray[0]);
        }

        //LootTables.GetRandomItem(RoomStats.LootTable)
    }
}
