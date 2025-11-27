using DiceGame.Scripts.Items.Weapons;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemStats", menuName = "Scriptable Objects/WeaponStats")]
public class WeaponStats : ItemStats
{
    internal Weapon.WeaponStyles ThisWeaponStyle => WeaponStyle;
    internal Weapon.Durability StartDurability => InitialDurability;

    [SerializeField] private Weapon.WeaponStyles WeaponStyle;
    [SerializeField] private Weapon.Durability InitialDurability;
   

   
  
}
