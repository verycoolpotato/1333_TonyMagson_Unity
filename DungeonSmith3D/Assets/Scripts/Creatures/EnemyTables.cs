using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using DiceGame.Scripts.Rooms.TreasureRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DiceGame.Scripts.Rooms
{
    internal static class EnemyTables
    {
        internal static List<KeyValuePair<Func<Enemy>, float>> CommonEnemies = new List<KeyValuePair<Func<Enemy>, float>>()
        {
            new KeyValuePair<Func<Enemy>, float>(() => new Enemy(20,"Goblin",new Vector2Int(8,12)), 4f),
            new KeyValuePair<Func<Enemy>, float>(() => new Enemy(10,"Skeleton",new Vector2Int(5,14)), 5f),
            new KeyValuePair<Func<Enemy>, float>(() => new Enemy(30,"Corpse Beast",new Vector2Int(5,10)), 2f),
        };





        /// <summary>
        /// Gets an item from the specified table based on weights
        /// </summary>
        /// <param name="enemyTable"> table from EnemyTables</param>
        /// <returns></returns>
        public static Enemy GetRandomEnemy(List<KeyValuePair<Func<Enemy>, float>> enemyTable)
        {
            if (enemyTable == null || enemyTable.Count == 0)
                return null; // fallback if no enemies exist

            // Sum all positive weights
            float totalWeight = 0f;
            foreach (var entry in enemyTable)
                totalWeight += Mathf.Max(entry.Value, 0f);

            if (totalWeight <= 0f)
                return null; // fallback if all weights are zero

            // Pick a random value
            float randomValue = UnityEngine.Random.value * totalWeight;

            foreach (var entry in enemyTable)
            {
                if (randomValue < entry.Value)
                    return entry.Key();

                randomValue -= entry.Value;
            }

            // Fallback: return the last enemy
            return enemyTable[enemyTable.Count - 1].Key();
        }


    }
}
