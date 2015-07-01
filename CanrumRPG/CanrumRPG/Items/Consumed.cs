namespace CanrumRPG.Items
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;
    using CanrumRPG.Enums;

    public abstract class Consumed : Item
    {
        public Consumed(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier)
            : base(position, name, attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Active)
        {
        }

        public abstract void DefaultItemAction(Character caster, Character target);
    }
}