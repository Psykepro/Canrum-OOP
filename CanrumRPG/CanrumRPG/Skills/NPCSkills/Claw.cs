namespace CanrumRPG.Skills.NPCSkills
{
    using CanrumRPG.Characters;

    public class Claw : PassiveSkill
    {
        public Claw() : base(15, 0, 0, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.AttackRating += this.AttackModifier;
        }
    }
}
