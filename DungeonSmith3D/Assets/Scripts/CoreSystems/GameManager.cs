using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using System.Collections;
using UnityEngine;

namespace DiceGame.Scripts.CoreSystems
{
    internal class GameManager : MonoBehaviour
    {

        public WorldBuilder Builder;
        public PlayerPosition PlayerPosition;
        public static GameManager Instance { get; private set; }

        private DieRoller _roller = new DieRoller();
        private WorldManager _worldManager = new WorldManager();

        internal Player GamePlayer;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Intro();
            Play();
        }

        internal void Intro()
        {
            Debug.Log("<color=yellow>Welcome to Dungeon Smith!</color>");
            Debug.Log("Prepare to enter a deadly dungeon where you'll have to scavenge and create weapons to survive.");
        }

        public void Play()
        {
            // Build the dungeon
            _worldManager.BuildWorld();

            // Create player
            GamePlayer = new Player();

            _worldManager.DisplayWorld(GamePlayer);

            // Start player movement/input
            GamePlayer.HandleInput();
        }

        /// <summary>
        /// Starts combat with the given enemy.
        /// </summary>
        public void Combat(Enemy enemy)
        {
            StartCoroutine(CombatLoop(GamePlayer, enemy));
        }

        /// <summary>
        /// Main combat loop (as a coroutine).
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
                        if (playerItem is Fists Guard)
                        {
                            // Damage reduction
                            blockAmount += Guard.Attack(_roller);
                            Debug.Log($"<color=yellow>{enemy.Name}'s attack reduced by {blockAmount}</color>");
                        }
                        else if (playerItem is Weapon weapon)
                        {
                            int roll = weapon.Attack(_roller);
                            playerDamage += roll;
                            Debug.Log($"<color=orange>Weapon hit for {roll}!</color>");
                        }
                        else if (playerItem is Consumable consumable)
                        {
                            consumable.Use();
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

                yield return new WaitForSeconds(1f); // delay between turns
            }

            if (player.Health <= 0)
            {
                GameOver();
                yield break;
            }

            Debug.Log("<color=cyan>Battle Over!</color>");
            _worldManager.DisplayWorld(player);
        }

        /// <summary>
        /// Game end — ask if the player wants to retry (simplified for Unity).
        /// </summary>
        private void GameOver()
        {
            Debug.Log("<color=red>Another traveller swallowed by the dungeon.</color>");
            Debug.Log("Restarting the game...");
            ResetProgression();
            Play();
        }

        private void ResetProgression()
        {
            GamePlayer.PlayerInventory.ClearInventory();
            GamePlayer = new Player();
            _worldManager.ClearWorld();
        }
    }
}
