using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Scriptable Objects/WeaponStats")]
public class WeaponStats : ItemStats
{
    public WeaponHoldStyle ThisWeaponStyle => WeaponStyle;
    public StartingDurability StartDurability => InitialDurability;

    [SerializeField] private WeaponHoldStyle WeaponStyle;
    [SerializeField] private StartingDurability InitialDurability;
    //The style of weapon
    public enum WeaponHoldStyle
    {
        OneHanded = 0,
        TwoHanded = 1,
        Heavy = 2
    }

    //The style of weapon
    public enum StartingDurability
    {
        Unbreakable = 0,
        Sturdy = 1,
        Weathered = 2,
        Fragile = 3,
        Shattered = 4,
    }
}
