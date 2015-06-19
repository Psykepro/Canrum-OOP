namespace CanrumRPG.Items
{
    using Engine;
    using Enums;

    public class Equipable : Item
    {
        public Equipable(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier)
            : base(position, name, attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Passive)
        {
        }
    }
}