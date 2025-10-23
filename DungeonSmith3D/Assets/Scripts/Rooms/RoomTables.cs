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
        public static Room GetRandomRoom(List<KeyValuePair<System.Func<Room>, float>> roomTable)
        {
            if (roomTable == null || roomTable.Count == 0)
                return new EmptyRoom(); // fallback

            // Sum weights
            float totalWeight = 0f;
            foreach (var entry in roomTable)
                totalWeight += Mathf.Max(entry.Value, 0f); // ignore negative weights

            if (totalWeight <= 0f)
                return new EmptyRoom(); // fallback if all weights are zero

            // Pick a random value
            float randomValue = UnityEngine.Random.value * totalWeight;

            foreach (var entry in roomTable)
            {
                if (randomValue < entry.Value)
                    return entry.Key();

                randomValue -= entry.Value;
            }

            // Fallback: last room
            return roomTable[roomTable.Count - 1].Key();
        }


    }
}
