namespace CanrumRPG.Items.Consumable
{
    using CanrumRPG.Attributes;
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    [Treasure]
    public class ManaStone : Consumed
    {
        public ManaStone(Position position)
            : base(position, "ManaStone", 0, 0, 0, 250)
        {
        }

        public override void DefaultItemAction(Character caster, Character target)
        {
            caster.CurrentMana += this.ManaModifier;

            if (caster.CurrentMana > caster.MaxMana)
            {
                caster.CurrentMana = caster.MaxMana;
            }

            GameEngine.Renderer.WriteLine(
                "{0} used {1} regenerated {2} mana.",
                caster.Name,
                this.GetType().Name,
                this.ManaModifier);
        }
    }
}
