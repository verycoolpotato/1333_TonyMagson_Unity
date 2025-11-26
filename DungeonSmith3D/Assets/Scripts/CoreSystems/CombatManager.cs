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

    private void Start()
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
        _manager.GamePlayer.PlayerInventory.CombatInventory();
    }

    public void SelectItem(Item item)
    {
        _selectedItem = item;
    }

    private IEnumerator CombatLoop(Player player, Enemy enemy)
    {
        Debug.Log("--- COMBAT STARTED with " + enemy.name + " ---");
        Debug.Log("Player HP: " + player.Health);

        Enemy tempEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        Debug.Log("Spawned tempEnemy: " + tempEnemy.name + " with HP: " + tempEnemy.Health);

        while (player.Health > 0 && tempEnemy.Health > 0)
        {
            Debug.Log("--- NEW TURN ---");
            Debug.Log("Player HP: " + player.Health + "  Enemy HP: " + tempEnemy.Health);

            int playerActions = 3;
            int blockAmount = 0;
            int totalPlayerDamage = 0;

            int incomingDamage = tempEnemy.NextAttack();
            Debug.Log("Enemy plans to attack for " + incomingDamage);

            _selectedItem = null;
            Debug.Log("Waiting for player action selection...");

            while (playerActions > 0)
            {
                while (_selectedItem == null)
                    yield return null;

                Item item = _selectedItem;
                _selectedItem = null;

            

                if (item.ActionPointCost > playerActions)
                {
                    Debug.Log("Not enough AP. Selection ignored. AP remaining: " + playerActions + " ItemCost: " + item.ActionPointCost);
                    continue;
                }

                if (item is Weapon wp)
                {
                    int roll = wp.Attack(_roller);
                    Debug.Log(wp.Name + " Attack returned: " + roll);

                    if (wp.WeaponStat != null && wp.WeaponStat.ThisWeaponStyle == Weapon.WeaponStyles.Fists)
                    {
                        blockAmount += roll;
                        Debug.Log("Block increased by " + roll + ". Total Block: " + blockAmount);
                    }
                    else
                    {
                        totalPlayerDamage += roll;
                        Debug.Log("Damage increased by " + roll + ". Total Player Damage: " + totalPlayerDamage);
                    }
                }
                else
                {
                    Debug.Log("Item selected is not a weapon, skipping damage/attack logic for this item.");
                }

                playerActions -= item.ActionPointCost;
                Debug.Log("AP Remaining: " + playerActions);

                yield return null;
            }

            Debug.Log("--- Resolving Turn ---");
            Debug.Log("Player total damage: " + totalPlayerDamage + " Block: " + blockAmount);

            int finalEnemyDamage = Mathf.Max(0, incomingDamage - blockAmount);
            Debug.Log("Enemy final damage after block: " + finalEnemyDamage);

            if (totalPlayerDamage > 0)
            {
                tempEnemy.Health -= totalPlayerDamage;
                Debug.Log("Enemy takes " + totalPlayerDamage + ", new HP: " + tempEnemy.Health);
            }
            else
            {
                Debug.Log("No player damage this turn.");
            }

            if (finalEnemyDamage > 0)
            {
                player.Health -= finalEnemyDamage;
                Debug.Log("Player takes " + finalEnemyDamage + ", new HP: " + player.Health);
            }

            yield return new WaitForSeconds(0.75f);
        }

        Debug.Log("--- COMBAT ENDED ---");

        if (player.Health <= 0)
        {
            _manager.GamePlayer.PlayerInventory.CombatInventory();

            Debug.Log("Player died!");
            _manager.GameOver();
            yield break;
        }

        _manager.GamePlayer.PlayerInventory.CombatInventory();

        Debug.Log("Enemy defeated!");
    }




}
