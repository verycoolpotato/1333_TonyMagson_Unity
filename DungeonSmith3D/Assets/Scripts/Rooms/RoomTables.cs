using UnityEngine; 
using DiceGame.Scripts.Rooms.TreasureRooms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceGame.Scripts.Rooms
{
    internal static class RoomTables
    {
        internal static List<KeyValuePair<Func<Room>, float>> StandardFloorLayout = new List<KeyValuePair<Func<Room>, float>>()
        {
            new KeyValuePair<Func<Room>, float>(() => new TreasureRoom(), 4f),
            new KeyValuePair<Func<Room>, float>(() => new RareTreasureRoom(), 1f),
            new KeyValuePair<Func<Room>, float>(() => new MonsterRoom(), 5f),
            new KeyValuePair<Func<Room>, float>(() => new EmptyRoom(), 10f),
            new KeyValuePair<Func<Room>, float>(() => new ForgeRoom(), 2f),
            

        };





        /// <summary>
        /// Gets an item from the specified roomtable based on weights
        /// </summary>
        /// <param name="roomTable">Room table from the RoomTables</param>
        /// <returns></returns>
        public static Room GetRandomRoom(List<KeyValuePair<Func<Room>, float>> roomTable)
        {
            float totalWeight = roomTable.Sum(r => r.Value);
            float randomValue = UnityEngine.Random.value * totalWeight; 

            foreach (var room in roomTable)
            {
                if (randomValue < room.Value)
                    return room.Key();
                randomValue -= room.Value;
            }

            return roomTable.Last().Key();
        }


    }
}
