namespace CanrumRPG.Skills.PriestSkills
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class Exhaustion : ActiveSkill
    {
        public Exhaustion()
            : base(140, 0, 70, 70, 6)
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
                    "{0} uses {1} on {2} causing {3} damage and heals self in the meantime for {4} health.", 
                    caster.Name, 
                    this.GetType().Name, 
                    target.Name, 
                    this.AttackModifier, 
                    healed));
        }
    }
}
