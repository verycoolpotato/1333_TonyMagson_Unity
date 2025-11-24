using DiceGame.Scripts.Creatures;
using UnityEngine;

namespace DiceGame.Scripts.Rooms
{
    internal class ForgeRoom : Room
    {
      

        public override void OnRoomSearched(Player player = null)
        {
            Debug.Log(""); // blank line (optional)
            Debug.Log("Use a workable metal to begin forging");

            _revealed = true;
        }

       
    }
}
