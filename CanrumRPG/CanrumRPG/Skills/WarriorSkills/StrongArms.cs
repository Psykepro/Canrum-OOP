namespace CanrumRPG.Skills.WarriorSkills
{
    using CanrumRPG.Characters;

    public class StrongArms : PassiveSkill
    {
        public StrongArms()
            : base(15, 0, 0, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.AttackRating += this.AttackModifier;
        }
    }
}
