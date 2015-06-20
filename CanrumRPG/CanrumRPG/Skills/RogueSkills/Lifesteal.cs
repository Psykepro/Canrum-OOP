using CanrumRPG.Characters;
using CanrumRPG.Enums;

namespace CanrumRPG.Skills.RogueSkills
{
    class Lifesteal:PassiveSkill
    {
        public Lifesteal() 
            : base(0 , 0, 10, 0, CharClass.Rogue)
        {
        }

        protected override void ApplySkillStats(Character caster)
        {
            caster.CurrentHealth += (caster.AttackRating*this.HealthModifier)/100;
        }
    }
}
