namespace CanrumRPG.Skills.PriestSkills
{
    using Characters;
    using Enums;

    public class Glory : ActiveSkill
    {
        public Glory() 
            : base(0, 0, 50, 20, CharClass.Priest, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
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
