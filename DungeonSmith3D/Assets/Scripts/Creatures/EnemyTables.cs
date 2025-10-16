using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using DiceGame.Scripts.Rooms.TreasureRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Rooms
{
    internal static class EnemyTables
    {
        internal static List<KeyValuePair<Func<Enemy>, float>> CommonEnemies = new List<KeyValuePair<Func<Enemy>, float>>()
        {
            new KeyValuePair<Func<Enemy>, float>(() => new Enemy(20,"Goblin",new Range(8,12)), 4f),
            new KeyValuePair<Func<Enemy>, float>(() => new Enemy(10,"Skeleton",new Range(5,14)), 5f),
            new KeyValuePair<Func<Enemy>, float>(() => new Enemy(30,"Corpse Beast",new Range(5,10)), 2f),
        };





        /// <summary>
        /// Gets an item from the specified table based on weights
        /// </summary>
        /// <param name="enemyTable"> table from EnemyTables</param>
        /// <returns></returns>
        public static Enemy GetRandomEnemy(List<KeyValuePair<Func<Enemy>, float>> enemyTable)
        {/*
            float totalWeight = enemyTable.Sum(r => r.Value);
            float randomValue = Random.Shared.NextSingle() * totalWeight;

            foreach (var enemy in enemyTable)
            {
                if (randomValue < enemy.Value)
                    return enemy.Key(); 
                randomValue -= enemy.Value;
            }

            return enemyTable.Last().Key(); 
            */
            return null;
        }


    }
}
