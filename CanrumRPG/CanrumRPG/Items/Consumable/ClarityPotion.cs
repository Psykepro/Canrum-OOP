namespace CanrumRPG.Items.Consumable
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class ClarityPotion : Consumable
    {
        public ClarityPotion(Position position)
            : base(position, "Clarity Potion", 0, 0, 0, 55)
        {
        }

        protected override void DefaultItemAction(Character caster, Character target)
        {
            caster.CurrentMana += this.ManaModifier;
            if (caster.CurrentMana > caster.MaxMana)
            {
                caster.CurrentMana = caster.MaxMana;
            }

            GameEngine.Renderer.WriteLine("{0} used {1} regenerated {2} mana.", caster.Name, this.GetType().Name, this.ManaModifier);
        }
    }
}
