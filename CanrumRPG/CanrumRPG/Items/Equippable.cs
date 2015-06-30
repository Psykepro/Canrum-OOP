namespace CanrumRPG.Items
{
    using CanrumRPG.Engine;
    using CanrumRPG.Enums;

    public abstract class Equippable : Item
    {
        protected Equippable(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier)
            : base(position, name, attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Passive)
        {
        }
    }
}