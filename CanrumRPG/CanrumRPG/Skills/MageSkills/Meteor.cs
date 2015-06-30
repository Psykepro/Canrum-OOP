namespace CanrumRPG.Skills.MageSkills
{
    using CanrumRPG.Characters;
    using CanrumRPG.Engine;

    public class Meteor : ActiveSkill
    {
        public Meteor() 
            : base(120, 0, 0, 60, 6)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= this.AttackModifier;
            GameEngine.Renderer.WriteLine(string.Format("{0} calls {1} on {2} for {3} damage.", caster.Name, this.GetType().Name, target.Name, this.AttackModifier));
        }
    }
}
