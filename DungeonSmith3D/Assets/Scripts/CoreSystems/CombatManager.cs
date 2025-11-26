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
        Enemy tempEnemy = Instantiate(enemy, transform.position, Quaternion.identity);

        while (player.Health > 0 && tempEnemy.Health > 0)
        {
          
            // START OF TURN
         
            int playerActions = 3;
            int blockAmount = 0;
            int totalPlayerDamage = 0;

            int incomingDamage = tempEnemy.NextAttack();

            // Reset selection for this round
            _selectedItem = null;

           
            // PLAYER ACTION PHASE
           
            while (playerActions > 0)
            {
                // Wait for UI selection
                while (_selectedItem == null)
                    yield return null;

                Item item = _selectedItem;
                _selectedItem = null; 

                if (item.ActionPointCost > playerActions)
                    continue;

                if (item is Weapon weapon)
                {
                    int roll = weapon.Attack(_roller);

                    if (weapon.WeaponStat.ThisWeaponStyle == Weapon.WeaponStyles.Fists)
                    {
                        
                        blockAmount += roll;
                    }
                    else
                    {
                     
                        totalPlayerDamage += roll;
                    }
                }

                playerActions -= item.ActionPointCost;
                yield return null;
            }

   
            // RESOLVE DAMAGE
          
            int finalEnemyDamage = Mathf.Max(0, incomingDamage - blockAmount);

            // enemy takes player damage
            if (totalPlayerDamage > 0)
                tempEnemy.Health -= totalPlayerDamage;

            // player takes damage
            if (finalEnemyDamage > 0)
                player.Health -= finalEnemyDamage;

           
            // Delay
           
            yield return new WaitForSeconds(0.75f);
        }

      
        // END OF COMBAT
      
        if (player.Health <= 0)
        {
            _manager.GameOver();
            yield break;
        }

     
    }

}
