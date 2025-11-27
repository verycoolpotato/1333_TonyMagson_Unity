using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;

using UnityEngine;
using UnityEngine.SceneManagement;

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

        [SerializeField] GameObject PauseMenu;
       
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
           
            _worldManager.BuildWorld();

            GamePlayer.InitializeAfterWorldBuild();

         
        }

        public void PauseGame()
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);
            Time.timeScale = PauseMenu.activeSelf ? 1 : 0 ;
        }

        /// <summary>
        /// Game end — ask if the player wants to retry (simplified for Unity).
        /// </summary>
        public void GameOver()
        {
          
            ResetProgression();
            
            SceneManager.LoadScene("MainMenu");
        }

        private void ResetProgression()
        {
            GamePlayer.PlayerInventory.ClearInventory();
           
            _worldManager.ClearWorld();
        }
    }
}
