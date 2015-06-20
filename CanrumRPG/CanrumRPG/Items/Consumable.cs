namespace CanrumRPG.Items
{
    using Engine;
    using Enums;

    public abstract class Consumable : Item
    {
        public Consumable(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier)
            : base(position, name, attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Active)
        {
        }
    }
}