using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Rooms;
using DiceGame.Scripts.Rooms.TreasureRooms;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] RoomMono[] RoomPrefabs;
    [SerializeField] private float RoomSize = 10;
    private RoomMono[,] _visibleRooms;

    public void CreateMap()
    {
        int grid = GameManager.Instance.RoomGrid;
        _visibleRooms = new RoomMono[grid, grid];

        for (int x = 0; x < grid; x++)
        {
            for (int z = 0; z < grid; z++)
            {
                Vector3 coords = new Vector3(x, 0, z);
                Room room = WorldManager.Instance.Rooms()[x, z]; 
                PlaceRoom(room, coords);
            }
        }

        OpenDoors();
    }

    internal void OpenDoors()
    {
        int grid = GameManager.Instance.RoomGrid;

        for (int x = 0; x < grid; x++)
        {
            for (int z = 0; z < grid; z++)
            {
                RoomMono north = z + 1 < grid ? _visibleRooms[x, z + 1] : null;
                RoomMono south = z - 1 >= 0 ? _visibleRooms[x, z - 1] : null;
                RoomMono east = x + 1 < grid ? _visibleRooms[x + 1, z] : null;
                RoomMono west = x - 1 >= 0 ? _visibleRooms[x - 1, z] : null;

                _visibleRooms[x, z].RoomSetup(north, west, south, east);
            }
        }
    }

    internal void PlaceRoom(Room RoomToPlace, Vector3 Location)
    {
        RoomMono room;

        switch (RoomToPlace)
        {
            case TreasureRoom:
                room = RoomPrefabs[1];
                break;
            case MonsterRoom:
                room = RoomPrefabs[2];
                break;
            case ForgeRoom:
                room = RoomPrefabs[3];
                break;
            default:
                room = RoomPrefabs[0];
                break;
        }

        RoomMono ThisRoom = Instantiate(room, Location * RoomSize, Quaternion.identity);
        _visibleRooms[(int)Location.x, (int)Location.z] = ThisRoom;
    }
}
