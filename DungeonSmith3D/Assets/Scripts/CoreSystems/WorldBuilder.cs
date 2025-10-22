using DiceGame.Scripts.Rooms;
using DiceGame.Scripts.Rooms.TreasureRooms;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField] GameObject[] RoomPrefabs; 


    internal void PlaceRoom(Room RoomToPlace, Vector3 Location)
    {
        GameObject room = null;

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
       GameObject ThisRoom = Instantiate(room,Location,Quaternion.identity);
        ThisRoom.transform.parent = this.transform;
    }
}
