namespace CanrumRPG.Skills.NPCSkills
{
    using Characters;

    using Enums;

    public class StoneSkin : PassiveSkill
    {
        public StoneSkin(CharClass charClass) : base(0, 15, 0, 0, charClass)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.DefenseRating += this.DefenseModifier;
        }
    }
}
