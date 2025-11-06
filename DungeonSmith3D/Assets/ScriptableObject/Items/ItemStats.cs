using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats", menuName = "Scriptable Objects/ItemStats")]
public class ItemStats : ScriptableObject
{

    //Fields
    [SerializeField] private string ItemName;
    [SerializeField] private Vector2Int RollRange;

    [Range(1f, 3f)]
    [SerializeField] private int APCost;




    //Getters
    public Vector2Int ItemRollRange => RollRange;
    public int ActionPointCost => APCost;
    public string ThisItemName => ItemName;
}
