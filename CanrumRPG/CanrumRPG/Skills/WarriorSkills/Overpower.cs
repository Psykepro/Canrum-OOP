namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;
    using Enums;

    public class Overpower : ActiveSkill
    {
        public Overpower() : base(0, 0, 0, 25, CharClass.Warrior, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= caster.AttackRating * 3;
        }
    }
}
