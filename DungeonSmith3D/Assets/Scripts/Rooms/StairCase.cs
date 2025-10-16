using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
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
            
            Console.WriteLine("Would you like to ascend to the next floor");
            
           
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
