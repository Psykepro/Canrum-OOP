namespace CanrumRPG.Skills.RogueSkills
{
    using Characters;
    using Enums;

    public class Stab : ActiveSkill
    {
        public Stab() 
            : base(90, 0, 0, 40, CharClass.Rogue, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
        }
    }
}
