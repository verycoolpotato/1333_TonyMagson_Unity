
using DiceGame.Scripts.Creatures;


namespace DiceGame.Scripts.Rooms
{
    internal class ForgeRoom:Room
    {
        protected override string RoomDescription()
        {
            return "The room houses a forge, perfect for making new equipment";
        }
        public override void OnRoomSearched(Player? player = null)
        {
            Console.WriteLine();
            Console.WriteLine("Use a workable metal to begin forging");
            
           _revealed = true;
            
        }

        

        public override string RoomIcon()
        {
            if (!_revealed)
                return "[?]".PadRight(3);
            return "[=]".PadRight(3);
        }



    }
}
