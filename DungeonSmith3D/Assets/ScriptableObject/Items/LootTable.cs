using UnityEngine;

[CreateAssetMenu(fileName = "LootTable", menuName = "Scriptable Objects/LootTable")]
public class LootTable : ScriptableObject
{
    [SerializeField] private string TableName;
    [SerializeField] private ItemStats[] Items;

    public ItemStats[] TableArray => Items;
    
}
