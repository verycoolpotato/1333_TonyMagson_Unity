using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemStats", menuName = "Scriptable Objects/ItemStats")]
public class ItemStats : ScriptableObject
{

    public enum RarityTiers
    {
        Common = 0,
        Uncommon = 1,
        Rare = 2,
        Unique = 3
    }

    //Fields
    [Header("Identifiers")]
    [SerializeField] private string ItemName;
    [SerializeField] private Image ItemImage;
    [SerializeField] private string ItemDescription;

    [Header("Stats")]
    [SerializeField] private Vector2Int RollRange;

    [Range(1f, 3f)]
    [SerializeField] private int APCost;
    [SerializeField] private RarityTiers Rarity;
 

    //Getters
    public Vector2Int ItemRollRange => RollRange;
    public int ActionPointCost => APCost;
    public string ThisItemName => ItemName;
    public Image Icon => ItemImage;
    public string Description => ItemDescription;
    public RarityTiers Tier => Rarity;
}
