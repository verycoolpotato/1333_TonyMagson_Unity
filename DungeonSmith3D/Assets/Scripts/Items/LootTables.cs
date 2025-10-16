using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;

using System;
using System.Collections.Generic;
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
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Fools Shortsword", Weapon.Durability.Fragile,new Range(2,4)), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Travelers Shortsword", Weapon.Durability.Weathered,new Range(2,5)), 0.5f),
             new KeyValuePair<Func<Item>, float>(() => new Spear("Travelers Spear", Weapon.Durability.Weathered,new Range(5,7)), 0.4f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Common, new Range(3,7)), 1f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Range(10,15)), 0.4f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Range(20,30)), 0.1f),
            new KeyValuePair<Func<Item>, float>(() => new WorkableMetal(Consumable.RarityTiers.Common), 0.3f),
        };

        internal static List<KeyValuePair<Func<Item>, float>> RareTreasure = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Warhammer("Worn Warhammer", Weapon.Durability.Fragile,new Range(16,20)), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Spear("Blacksmiths Spear", Weapon.Durability.Sturdy,new Range(10,12)), 0.5f),
             new KeyValuePair<Func<Item>, float>(() => new RedMetalSword("Red Metal Sword", Weapon.Durability.Weathered,new Range(6,12)), 0.3f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Range(10,15)), 0.2f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Range(20,30)), 0.5f),
            new KeyValuePair<Func<Item>, float>(() => new WorkableMetal(Consumable.RarityTiers.Common), 0.4f),
        };


        #endregion

        //Drops do not guarantee an item, typically made of common variety loot
        #region DropTables

        internal static List<KeyValuePair<Func<Item>, float>> CommonDrop = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
             new KeyValuePair<Func<Item>, float>(() => new Shortsword("Fools Shortsword", Weapon.Durability.Fragile,new Range(2,4)), 0.3f),
            new KeyValuePair<Func<Item>, float>(() => new Spear("Worn Spear", Weapon.Durability.Weathered, new Range(4,6)), 0.5f),
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Travelers Shortsword", Weapon.Durability.Weathered,new Range(2,5)), 0.5f),

            //consumables
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Common, new Range(3,7)), 1f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Uncommon, new Range(10,15)), 0.4f),
            new KeyValuePair<Func<Item>, float>(() => new HealthGem(Consumable.RarityTiers.Rare, new Range(20,30)), 0.1f),

            //found nothing
             new KeyValuePair<Func<Item>, float>(() => null!, 2f)
        };
        #endregion

        //ForgeTables are only recieved from forges
        #region ForgeTables
        internal static List<KeyValuePair<Func<Item>, float>> CommonForgeOneHanded = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Shortsword("Forged Shortsword", Weapon.Durability.Sturdy, new Range(5, 10)), 1f),
            
        };
        internal static List<KeyValuePair<Func<Item>, float>> CommonForgeTwoHanded = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Spear("Forged Spear", Weapon.Durability.Sturdy, new Range(7, 9)), 1f),

        };
        internal static List<KeyValuePair<Func<Item>, float>> CommonForgeHeavy = new List<KeyValuePair<Func<Item>, float>>()
        {
            //weapons
            new KeyValuePair<Func<Item>, float>(() => new Warhammer("Forged Warhammer", Weapon.Durability.Sturdy, new Range(10, 20)), 1f),

        };
        #endregion


        /// <summary>
        /// Gets an item from the specified loot table based on weights
        /// </summary>
        /// <param name="lootTable">Loot table from the loot tables class</param>
        /// <returns></returns>
        public static Item GetRandomItem(List<KeyValuePair<Func<Item>, float>> lootTable)
        {
            /*
            float totalWeight = lootTable.Sum(i => i.Value);
            float randomValue = Random.Shared.NextSingle() * totalWeight;

            foreach (var item in lootTable)
            {
                if (randomValue < item.Value)
                    return item.Key(); 
                randomValue -= item.Value;
            }

            return lootTable.Last().Key();
            */
            return null;
        }


    }
}
