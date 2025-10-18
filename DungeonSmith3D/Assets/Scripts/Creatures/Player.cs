using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Items;
using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using DiceGame.Scripts.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace DiceGame.Scripts.Creatures
{
    internal class Player : Creature
    {

        private WorldManager? _worldManager;
       internal static Room? CurrentRoom { get; set; }

        private Vector2 _currentLocation = new Vector2(0,0);

        

        public Player(int health = 30, string name = "Player") : base(health, name)
        {
            _worldManager = WorldManager.Instance;
            CurrentRoom = _worldManager!.Rooms()[(int)_currentLocation.X, (int)_currentLocation.Y];
            inventory = new Inventory() { };


            
            inventory.PickupItem(new Fists(),false);
            inventory.PickupItem(new Shortsword($"{Name}'s Shortsword", Weapon.Durability.Sturdy, new Range(5,8)), false);
            inventory.PickupItem(new WorkableMetal(Consumable.RarityTiers.Common), false);
        }

        public void CheckInput()
        {
            while (true)
            {
                Console.WriteLine("Use arrow keys to move");
                Console.WriteLine("");
                Console.WriteLine("[1] Search");
                Console.WriteLine("[2] Inventory");
                Console.WriteLine("");
                var key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Move(Room.Direction.West);
                        break;
                    case ConsoleKey.DownArrow:
                        Move(Room.Direction.East);
                        break;
                    case ConsoleKey.LeftArrow:
                        Move(Room.Direction.South);
                        break;
                    case ConsoleKey.RightArrow:
                        Move(Room.Direction.North);
                        break;
                    case ConsoleKey.D1:
                        CurrentRoom!.OnRoomSearched(this);
                        break;
                    case ConsoleKey.D2:
                        inventory.ViewInventory(Health,_maxHealth);
                        break;
                    default:
                        continue;
                }
            }
        }

        public void Move(Room.Direction direction)
        {
            //room values are clamped so if a room would reference a room that doesnt exist, it instead references itself
            if (CurrentRoom!.RoomRefs[direction] == CurrentRoom)
            {
                Console.WriteLine("Thats a wall");
                return;
            }
            
                // Exit the current room first

                CurrentRoom!.OnRoomExit();

                CurrentRoom = CurrentRoom!.RoomRefs[direction];


                _worldManager!.DisplayWorld(this);

                // Enter the new room
                CurrentRoom!.OnRoomEnter();
            


               
        }
    }
}
