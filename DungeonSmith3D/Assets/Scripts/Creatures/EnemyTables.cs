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

        /// <summary>
        /// Gets an item from the specified table based on weights
        /// </summary>
        /// <param name="enemyTable"> table from EnemyTables</param>
        /// <returns></returns>
        public static Enemy GetRandomEnemy(EnemyTable Table)
        {
            if (Table == null || Table.TableArray.Length == 0)
                return null;

            int index = UnityEngine.Random.Range(0, Table.TableArray.Length);
            return Table.TableArray[index];
        }



    }
}
