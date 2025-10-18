using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Rooms
{
    internal class StairCase:Room
    {
        protected override string RoomDescription()
        {
            
                return "A staircase leading to a new floor";
        }
        public override void OnRoomSearched(Player player = null)
        {
            
            Console.WriteLine("Would you like to descend to the next floor?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");

            while (true)
            {
                switch (InputHelper.GetIntInput())
                {
                    case 1:
                        Console.WriteLine("You enter a new floor");
                        WorldManager world = WorldManager.Instance!;
                        world.ClearWorld();
                        world.BuildWorld();
                        world.DisplayWorld(GameManager.Instance!.GamePlayer);
                        break;

                    case 2:

                        break;

                    default:
                        continue;
                }
            }

            

        }

        protected override void EnteredEvent()
        {
           
            
            
        }

        public override string RoomIcon()
        {
            if (!_revealed)
                return "[?]".PadRight(3);
            return "[^]".PadRight(3);
        }



    }
}
