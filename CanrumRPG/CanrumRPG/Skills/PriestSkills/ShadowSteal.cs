namespace CanrumRPG.Skills.PriestSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class ShadowSteal : ActiveSkill
    {
        public ShadowSteal() 
            : base(30, 0, 20, 20, CharClass.Priest, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            int healed = this.HealthModifier;
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
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
                    "{0} uses {1} on {2} causing {3} damage and healing self for {4} hit points.",
                    caster.Name,
                    this.GetType().Name,
                    target.Name,
                    this.AttackModifier,
                    healed));
        }
    }
}
