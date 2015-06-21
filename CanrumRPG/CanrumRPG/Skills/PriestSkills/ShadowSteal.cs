namespace CanrumRPG.Skills.PriestSkills
{
    using Characters;
    using Enums;

    public class ShadowSteal : ActiveSkill
    {
        public ShadowSteal() 
            : base(30, 0, 20, 20, CharClass.Priest, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
            if (this.HealthModifier >= caster.MaxHealth - caster.CurrentHealth)
            {
                caster.CurrentHealth = caster.MaxHealth;
            }
            else
            {
                caster.CurrentHealth += this.HealthModifier;
            }
        }
    }
}
