namespace CanrumRPG.Skills.MageSkills
{
    using Characters;
    using Enums;

    public class Meteor : ActiveSkill
    {
        public Meteor() 
            : base(120, 0, 0, 60, CharClass.Mage, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
