namespace CanrumRPG.Skills.MageSkills
{
    using Characters;
    using Enums;

    public class ManaSteal : ActiveSkill
    {
        public ManaSteal() 
            : base(0, 0, 0, 100, CharClass.Mage, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            target.CurrentMana -= this.ManaModifier > target.CurrentMana ? this.ManaModifier : target.CurrentMana;
            caster.CurrentMana += this.ManaModifier > target.CurrentMana ? this.ManaModifier : target.CurrentMana;
        }
    }
}
