namespace CanrumRPG.Skills.NPCSkills
{
    using Characters;

    using Enums;

    public class Claw : PassiveSkill
    {
        public Claw(CharClass charClass) : base(15, 0, 0, 0, charClass)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.AttackRating += this.AttackModifier;
        }
    }
}
