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

        public Player GamePlayer;

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
            //spawns the world
            _worldManager.BuildWorld();

            // spawn player after the world is built, for timing
            GamePlayer.InitializeAfterWorldBuild();

            GamePlayer.HandleInput();
        }



        /// <summary>
        /// Game end — ask if the player wants to retry (simplified for Unity).
        /// </summary>
        public void GameOver()
        {
            Debug.Log("<color=red>Another traveller swallowed by the dungeon.</color>");
            Debug.Log("Restarting the game...");
            ResetProgression();
            Play();
        }

        private void ResetProgression()
        {
            GamePlayer.PlayerInventory.ClearInventory();
           
            _worldManager.ClearWorld();
        }
    }
}
