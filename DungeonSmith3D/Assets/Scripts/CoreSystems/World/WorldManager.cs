using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using static DiceGame.Scripts.Rooms.Room;

namespace DiceGame.Scripts.CoreSystems
{
    internal class WorldManager
    {
        public static WorldManager Instance { get; private set; }

        public Dictionary<Direction, Vector3> PossibleDirections = new Dictionary<Direction, Vector3>()
        {
            { Direction.North, new Vector3(0, 0, 1)},
            { Direction.East, new Vector3(1,0, 0)},
            { Direction.South, new Vector3(0,0, -1)},
            { Direction.West, new Vector3(-1,0, 0)}
        };


        private Room[,] _rooms = new Room[0, 0];
        private System.Random random;

        public Room[,] Rooms() => _rooms;

        public WorldManager()
        {
            Instance = this;
            random = new System.Random();
            
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
            _rooms = new Room[GameManager.Instance.RoomGrid, GameManager.Instance.RoomGrid];
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
            GameManager.Instance.Builder.CreateMap();
            BuildDoors();
        }

        /// <summary>
        /// Creates connections between rooms
        /// </summary>
        private void BuildDoors()
        {
            for (int column = 0; column < _rooms.GetLength(1); column++)
            {
                for (int row = 0; row < _rooms.GetLength(0); row++)
                {
                    var room = _rooms[row, column];
                    var directions = room.RoomRefs.Keys.ToList(); // snapshot

                    foreach (var dir in directions)
                    {
                        int x = row + (int)PossibleDirections[dir].x;
                        int z = column + (int)PossibleDirections[dir].z;

                        x = Math.Clamp(x, 0, _rooms.GetLength(0) - 1);
                        z = Math.Clamp(z, 0, _rooms.GetLength(1) - 1);

                        Room assignRoom = _rooms[x, z];
                        room.RoomRefs[dir] = assignRoom;
                    }
                }
            }
        }

        /// <summary>
        /// Prints the world to the Unity console
        /// </summary>
        public void DisplayWorld(Player player)
        {
            Room[,] rooms = _rooms;
            string map = "";

            for (int row = 0; row < rooms.GetLength(0); row++)
            {
                for (int col = 0; col < rooms.GetLength(1); col++)
                {
                    var room = rooms[row, col];
                    if (Player.CurrentRoom == room)
                        map += "[P]";
                    else
                        map += room.RoomIcon();
                }
                map += "\n";
            }

            Debug.Log(map);
        }
    }
}
