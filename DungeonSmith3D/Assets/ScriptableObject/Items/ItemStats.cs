using DiceGame.Scripts.Items.Weapons;
using System;
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

    public enum ItemClass
    {
        Weapon,
        Item
    }

    [Header("Identifiers")]
    [SerializeField] private string ItemName;
    [SerializeField] private Sprite ItemImage;
    [SerializeField] private string ItemDescription;

    [Header("Stats")]
    [SerializeField] private Vector2Int RollRange;
    [SerializeField] private ItemClass ThisClass;
    [Range(1, 3)][SerializeField] private int APCost;

    [Header("Drop")]
    [SerializeField] private RarityTiers Rarity;
    [Range(0f, 5f)][SerializeField] private float Weight;

    // Getters
    public Vector2Int ItemRollRange => RollRange;
    public int ActionPointCost => APCost;
    public string ThisItemName => ItemName;
    public Sprite Icon => ItemImage;
    public string Description => ItemDescription;
    public RarityTiers Tier => Rarity;
    public float DropWeight => Weight;
    public ItemClass Class => ThisClass;

    public Type ClassType
    {
        get
        {
            return ThisClass switch
            {
                ItemClass.Weapon => typeof(Weapon),
                ItemClass.Item => typeof(Item),
                _ => null
            };
        }
    }

}
