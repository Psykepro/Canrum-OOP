namespace CanrumRPG.Skills.RogueSkills
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class ThrowKnife : ActiveSkill
    {
        public ThrowKnife()
            : base(50, 0, 0, 20, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;

            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0} throws a knife at {1} deealing {2} damage.", 
                    caster.Name, 
                    target.Name, 
                    this.AttackModifier));
        }
    }
}
