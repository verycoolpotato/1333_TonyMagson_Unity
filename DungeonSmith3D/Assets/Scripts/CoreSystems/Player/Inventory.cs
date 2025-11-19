using System;
using System.Collections.Generic;
using UnityEngine;


namespace DiceGame.Scripts.CoreSystems
{
    internal class Inventory : MonoBehaviour
    {
        private List<Item> _inventory = new List<Item>(10) { null, null, null, null, null, null, null, null, null,null};


        [SerializeField] GameObject InventoryPopup;

        public void PickupItem(ItemStats GrabbedItem)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i] == null)
                {
                    //object instance = Activator.CreateInstance(GrabbedItem.ClassType);
                    //Item item = instance as Item;

                    Item item = new Item(GrabbedItem);

                    _inventory[i] = item;
                   
                 
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
           
            //Toggle inventory
            InventoryPopup.SetActive(!InventoryPopup.activeSelf); 

            if (health != null && MaxHealth != null)
                Debug.Log($"{health}/{MaxHealth} Health");

            for (int i = 0; i < _inventory.Count; i++)
            {
                
                string itemName = "Empty";

                if(_inventory[i]?.Name! != null)
                    itemName = _inventory[i].Name;
                
                Debug.Log($"[{i + 1}] {itemName}");
            }
        }

        public List<Item> GetInventory()
        {
            return _inventory;
        }
    }
}
