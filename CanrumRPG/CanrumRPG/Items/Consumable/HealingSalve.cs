using CanrumRPG.Characters;
using CanrumRPG.Engine;

namespace CanrumRPG.Items
{
    public class HealingSalve : Consumable
    {
        public HealingSalve(Position position)
            : base(position, "Healing Salve", 0, 0, 170, 0)
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
