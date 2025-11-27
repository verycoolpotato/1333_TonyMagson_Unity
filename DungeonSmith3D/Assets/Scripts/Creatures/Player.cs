using DiceGame.Scripts.CoreSystems;

using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using DiceGame.Scripts.Rooms;

using UnityEngine;

namespace DiceGame.Scripts.Creatures
{
    internal class Player : Creature
    {
        private WorldManager _worldManager;
        public static Room CurrentRoom { get; private set; }

        private Vector2 _currentLocation = Vector2.zero;

        public Inventory PlayerInventory;

        private PlayerPosition _pos;

       
        [SerializeField] ItemStats[] StarterItems;

       

        public void InitializeAfterWorldBuild()
        {
            _pos = GameManager.Instance.PlayerPosition;
            _worldManager = WorldManager.Instance;

            for (int i = 0; i < StarterItems.Length; i++)
                PlayerInventory.PickupItem(StarterItems[i]);

            CurrentRoom = _worldManager.Rooms()[(int)_currentLocation.x, (int)_currentLocation.y];
        }


      

        public void Move(Room.Direction direction)
        {
            if (CurrentRoom!.RoomRefs[direction] == CurrentRoom)
            {
                Debug.Log("That's a wall");
                return;
            }

            _pos.MovePlayer(_worldManager.PossibleDirections[direction]);

            // Exit current room
            CurrentRoom.OnRoomExit();

            CurrentRoom = CurrentRoom.RoomRefs[direction];

          

            // Enter new room
            CurrentRoom.OnRoomEnter();
        }
    }
}
