namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;
    using Enums;

    public class Overpower : ActiveSkill
    {
        public Overpower() : base(3, 0, 0, 25, CharClass.Warrior, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= caster.AttackRating * this.AttackModifier;
        }
    }
}
