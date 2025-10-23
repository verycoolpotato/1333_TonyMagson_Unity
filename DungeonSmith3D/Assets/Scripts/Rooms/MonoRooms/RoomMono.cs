using UnityEngine;

public class RoomMono : MonoBehaviour
{
    //Door references
    [SerializeField] private GameObject NorthDoor, WestDoor, SouthDoor, EastDoor;
    private RoomMono _north,_south, _east,_west;
    public void RoomSetup(RoomMono North, RoomMono West, RoomMono South, RoomMono East)
    {
        //Open doors
        NorthDoor.SetActive(North == null);
        WestDoor.SetActive(West == null);
        EastDoor.SetActive(East == null);
        SouthDoor.SetActive(South == null);

        //Set refs
        _north = North;
        _south = South;
        _east = East;
        _west = West;
    }

}
