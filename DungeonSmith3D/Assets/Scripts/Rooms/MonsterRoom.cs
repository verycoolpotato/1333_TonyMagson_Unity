using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using UnityEngine;

namespace DiceGame.Scripts.Rooms
{
    internal class MonsterRoom : Room
    {
        public override void OnRoomSearched(Player player = null)
        {
            if (_empty)
            {
                Debug.Log("The room is empty");
                return;
            }

            Debug.Log("As you search in the dark, you are attacked!");
            EnteredEvent();
        }

        protected override void EnteredEvent()
        {
            if (!_empty)
            {
                Enemy enemy = EnemyTables.GetRandomEnemy(RoomStats.Table);
                CombatManager.Instance.Combat(enemy);
            }

            _empty = true;
            _revealed = true;
        }

       
    }
}
