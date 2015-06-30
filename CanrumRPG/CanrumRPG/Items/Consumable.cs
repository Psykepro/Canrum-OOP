namespace CanrumRPG.Items
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;
    using CanrumRPG.Enums;

    public abstract class Consumable : Item
    {
        public Consumable(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier)
            : base(position, name, attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Active)
        {
        }

        protected abstract void DefaultItemAction(Character caster, Character target);
    }
}