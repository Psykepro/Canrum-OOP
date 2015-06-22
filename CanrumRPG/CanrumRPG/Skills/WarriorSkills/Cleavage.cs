namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class Cleavage : ActiveSkill
    {
        public Cleavage()
            : base(230, 0, 0, 70, CharClass.Warrior, 7)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;

            GameEngine.Renderer.WriteLine(
                string.Format(
                    "{0} cleaves {1} for {2} damage.",
                    caster.Name,
                    target.Name,
                    this.AttackModifier));
        }
    }
}
