using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using DiceGame.Scripts.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DiceGame.Scripts.Items
{
    internal static class LootTables
    {
        //tables contain pre written constructors which are used to make new instances, also has an associated drop weight value

        //Treasure tables guarantee an item, typically a reward
        #region TreasureTables
        internal static List<KeyValuePair<Func<Item>, float>> CommonTreasure = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Fools Shortsword", Weapon.Durability.Fragile,new Vector2Int(2,4)), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Travelers Shortsword", Weapon.Durability.Weathered,new Vector2Int(2,5)), 0.5f),
             new KeyValuePair<Func<Item>, float>(() => new Spear("Travelers Spear", Weapon.Durability.Weathered,new Vector2Int(5,7)), 0.4f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Common, new Vector2Int(3,7)), 1f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Vector2Int(10,15)), 0.4f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Vector2Int(20,30)), 0.1f),
            new KeyValuePair<Func<Item>, float>(() => new WorkableMetal(Consumable.RarityTiers.Common), 0.3f),
        };

        internal static List<KeyValuePair<Func<Item>, float>> RareTreasure = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Warhammer("Worn Warhammer", Weapon.Durability.Fragile,new Vector2Int(16,20)), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Spear("Blacksmiths Spear", Weapon.Durability.Sturdy,new Vector2Int(10,12)), 0.5f),
             new KeyValuePair<Func<Item>, float>(() => new RedMetalSword("Red Metal Sword", Weapon.Durability.Weathered,new Vector2Int(6,12)), 0.3f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Vector2Int(10,15)), 0.2f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Vector2Int(20,30)), 0.5f),
            new KeyValuePair<Func<Item>, float>(() => new WorkableMetal(Consumable.RarityTiers.Common), 0.4f),
        };


        #endregion

        //Drops do not guarantee an item, typically made of common variety loot
        #region DropTables

        internal static List<KeyValuePair<Func<Item>, float>> CommonDrop = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
             new KeyValuePair<Func<Item>, float>(() => new Shortsword("Fools Shortsword", Weapon.Durability.Fragile,new Vector2Int(2,4)), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Spear("Worn Spear", Weapon.Durability.Weathered, new Vector2Int(4,6)), 0.5f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Travelers Shortsword", Weapon.Durability.Weathered,new Vector2Int(2,5)), 0.5f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Common, new Vector2Int(3,7)), 1f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Vector2Int(10,15)), 0.4f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Vector2Int(20,30)), 0.1f),

            //found nothing
             new KeyValuePair<Func<Item>, float>(() => null!, 2f)
        };
        #endregion

        //ForgeTables are only recieved from forges
        #region ForgeTables
        internal static List<KeyValuePair<Func<Item>, float>> CommonForgeOneHanded = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Forged Shortsword", Weapon.Durability.Sturdy, new Vector2Int(5, 10)), 1f),
            
        };
        internal static List<KeyValuePair<Func<Item>, float>> CommonForgeTwoHanded = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Spear("Forged Spear", Weapon.Durability.Sturdy, new Vector2Int(7, 9)), 1f),

        };
        internal static List<KeyValuePair<Func<Item>, float>> CommonForgeHeavy = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Warhammer("Forged Warhammer", Weapon.Durability.Sturdy, new Vector2Int(10, 20)), 1f),

        };
        #endregion


        /// <summary>
        /// Gets an item from the specified loot table based on weights
        /// </summary>
        /// <param name="lootTable">Loot table from the loot tables class</param>
        /// <returns></returns>
        public static Item GetRandomItem(List<KeyValuePair<Func<Item>, float>> itemTable)
        {
            if (itemTable == null || itemTable.Count == 0)
                return null; // fallback: no items available

            // Sum all positive weights
            float totalWeight = 0f;
            foreach (var entry in itemTable)
                totalWeight += Mathf.Max(entry.Value, 0f);

            if (totalWeight <= 0f)
                return null; // fallback if all weights are zero

            // Pick a random value
            float randomValue = UnityEngine.Random.value * totalWeight;

            foreach (var entry in itemTable)
            {
                if (randomValue < entry.Value)
                    return entry.Key();

                randomValue -= entry.Value;
            }

            // Fallback: return the last item
            return itemTable[itemTable.Count - 1].Key();
        }
    }


}

