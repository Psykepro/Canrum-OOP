namespace CanrumRPG.Skills.PriestSkills
{
    using Characters;
    using Enums;

    class Exhaustion : ActiveSkill
    {
        public Exhaustion()
            : base(140, 0, 70, 70, CharClass.Priest, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
            caster.CurrentHealth += this.HealthModifier;
        }
    }
}
