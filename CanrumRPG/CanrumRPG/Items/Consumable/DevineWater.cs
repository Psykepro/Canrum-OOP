namespace CanrumRPG.Items.Consumable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    [Treasure]
    public class DevineWater : Consumed
    {
        public DevineWater(Position position)
            : base(position, "DevineWater", 0, 0, 200, 200)
        {
        }

        public override void DefaultItemAction(Character caster, Character target)
        {
            caster.CurrentMana += this.ManaModifier;
            caster.CurrentHealth += this.HealthModifier;

            if (caster.CurrentMana > caster.MaxMana)
            {
                caster.CurrentMana = caster.MaxMana;
            }

            if (caster.CurrentHealth > caster.MaxHealth)
            {
                caster.CurrentHealth = caster.MaxHealth;
            }

            GameEngine.Renderer.WriteLine(
                "{0} used {1} regenerated {2} mana and {3} health.",
                caster.Name,
                this.GetType().Name,
                this.ManaModifier,
                this.HealthModifier);
        }
    }
}
