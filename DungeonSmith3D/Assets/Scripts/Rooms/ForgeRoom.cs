using DiceGame.Scripts.Creatures;
using UnityEngine;

namespace DiceGame.Scripts.Rooms
{
    internal class ForgeRoom : Room
    {
        protected override string RoomDescription()
        {
            return "The room houses a forge, perfect for making new equipment";
        }

        public override void OnRoomSearched(Player player = null)
        {
            Debug.Log(""); // blank line (optional)
            Debug.Log("Use a workable metal to begin forging");

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
