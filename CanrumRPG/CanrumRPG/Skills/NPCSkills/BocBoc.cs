namespace CanrumRPG.Skills.NPCSkills
{
    using Enums;

    using Characters;

    public class BocBoc : PassiveSkill
    {
        public BocBoc(CharClass charClass) : base(10, 0, 0, 0, charClass)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.CritChance += this.AttackModifier;
        }
    }
}
