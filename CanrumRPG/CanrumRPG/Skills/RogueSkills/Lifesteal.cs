namespace CanrumRPG.Skills.RogueSkills
{
    using Characters;
    using Enums;

    public class Lifesteal : PassiveSkill
    {
        public Lifesteal() 
            : base(0, 0, 10, 0, CharClass.Rogue)
        {
        }

        protected override void ApplySkillStats(Character caster)
        {
            caster.CurrentHealth += (caster.AttackRating * this.HealthModifier) / 100;
        }
    }
}
