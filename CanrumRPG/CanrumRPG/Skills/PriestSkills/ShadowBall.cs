namespace CanrumRPG.Skills.PriestSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class ShadowBall : ActiveSkill
    {
        public ShadowBall()
            : base(120, 0, 0, 60, CharClass.Priest, 9)
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
