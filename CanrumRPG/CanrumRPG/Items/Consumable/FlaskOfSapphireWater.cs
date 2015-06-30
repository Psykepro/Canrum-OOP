namespace CanrumRPG.Items.Consumable
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class FlaskOfSapphireWater : Consumable
    {
        public FlaskOfSapphireWater(Position position)
            : base(position, "Flask Of Sapphire Water", 0, 0, 115, 0)
        {
        }

        protected override void DefaultItemAction(Character caster, Character target)
        {
            caster.CurrentHealth += this.HealthModifier;

            if (caster.CurrentHealth > caster.MaxHealth)
            {
                caster.CurrentHealth = caster.MaxHealth;
            }

            GameEngine.Renderer.WriteLine("{0} used {1} regenerated {2} health.", caster.Name, this.GetType().Name, 
                this.HealthModifier);
        }
    }
}
