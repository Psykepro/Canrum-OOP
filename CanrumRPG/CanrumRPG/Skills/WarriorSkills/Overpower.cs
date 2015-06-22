namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class Overpower : ActiveSkill
    {
        public Overpower() : base(3, 0, 0, 25, CharClass.Warrior, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= caster.AttackRating * this.AttackModifier;
            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0} {1}s {2} for {3} damage.",
                    caster.Name,
                    this.GetType().Name,
                    target.Name,
                    this.AttackModifier * caster.AttackRating));
        }
    }
}
