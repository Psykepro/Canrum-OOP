namespace CanrumRPG.Skills.MageSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class Earthquake : ActiveSkill
    {
        public Earthquake()
            : base(250, 0, 0, 100, CharClass.Mage, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
            GameEngine.Renderer.WriteLine(string.Format("{0} shakes the ground with {1} causing {2} to suffer {3} damage.", caster.Name, this.GetType().Name, target.Name, this.AttackModifier));
        }
    }
}
