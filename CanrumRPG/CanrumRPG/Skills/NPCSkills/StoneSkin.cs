namespace CanrumRPG.Skills.NPCSkills
{
    using CanrumRPG.Characters;

    public class StoneSkin : PassiveSkill
    {
        public StoneSkin() : base(0, 15, 0, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.DefenseRating += this.DefenseModifier;
        }
    }
}
