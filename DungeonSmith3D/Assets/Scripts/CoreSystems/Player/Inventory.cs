using DiceGame.Scripts.Items.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace DiceGame.Scripts.CoreSystems
{
    internal class Inventory : MonoBehaviour
    {
        private List<Item> _inventory = new List<Item>(10) { null, null, null, null, null, null, null, null, null,null};


        [SerializeField] GameObject InventoryPopup;
        [SerializeField] GameObject CombatInventoryPopup;

        public void PickupItem(ItemStats grabbed)
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i] == null)
                {
                    Item newItem;

                   
                    if (grabbed is WeaponStats weaponStats)
                    {
                        newItem = new Weapon(weaponStats);
                    }
                    else
                    {
                        newItem = new Item(grabbed);
                    }

                    _inventory[i] = newItem;
                    return;
                }
            }

            Debug.Log("Inventory full!");
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

      
        public void CombatInventory()
        {
            CombatInventoryPopup.SetActive(!CombatInventoryPopup.activeSelf);

          
        }

       
        public void ViewInventory(int? health = null, int? MaxHealth = null)
        {
           
            //Toggle inventory
            InventoryPopup.SetActive(!InventoryPopup.activeSelf); 

           

        }

        public List<Item> GetInventory()
        {
            return _inventory;
        }
    }
}
