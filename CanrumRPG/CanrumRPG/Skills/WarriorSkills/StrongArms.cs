namespace CanrumRPG.Skills.WarriorSkills
{
    using Characters;
    using Enums;

    public class StrongArms : PassiveSkill
    {
        public StrongArms()
            : base(15, 0, 0, 0, CharClass.Warrior)
        {
        }

        protected override void ApplySkillStats(Character caster)
        {
            caster.AttackRating += this.AttackModifier;
        }
    }
}
