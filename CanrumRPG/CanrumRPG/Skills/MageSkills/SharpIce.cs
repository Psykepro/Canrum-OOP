namespace CanrumRPG.Skills.MageSkills
{
    using Characters;

    using Enums;

    public class SharpIce : ActiveSkill
    {
        public SharpIce() 
            : base(50, 0, 0, 25, CharClass.Mage, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
