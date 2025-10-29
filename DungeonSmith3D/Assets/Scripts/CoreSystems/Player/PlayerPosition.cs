using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private void Awake()
    {
      
    }
    internal void MovePlayer(Vector3 Direction)
    {
        Player.transform.position += Direction * 10;
    }
}
