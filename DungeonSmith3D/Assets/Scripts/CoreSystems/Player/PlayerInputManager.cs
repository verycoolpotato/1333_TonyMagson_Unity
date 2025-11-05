using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Rooms;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public void Move(InputAction.CallbackContext input)
    {
        if (input.performed)
        {
         
            if (input.ReadValue<Vector2>() == new Vector2(0,1))
                GameManager.Instance.GamePlayer.Move(Room.Direction.North);
            else if (input.ReadValue<Vector2>() == new Vector2(0, -1))
                GameManager.Instance.GamePlayer.Move(Room.Direction.South);
            else if (input.ReadValue<Vector2>() == new Vector2(-1, 0))
                GameManager.Instance.GamePlayer.Move(Room.Direction.West);
            else if (input.ReadValue<Vector2>() == new Vector2(1, 0)) 
                GameManager.Instance.GamePlayer.Move(Room.Direction.East);
           
        }
       
    }

    public void Search(InputAction.CallbackContext input)
    {
        if (input.performed)
        {
            Debug.Log("Search");
            Player.CurrentRoom.OnRoomSearched(GameManager.Instance.GamePlayer);
        }
    }
}
