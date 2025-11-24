using DiceGame.Scripts.Creatures;
using DiceGame.Scripts.Items;


namespace DiceGame.Scripts.Rooms.TreasureRooms
{
    internal class RareTreasureRoom : TreasureRoom
    {
        

        protected override void Loot(Player player)
        {
            player.PlayerInventory.PickupItem(LootTables.GetRandomItem(RoomStats.LootTable));
        }

    }
}
