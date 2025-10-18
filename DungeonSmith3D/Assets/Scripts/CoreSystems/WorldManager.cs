using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using static DiceGame.Scripts.Rooms.Room;


namespace DiceGame.Scripts.CoreSystems
{
    internal class WorldManager
    {
        public static WorldManager? Instance { get; private set; }

        public Dictionary<Direction, Vector2> PossibleDirections = new Dictionary<Direction, Vector2>()
        {
            { Direction.North, new Vector2(0, 1)},
            { Direction.East, new Vector2(1, 0)},
            {Direction.South, new Vector2(0, -1)},
            {Direction.West, new Vector2(-1, 0)}
        };


        private Room[,] _rooms = new Room [5, 5];

     
        public Room[,] Rooms() => _rooms;

        private Random random;

        public WorldManager()
        {
            Instance = this;
            
            // Initialize Random instance once
            random = new Random();
        }

        internal void ClearWorld()
        {
            _rooms = new Room[5, 5];
        }

        /// <summary>
        /// Generates the world
        /// </summary>
        public void BuildWorld()
        {
            _rooms[0, 0] = new ForgeRoom();
            
            for (int row = 0; row < _rooms.GetLength(0); row++)
            {
                for (int column = 0; column < _rooms.GetLength(1); column++)
                {
                    if (_rooms[row, column] == null)
                    {
                        _rooms[row, column] = RoomTables.GetRandomRoom(RoomTables.StandardFloorLayout);

                        _rooms[row, column].SetWorld(this);
                    }
                    
                }
            }
            BuildDoors();
        }

        /// <summary>
        /// Creates connections between rooms
        /// </summary>
        private void BuildDoors()
        {
            for (int column = 0; column < _rooms.GetLength(1); column++)
            {
                Console.WriteLine();
                for (int row = 0; row < _rooms.GetLength(0); row++)
                {
                    //Assign room refs
                    foreach (KeyValuePair<Direction, Room> i in _rooms[row, column].RoomRefs)
                    {
                 
                        int x = row + (int)PossibleDirections[i.Key].X;
                        x = Math.Clamp(x,0,_rooms.GetLength(0) -1);

                        int y = column + (int)PossibleDirections[i.Key].Y;
                        y = Math.Clamp(y, 0, _rooms.GetLength(1) -1);
                        
                            
                            Room assignRoom = _rooms[x, y];

                           _rooms[row, column].RoomRefs[i.Key] = assignRoom;
                        
                        
                    }

                }
            }
        }

       
        /// <summary>
        /// Prints the world to the console
        /// </summary>
        /// <param name="player"></param>
        public void DisplayWorld(Player player)
        {
            Room[,] rooms = _rooms;

            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    var room = rooms[row, col];
                    if (Player.CurrentRoom == room)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[P]");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(room.RoomIcon());
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

      

    }
}
