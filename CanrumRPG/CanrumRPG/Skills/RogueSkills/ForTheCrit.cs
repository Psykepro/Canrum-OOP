namespace CanrumRPG.Skills.RogueSkills
{
    using Characters;

    using Enums;

    public class ForTheCrit : PassiveSkill
    {
        public ForTheCrit() 
            : base(25, 0, 0, 0, CharClass.Rogue)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
            caster.CritChance += this.AttackModifier;
        }
    }
}
