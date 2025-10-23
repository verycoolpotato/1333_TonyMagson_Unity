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
        _visibleRooms = new RoomMono[GameManager.Instance.RoomGrid, GameManager.Instance.RoomGrid];

        for (int z = 0; z < GameManager.Instance.RoomGrid; z++)
        {
            for (int x = 0; x < GameManager.Instance.RoomGrid; x++)
            {
                Vector3 coords = new Vector3(x,0,z);

                Room room = WorldManager.Instance.Rooms()[z, x];

                PlaceRoom(room, coords);

            }
        }
        OpenDoors();
    }

    internal void OpenDoors()
    {
        for (int x = 0; x < GameManager.Instance.RoomGrid; x++)
        {
            for (int z = 0; z < GameManager.Instance.RoomGrid; z++)
            {
               
                Room room = WorldManager.Instance.Rooms()[x, z];

                
                _visibleRooms[x, z].RoomSetup(
                  _visibleRooms[x, z + 1],
                   _visibleRooms[x -1 , z],
                    _visibleRooms[x,z - 1],
                   _visibleRooms[x + 1, z]
                );

            }
        }
    }



    internal void PlaceRoom(Room RoomToPlace, Vector3 Location)
    {
        RoomMono room = null;

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
       RoomMono ThisRoom = Instantiate(room,Location * RoomSize,Quaternion.identity);
        

        _visibleRooms[(int)Location.x, (int)Location.z] = ThisRoom;
        
    }
}
