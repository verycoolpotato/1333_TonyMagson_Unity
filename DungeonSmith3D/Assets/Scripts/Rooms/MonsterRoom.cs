using DiceGame.Scripts.CoreSystems;
using DiceGame.Scripts.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.Rooms
{
    internal class MonsterRoom:Room
    {
        protected override string RoomDescription()
        {
            if (!_empty)
                return "A sillouetted figure blocks your path";
            else
                return "A creature lays dead on the floor";
        }
        public override void OnRoomSearched(Player? player = null)
        {
            if(_empty)
            {
                Console.WriteLine("The room is empty");
                return;
            }
            Console.WriteLine("As you search in the dark you are attacked!");
            
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

        public override string RoomIcon()
        {
            if (!_revealed)
                return "[?]".PadRight(3);
            return "[M]".PadRight(3);
        }



    }
}
