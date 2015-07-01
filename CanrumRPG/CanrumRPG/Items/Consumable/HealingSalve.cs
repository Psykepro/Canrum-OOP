namespace CanrumRPG.Items.Consumable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    [Treasure]
    public class HealingSalve : Consumed
    {
        public HealingSalve(Position position)
            : base(position, "HealingSalve", 0, 0, 170, 0)
        {
        }

        public override void DefaultItemAction(Character caster, Character target)
        {
            caster.CurrentHealth += this.HealthModifier;

            if (caster.CurrentHealth > caster.MaxHealth)
            {
                caster.CurrentHealth = caster.MaxHealth;
            }

            GameEngine.Renderer.WriteLine(
                "{0} used {1} regenerated {2} health.",
                caster.Name,
                this.GetType().Name,
                this.HealthModifier);
        }
    }
}
