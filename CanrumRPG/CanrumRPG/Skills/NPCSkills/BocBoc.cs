namespace CanrumRPG.Skills.NPCSkills
{
    using CanrumRPG.Characters;

    public class BocBoc : PassiveSkill
    {
        public BocBoc() : base(10, 0, 0, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.CritChance += this.AttackModifier;
        }
    }
}
