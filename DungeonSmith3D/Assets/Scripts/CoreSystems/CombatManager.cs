using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Items.Weapons;
using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private DieRoller _roller = new DieRoller();
    private GameManager _manager;

    public static CombatManager Instance;

    private Item _selectedItem;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        _manager = GameManager.Instance;
    }

    /// <summary>
    /// Starts combat with the given enemy.
    /// </summary>
    public void Combat(Enemy enemy)
    {
        StartCoroutine(CombatLoop(_manager.GamePlayer, enemy));
        _manager.GamePlayer.inventory.CombatInventory();
    }

    public void SelectItem(Item item)
    {
        if(_selectedItem == null)
            _selectedItem = item;
    }


    /// <summary>
    /// Main combat loop 
    /// </summary>
    private IEnumerator CombatLoop(Player player, Enemy enemy)
    {
        while (player.Health > 0 && enemy.Health > 0)
        {
            int playerActions = 3;
            int blockAmount = 0;
            int playerDamage = 0;

            
            int enemyDamage = enemy.NextAttack();

            while (playerActions > 0)
            {
               
                while (_selectedItem == null)
                    yield return null;

                if (_selectedItem.ActionPointCost <= playerActions)
                {
                    if (_selectedItem is Weapon weapon)
                    {
                        if (weapon.WeaponStat.ThisWeaponStyle == Weapon.WeaponStyles.Fists)
                        {
                            blockAmount += weapon.Attack(_roller);
                        }
                        int roll = weapon.Attack(_roller);
                        playerDamage += roll;
                    }


                    playerActions -= _selectedItem.ActionPointCost;
                }

                yield return null;
            }

            enemyDamage -= blockAmount;

            

            if (playerDamage > enemyDamage)
            {
                enemy.Health -= playerDamage;
            }
            else
            {
                player.Health -= enemyDamage;
            }


            yield return new WaitForSeconds(1f);
        }

        if (player.Health <= 0)
        {
            _manager.GameOver();
            yield break;
        }


    }
}
