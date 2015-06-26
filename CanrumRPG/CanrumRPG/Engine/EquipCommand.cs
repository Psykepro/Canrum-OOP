using System;
using CanrumRPG.Enums;

namespace CanrumRPG.Engine
{
    using Items;
    using Characters;
    public class EquipCommand
    {
        public static void Equip(Item item,Character hero)
        {
            if (item.ItemState == ItemState.Available)
            {
                hero.Inventory.Add(item);
                ApplyItemStats(item, hero);
            }
            else
            {
                Console.WriteLine("You didn't equiped this item because is not available.");
            }

        }

        private static void ApplyItemStats(Item item, Character hero)
        {
            hero.MaxHealth += item.HealthModifier;
            hero.MaxMana += item.ManaModifier;
            hero.AttackRating += item.AttackModifier;
            hero.DefenseRating += item.DefenseModifier;
        }
    }
}
