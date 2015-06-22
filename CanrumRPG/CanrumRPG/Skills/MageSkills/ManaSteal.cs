namespace CanrumRPG.Skills.MageSkills
{
    using Characters;

    using Engine;

    using Enums;

    public class ManaSteal : ActiveSkill
    {
        public ManaSteal() 
            : base(0, 0, 0, 100, CharClass.Mage, 8)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            target.CurrentMana -= this.ManaModifier > target.CurrentMana ? this.ManaModifier : target.CurrentMana;
            caster.CurrentMana += this.ManaModifier > target.CurrentMana ? this.ManaModifier : target.CurrentMana;
            GameEngine.Renderer.WriteLine(string.Format("{0} steals {1} mana from {2}.", caster.Name, this.ManaModifier, target.Name));
        }
    }
}
