namespace CanrumRPG.Skills.RogueSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class Stab : ActiveSkill
    {
        public Stab() 
            : base(90, 0, 0, 40, CharClass.Rogue, 5)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;

            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0} stabs {1} for {2} damage.",
                    caster.Name,
                    target.Name,
                    this.AttackModifier));
        }
    }
}
