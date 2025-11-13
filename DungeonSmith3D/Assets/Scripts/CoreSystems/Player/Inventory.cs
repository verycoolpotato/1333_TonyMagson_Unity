using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace DiceGame.Scripts.CoreSystems
{
    internal class Inventory : MonoBehaviour
    {
        [SerializeField] List<Item> _inventory = new List<Item>(9) { null, null, null, null, null, null, null, null, null };
        
        public void PickupItem(ItemStats GrabbedItem)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i] == null)
                {
                    object instance = Activator.CreateInstance(GrabbedItem.ClassType);
                    Item item = instance as Item;
                    _inventory[i] = item;
                    _inventory[i].Stats = GrabbedItem;
                    return;
                }

            }

            Debug.Log("Inventory full, cannot pick up item!");
        }

        public void ClearInventory()
        {
            for (int i = 0; i < _inventory.Count; i++)
                _inventory[i] = null;
        }

        public void RemoveItemIndex(int index)
        {
            if (index >= 0 && index < _inventory.Count)
                _inventory[index] = null;
        }

        public void RemoveItemType(Item item)
        {
            int index = _inventory.IndexOf(item);
            if (index != -1)
                _inventory[index] = null;
        }

      
        public Item CombatInventory()
        {
            foreach (var item in _inventory)
            {
                if (item != null)
                    return item;

                Debug.Log(item);
            }

            Debug.LogWarning("Inventory empty, returning null.");
            return null;
        }

       
        public void ViewInventory(int? health = null, int? MaxHealth = null)
        {
            Debug.Log("=== INVENTORY ===");

            if (health != null && MaxHealth != null)
                Debug.Log($"{health}/{MaxHealth} Health");

            for (int i = 0; i < _inventory.Count; i++)
            {
                string itemName = _inventory[i]?.Name ?? "Empty";
                Debug.Log($"[{i + 1}] {itemName}");
            }
        }

        public List<Item> GetInventory()
        {
            return _inventory;
        }
    }
}
