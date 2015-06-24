namespace CanrumRPG.Skills.RogueSkills
{
    using Characters;
    using Enums;

    public class Lifesteal : PassiveSkill
    {
        public Lifesteal() 
            : base(0, 0, 5, 0, CharClass.Rogue)
        {
        }

        public override void ApplySkillStats(Character caster)
        {
        }
    }
}
