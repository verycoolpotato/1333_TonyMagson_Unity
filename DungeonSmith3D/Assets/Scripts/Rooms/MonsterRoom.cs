using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using UnityEngine;

namespace DiceGame.Scripts.Rooms
{
    internal class MonsterRoom : Room
    {
        protected override string RoomDescription()
        {
            if (!_empty)
                return "A silhouetted figure blocks your path";
            else
                return "A creature lays dead on the floor";
        }

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
                Enemy enemy = EnemyTables.GetRandomEnemy(EnemyTables.CommonEnemies);
                GameManager.Instance!.Combat(enemy);
            }

            _empty = true;
            _revealed = true;
        }

       
    }
}
