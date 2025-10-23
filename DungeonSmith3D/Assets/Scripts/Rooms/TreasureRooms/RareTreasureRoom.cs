using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;


namespace DiceGame.Scripts.Rooms.TreasureRooms
{
    internal class RareTreasureRoom : TreasureRoom
    {
        protected override string RoomDescription()
        {
            return "A pile of treasure sits in the middle of the room";
        }

        protected override void Loot(Player player)
        {
            player!.PlayerInventory.PickupItem(LootTables.GetRandomItem(LootTables.RareTreasure), true);
        }

    }
}
