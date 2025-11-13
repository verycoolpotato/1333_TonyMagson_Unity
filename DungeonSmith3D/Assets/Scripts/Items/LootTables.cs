
using UnityEngine;


namespace DiceGame.Scripts.Items
{
    internal static class LootTables
    {
      

        /// <summary>
        /// Gets an item from the specified loot table based on weights
        /// </summary>
        /// <param name="lootTable">Loot table from the loot tables class</param>
        /// <returns></returns>
        public static ItemStats GetRandomItem(LootTable Table)
        {
            //Check if has items
            if (Table == null || Table.TableArray.Length == 0)
                return null; 

            // Sum all positive weights
            float totalWeight = 0f;
            foreach (var entry in Table.TableArray)
                totalWeight += Mathf.Max(entry.DropWeight, 0f);

            // Pick a random value
            float randomValue = Random.value * totalWeight;

            foreach (var entry in Table.TableArray)
            {
                if (randomValue < entry.DropWeight)
                    return entry;

                randomValue -= entry.DropWeight;
            }

            // Fallback: return the last item
            return Table.TableArray[Table.TableArray.Length -1];
        }
    }


}

