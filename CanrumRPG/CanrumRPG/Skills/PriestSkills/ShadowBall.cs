namespace CanrumRPG.Skills.PriestSkills
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class ShadowBall : ActiveSkill
    {
        public ShadowBall()
            : base(120, 0, 0, 60, 9)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;

            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0} hurls a {1} on {2} causing {3} damage.", 
                    caster.Name, 
                    this.GetType().Name, 
                    target.Name, 
                    this.AttackModifier));
        }
    }
}
