using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Items;
using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using DiceGame.Scripts.Rooms;
using System.Collections.Generic;
using UnityEngine;

namespace DiceGame.Scripts.Creatures
{
    internal class Player : Creature
    {
        private WorldManager _worldManager;
        internal static Room CurrentRoom { get; private set; }

        private Vector2 _currentLocation = Vector2.zero;

        public Inventory PlayerInventory;

        // Constructor replaces Awake
        public Player(string name = "Player", int health = 30)
            : base(health, name)
        {
            _worldManager = WorldManager.Instance;
            PlayerInventory = new Inventory();

            // Add starting items
            PlayerInventory.PickupItem(new Fists(), false);
            
            PlayerInventory.PickupItem(new Shortsword($"{name}'s Shortsword", Weapon.Durability.Sturdy, new Vector2Int(5, 8)), false);
            PlayerInventory.PickupItem(new WorkableMetal(Consumable.RarityTiers.Common), false);

            // Set starting room
            if (_worldManager != null)
            {
                CurrentRoom = _worldManager.Rooms()[(int)_currentLocation.x, (int)_currentLocation.y];
            }
        }

      
        public void HandleInput()
        {

            Move(Room.Direction.East);
            PlayerInventory.ViewInventory(Health, _maxHealth);
            //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            //    Move(Room.Direction.North);
            //else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            //    Move(Room.Direction.South);
            //else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            //    Move(Room.Direction.West);
            //else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            //    Move(Room.Direction.East);

            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //    CurrentRoom?.OnRoomSearched(this);

            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //    PlayerInventory.ViewInventory(Health, _maxHealth);
        }

        public void Move(Room.Direction direction)
        {
            if (CurrentRoom!.RoomRefs[direction] == CurrentRoom)
            {
                Debug.Log("That's a wall");
                return;
            }

            // Exit current room
            CurrentRoom.OnRoomExit();

            CurrentRoom = CurrentRoom.RoomRefs[direction];

            _worldManager?.DisplayWorld(this);

            // Enter new room
            CurrentRoom.OnRoomEnter();
        }
    }
}
