using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private void Awake()
    {
        Player.transform.position = Vector3.zero;
    }
    internal void MovePlayer(Vector3 Direction)
    {
        Player.transform.position += Direction;
    }
}
