using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Items.Weapons;
using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private DieRoller _roller = new DieRoller();
    private GameManager Manager;

    /// <summary>
    /// Starts combat with the given enemy.
    /// </summary>
    public void Combat(Enemy enemy)
    {
        StartCoroutine(CombatLoop(Manager.GamePlayer, enemy));
        Manager.GamePlayer.inventory.CombatInventory();
    }

    public void SelectedItem(Item item)
    {

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

            Debug.Log($"<color=yellow>{enemy.Name} has {enemy.Health} Health</color>");
            int enemyDamage = enemy.NextAttack();

            while (playerActions > 0)
            {
                Debug.Log($"<color=green>{player.Health} Health</color>");
                Debug.Log($"You have {playerActions} Action Points left this turn.");
                Debug.Log($"<color=red>Total Damage: {playerDamage}</color>");

                Item playerItem = player.PlayerInventory.CombatInventory();

                if (playerItem.ActionPointCost <= playerActions)
                {

                    if (playerItem is Weapon weapon)
                    {
                        if (weapon.WeaponStat.ThisWeaponStyle == Weapon.WeaponStyles.Fists)
                        {
                            blockAmount += weapon.Attack(_roller);
                            Debug.Log($"<color=yellow>{enemy.Name}'s attack reduced by {blockAmount}</color>");
                        }
                        int roll = weapon.Attack(_roller);
                        playerDamage += roll;
                        Debug.Log($"<color=orange>Weapon hit for {roll}!</color>");
                    }


                    playerActions -= playerItem.ActionPointCost;
                }

                yield return null; // wait a frame between actions
            }

            enemyDamage -= blockAmount;

            Debug.Log($"{player.Name} swings for {playerDamage}");
            Debug.Log($"{enemy.Name} swings for {enemyDamage}");

            if (playerDamage > enemyDamage)
            {
                Debug.Log($"<color=green>SUCCESS! {player.Name} hit {enemy.Name} for {playerDamage} damage.</color>");
                enemy.Health -= playerDamage;
            }
            else
            {
                Debug.Log($"<color=red>FAILURE! {enemy.Name} hit {player.Name} for {enemyDamage} damage.</color>");
                player.Health -= enemyDamage;
            }

            Debug.Log($"{player.Name} has {player.Health} HP | {enemy.Name} has {enemy.Health} HP");

            yield return new WaitForSeconds(1f);
        }

        if (player.Health <= 0)
        {
            Manager.GameOver();
            yield break;
        }


    }
}
