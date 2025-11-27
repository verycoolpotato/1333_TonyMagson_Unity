using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Rooms;
using DiceGame.Scripts.Rooms.TreasureRooms;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] RoomMono[] RoomPrefabs;
   
    private RoomMono[,] _visibleRooms;

    public DungeonGrid FloorData;

    public void CreateMap()
    {
        
        _visibleRooms = new RoomMono[FloorData.GridSizeX, FloorData.GridSizeZ];

        for (int x  = 0; x < FloorData.GridSizeX; x++)
        {
            for (int z = 0; z < FloorData.GridSizeZ; z++)
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
        for (int x = 0; x < FloorData.GridSizeX; x++)
        {
            for (int z = 0; z < FloorData.GridSizeZ; z++)
            {
                RoomMono north = z + 1 < FloorData.GridSizeZ ? _visibleRooms[x, z + 1] : null;
                RoomMono south = z - 1 >= 0 ? _visibleRooms[x, z - 1] : null;
                RoomMono east = x + 1 < FloorData.GridSizeX ? _visibleRooms[x + 1, z] : null;
                RoomMono west = x - 1 >= 0 ? _visibleRooms[x - 1, z] : null;

                _visibleRooms[x, z].RoomSetup(north, west, south, east);
            }
        }
    }

    internal void PlaceRoom(Room RoomToPlace, Vector3 Location)
    {
        RoomMono prefab;

        switch (RoomToPlace)
        {
            case TreasureRoom:
                prefab = RoomPrefabs[1];
                break;
            case MonsterRoom:
                prefab = RoomPrefabs[2];
                break;
            case ForgeRoom:
                prefab = RoomPrefabs[3];
                break;
            default:
                prefab = RoomPrefabs[0];
                break;
        }

        RoomMono instance = Instantiate(prefab, Location * FloorData.NodeSize, Quaternion.identity);

        // Link the logical room to the prefab's stats
        if (prefab.Data != null)
            RoomToPlace.RoomStats = prefab.Data;

        _visibleRooms[(int)Location.x, (int)Location.z] = instance;
    }

}
