using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using DiceGame.Scripts.Items.Consumables;
using DiceGame.Scripts.Items.Weapons;
using System;
using System.Linq;
using System.Numerics;

using System.Threading;

namespace DiceGame.Scripts.CoreSystems
{
    internal class GameManager
    {
        public static GameManager Instance { get; private set; }

      

        // Essential systems
        private DieRoller _roller = new DieRoller();
        
        private WorldManager _worldManager = new WorldManager();

       

        internal Player GamePlayer;

        internal GameManager()
        {
            Instance = this;
        }

        internal void Intro()
        {
            Console.WriteLine("Welcome to Dungeon Smith!");
            Console.WriteLine("Prepare to enter a deadly dungeon where you'll have to scavenge and create weapons to survive");
        }

        public void Play()
        {
            // Build the dungeon
            _worldManager.BuildWorld();
            // Create player
            GamePlayer = new Player();
            _worldManager.DisplayWorld(GamePlayer);
           
            // Start player movement/input
            GamePlayer.CheckInput();
        }

        /// <summary>
        /// start combat with the enemy passed 
        /// </summary>
        /// <param name="enemy"></param>
        public void Combat(Enemy enemy)
        {
            CombatLoop(GamePlayer, enemy);
        }
        /// <summary>
        /// Main fight loop
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        private void CombatLoop(Player player, Enemy enemy)
        {
         
            while (player.Health > 0 && enemy.Health > 0)
            {
                int PlayerActions = 3;
                int blockAmount = 0;
                //Announce enemy intent and health
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{enemy.Name} has {enemy.Health} Health");
                int enemyDamage = enemy.NextAttack();
                Console.WriteLine();

                //Players turn
                int playerDamage = 0;

                while (PlayerActions > 0)
                {
                   
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{player.Health} Health");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"You have {PlayerActions} Action points left this turn");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                   
                    Console.WriteLine($"{playerDamage} Total Damage");
                    Console.ResetColor();
                    Console.WriteLine();
                    Item playerItem = player.inventory.CombatInventory();
                    
                    if (playerItem.ActionPointCost <= PlayerActions)
                    {
                        

                        if(playerItem is Fists Guard)
                        {
                            //damage reduction
                             blockAmount += Guard.Attack(_roller);
                            
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{enemy.Name}'s attack reduced to " +
                                $"{enemy.ModifiedDamage.Start.Value - blockAmount}-" +
                                $"{enemy.ModifiedDamage.End.Value - blockAmount}");
                            Console.ResetColor();
                            
                        }
                        else if (playerItem is Weapon weapon)
                        {
                            //deal damage
                            Console.WriteLine();
                            int roll = weapon.Attack(_roller);
                            playerDamage += roll;
                            Console.WriteLine();
                        }
                        else if (playerItem is Consumable consumable)
                        {
                            //use item
                            consumable.Use();
                        }

                        PlayerActions -= playerItem.ActionPointCost;
                        continue;
                    }
                   
                }
                //apply block
                enemyDamage -= blockAmount;

                Console.WriteLine($"{player.Name} swings for {playerDamage}");
                Console.WriteLine($"{enemy.Name} swings for {enemyDamage}");
                Console.WriteLine();

                //decide roll winner
                switch (playerDamage > enemyDamage)
                {
                    case true:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"|SUCCESS| {player.Name} hit {enemy.Name} for {playerDamage} damage");
                        Console.ResetColor();
                        enemy.Health -= playerDamage;
                    break;
                    case false:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"|FAILURE| {enemy.Name} hit {player.Name} for {enemyDamage} damage");
                        Console.ResetColor();
                        player.Health -= enemyDamage;
                    break;
                }
                
                Console.WriteLine();

                Console.WriteLine($"{player.Name} has {player.Health} health");
                Console.WriteLine($"{enemy.GetType().Name} has {enemy.Health} health");
                Thread.Sleep(1000);
            }
            if(GamePlayer.Health <= 0)
            {
                GameOver();
            }
            Console.WriteLine("Battle Over!");
            _worldManager.DisplayWorld( GamePlayer );
        }

        /// <summary>
        /// Game end, ask if player wants to retry
        /// </summary>
        private void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Another traveller swallowed by the dungeon");
            Console.WriteLine("Would you like to try again?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");

            while (true)
            {
                switch (InputHelper.GetIntInput())
                {
                    case 1:
                        Console.ResetColor();
                        ResetProgression();
                        Play();
                        break;
                    case 2:
                        Console.WriteLine("Until Next time...");
                        Environment.Exit(0);
                        break;
                    default:
                        continue;
                       
                }
            }
            
        }

        private void ResetProgression()
        {
            GamePlayer.inventory.ClearInventory();
            GamePlayer = new Player();
            _worldManager.ClearWorld();
        }

    }
}
