namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;
    using Enums;

    public class Hedgehog : ActiveSkill
    {
        public Hedgehog() 
            : base(0, 0, 0, 30, CharClass.Warrior, 10)
        {
        }

        protected override void DefaultSkillAction(Character caster, Character target)
        {
            caster.CurrentMana -= this.ManaModifier;
            target.CurrentHealth -= (target.AttackRating * 10) / 100;
        }
    }
}
