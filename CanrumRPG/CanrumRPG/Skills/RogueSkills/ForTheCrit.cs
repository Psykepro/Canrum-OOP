namespace CanrumRPG.Skills.RogueSkills
{
    using CanrumRPG.Characters;

    public class ForTheCrit : PassiveSkill
    {
        public ForTheCrit() 
            : base(25, 0, 0, 0)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.CritChance += this.AttackModifier;
        }
    }
}
