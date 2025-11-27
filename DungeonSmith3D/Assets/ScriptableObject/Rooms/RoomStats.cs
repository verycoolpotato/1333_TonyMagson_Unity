using UnityEngine;

[CreateAssetMenu(fileName = "RoomStats", menuName = "Scriptable Objects/RoomStats")]
public class RoomStats : ScriptableObject
{
    [SerializeField] private string RoomName;
    [SerializeField] private string RoomDescription;
  
    [Tooltip("Can be ignored if no loot in room")]
    [SerializeField] private LootTable RoomLoottable;

    [Tooltip("Can be ignored if no enemy in room")]
    [SerializeField] private EnemyTable EnemyTable;

    public string Name => RoomName;
    public string Description => RoomDescription;
    public LootTable LootTable => RoomLoottable;
    public EnemyTable Table => EnemyTable;

}
