namespace CanrumRPG.Skills.MageSkills
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class ManaSteal : ActiveSkill
    {
        public ManaSteal() 
            : base(100, 0, 0, 0, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            int manaStolen = this.AttackModifier < target.CurrentMana ? this.AttackModifier : target.CurrentMana;
            target.CurrentMana -= manaStolen;
            if (manaStolen + caster.CurrentMana > caster.MaxMana)
            {
                caster.CurrentMana = caster.MaxMana;
            }
            else
            {
                caster.CurrentMana += manaStolen;
            }
            GameEngine.Renderer.WriteLine(string.Format("{0} steals {1} mana from {2}.", caster.Name, this.AttackModifier, target.Name));
        }
    }
}
