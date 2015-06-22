namespace CanrumRPG.Skills.PriestSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class Glory : ActiveSkill
    {
        public Glory() 
            : base(0, 0, 50, 20, CharClass.Priest, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            int healed = this.HealthModifier;
            caster.CurrentMana -= this.ManaModifier;
            if (this.HealthModifier >= caster.MaxHealth - caster.CurrentHealth)
            {
                healed = caster.MaxHealth - caster.CurrentHealth;
                caster.CurrentHealth = caster.MaxHealth;
            }
            else
            {
                caster.CurrentHealth += this.HealthModifier;
            }

            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0} casts {1} healing self for {2} health.",
                    caster.Name,
                    this.GetType().Name,
                    healed));
        }
    }
}
