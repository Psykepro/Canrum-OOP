namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;
    using Enums;

    class Cleavage : ActiveSkill
    {
        public Cleavage()
            : base(230, 0, 0, 70, CharClass.Warrior, 7)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
