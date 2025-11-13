using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;
using System;
using UnityEngine;

namespace DiceGame.Scripts.Rooms
{
    internal class EmptyRoom : Room
    {
        protected override string RoomDescription()
        {
            _revealed = true;
            return "A dimly lit, mostly empty room";
        }

        public override void OnRoomSearched(Player player = null)
        {
            if (_empty)
            {
                Debug.Log("The room is empty");
                return;
            }

            ItemStats item = LootTables.GetRandomItem(RoomStats.LootTable);
            if (item != null)
            {
                player!.PlayerInventory.PickupItem(item);
                Debug.Log("You manage to scrounge up a small reward");
            }
            else
            {
                Debug.Log("You searched but found nothing");
            }

            _empty = true;
        }

      
    }
}
