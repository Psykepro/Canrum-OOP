namespace CanrumRPG.Skills.MageSkills
{
    using Characters;
    using Enums;

    class Earthquake : ActiveSkill
    {
        public Earthquake()
            : base(250, 0, 0, 100, CharClass.Mage, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
