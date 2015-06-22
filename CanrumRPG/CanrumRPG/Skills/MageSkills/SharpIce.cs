namespace CanrumRPG.Skills.MageSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class SharpIce : ActiveSkill
    {
        public SharpIce() 
            : base(50, 0, 0, 25, CharClass.Mage, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
            GameEngine.Renderer.WriteLine(string.Format("{0} hurls {1} on {2} for {3} damage.", caster.Name, this.GetType().Name, target.Name, this.AttackModifier));
        }
    }
}
