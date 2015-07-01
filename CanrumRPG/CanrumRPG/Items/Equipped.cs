namespace CanrumRPG.Items
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;
    using CanrumRPG.Enums;

    public abstract class Equipped : Item
    {
        protected Equipped(Position position, string name, int attackModifier, int defenseModifier, int healthModifier, int manaModifier)
            : base(position, name, attackModifier, defenseModifier, healthModifier, manaModifier, Skills.Passive)
        {
        }

        public void ApplyItemStats(Character character)
        {
            character.MaxHealth += this.HealthModifier;
            character.MaxMana += this.ManaModifier;
            character.AttackRating += this.AttackModifier;
            character.DefenseRating += this.DefenseModifier;
        }
    }
}